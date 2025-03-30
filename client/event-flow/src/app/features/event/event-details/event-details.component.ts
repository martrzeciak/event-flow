import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventModel } from '../../../shared/models/eventModel';
import { EventService } from '../../../core/services/event.service';
import { MatDivider } from '@angular/material/divider';
import { MatFormField, MatLabel } from '@angular/material/form-field';
import { MatIcon } from '@angular/material/icon';
import { MatButton } from '@angular/material/button';
import { MatInput } from '@angular/material/input';
import { CurrencyPipe, DatePipe } from '@angular/common';
import { AddressPipe } from '../../../shared/pipes/address.pipe';
import { FormsModule } from '@angular/forms';
import { CartService } from '../../../core/services/cart.service';
import { Ticket } from '../../../shared/models/ticket';

@Component({
  selector: 'app-event-details',
  imports: [
    MatDivider,
    MatLabel,
    MatIcon,
    MatFormField,
    MatButton,
    MatInput,
    DatePipe,
    AddressPipe,
    CurrencyPipe,
    FormsModule
],
  templateUrl: './event-details.component.html',
  styleUrl: './event-details.component.scss'
})
export class EventDetailsComponent implements OnInit {
  private eventService = inject(EventService);
  private activatedRoute = inject(ActivatedRoute);
  private cartService = inject(CartService);
  event?: EventModel;
  selectedTicketQuantities: { [ticketType: string]: number } = {};
  ticketQuantitiesInCart: { [ticketType: string]: number } = {};

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (!id) return;
    this.eventService.getEvent(id).subscribe({
      next: response => {
        this.event = response;
        this.initializeTicketQuantities();
      },
      error: error => console.log(error)
    })
  }

  initializeTicketQuantities() {
    if (!this.event) return;
    this.event.tickets.forEach(ticket => {
      this.selectedTicketQuantities[ticket.ticketType] = 1;
      this.ticketQuantitiesInCart[ticket.ticketType] = 0;
    });
  }

  incrementQuantity(ticketType: string, available: number) {
    if (this.selectedTicketQuantities[ticketType] < available) {
      this.selectedTicketQuantities[ticketType]++;
    }
  }

  decrementQuantity(ticketType: string) {
    if (this.selectedTicketQuantities[ticketType] > 0) {
      this.selectedTicketQuantities[ticketType]--;
    }
  }

  updateCart(ticket: Ticket, selectedQuantity: number, availableQuantity: number) {
    if (!this.event) return;
    if (selectedQuantity > availableQuantity) return;
  
    const ticketType = ticket.ticketType;
    const currentQuantityInCart = this.ticketQuantitiesInCart[ticketType] || 0;
  
    if (selectedQuantity > currentQuantityInCart) {
      const itemsToAdd = selectedQuantity - currentQuantityInCart;
      this.ticketQuantitiesInCart[ticketType] = currentQuantityInCart + itemsToAdd;
      this.cartService.addItemToCart(ticket, itemsToAdd, this.event.name, this.event.id);
    } else if (selectedQuantity < currentQuantityInCart) {
      const itemsToRemove = currentQuantityInCart - selectedQuantity;
      this.ticketQuantitiesInCart[ticketType] = currentQuantityInCart - itemsToRemove;
      this.cartService.removeItemFromCart(ticket.id, itemsToRemove);
    }
  }
}

