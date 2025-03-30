import { Component, inject, input, OnInit } from '@angular/core';
import { CartItem } from '../../../shared/models/cart';
import { CartService } from '../../../core/services/cart.service';
import { MatIcon } from '@angular/material/icon';
import { CurrencyPipe } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-cart-item',
  imports: [
    MatIcon,
    MatButtonModule,
    MatIconModule,
    CurrencyPipe,
    
  ],
  templateUrl: './cart-item.component.html',
  styleUrl: './cart-item.component.scss'
})
export class CartItemComponent {
  item = input.required<CartItem>();
  cartService = inject(CartService);

  incrementQuantity() {
    this.cartService.addItemToCart(this.item());
  }

  decrementQuantity() {
    this.cartService.removeItemFromCart(this.item().ticketId);
  }

  removeItemFromCart() {
    this.cartService.removeItemFromCart(this.item().ticketId, this.item().quantity);
  }
}
