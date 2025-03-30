import { computed, inject, Injectable, signal } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Cart, CartItem } from '../../shared/models/cart';
import { firstValueFrom, map, tap } from 'rxjs';
import { Ticket } from '../../shared/models/ticket';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  baseUrl: string = environment.apiUrl;
  private http = inject(HttpClient);
  cart = signal<Cart | null>(null);
  itemCount = computed(() => {
    return this.cart()?.items.reduce((sum, item) => sum + item.quantity, 0)
  });
  totals = computed(() => {
    const cart = this.cart();

    if (!cart) return null;
    const subtotal = cart.items.reduce((sum, item) => sum + item.price * item.quantity, 0);

    return {
      subtotal,
      discount: 0,
      total: subtotal
    }
  })

  getCart(id: string) {
    return this.http.get<Cart>(this.baseUrl + 'cart?id=' + id).pipe(
      map(cart => {
        this.cart.set(cart);
        return cart;
      })
    )
  }

  setCart(cart: Cart) {
    return this.http.post<Cart>(this.baseUrl + 'cart', cart).pipe(
      tap(cart => {
        this.cart.set(cart)
      })
    )
  }

  deleteCart() {
    this.http.delete(this.baseUrl  + 'cart?id=' + this.cart()?.id).subscribe({
      next: () => {
        localStorage.removeItem('cart_id');
        this.cart.set(null);
      }
    })
  }

  async addItemToCart(item: CartItem | Ticket, quantity = 1, 
    eventName = 'Event name not provided', eventId = '') {
    const cart = this.cart() ?? this.createCart();
    if (this.isTicket(item)) {
      item = this.mapTicketToCartItem(item, eventName, eventId);
    }
    cart.items = this.addOrUpdateItem(cart.items, item, quantity);
    await firstValueFrom(this.setCart(cart));
  }

  async removeItemFromCart(ticketId: string, quantity = 1) {
    const cart = this.cart();
    if (!cart) return;
    const index = cart.items.findIndex(x => x.ticketId === ticketId);
    if (index !== -1) {
      if (cart.items[index].quantity > quantity) {
        cart.items[index].quantity -= quantity;
      } else {
        cart.items.splice(index, 1);
      }
      if (cart.items.length === 0) {
        this.deleteCart();
      } else {
        await firstValueFrom(this.setCart(cart));
      }
    }
  }

  private addOrUpdateItem(items: CartItem[], item: CartItem, quantity: number): CartItem[] {
    const index = items.findIndex(x => x.ticketId === item.ticketId);
    if (index === -1) {
      item.quantity = quantity;
      items.push(item);
    } else {
      items[index].quantity += quantity
    }
    return items;
  }

  private mapTicketToCartItem(item: Ticket, eventName: string, eventId: string): CartItem {
    return {
      ticketId: item.id,
      eventName: eventName,
      eventId: eventId,
      ticketType: item.ticketType,
      price: item.price,
      quantity: 0
    }
  }

  private isTicket(item: CartItem | Ticket): item is Ticket {
    return (item as Ticket).id !== undefined;
  }

  private createCart(): Cart {
    const cart = new Cart();
    localStorage.setItem('cart_id', cart.id);
    return cart;
  }
}
