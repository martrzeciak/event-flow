import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { OrderService } from '../../../core/services/order.service';
import { CurrencyPipe, DatePipe, NgIf } from '@angular/common';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { AddressPipe } from '../../../shared/pipes/address.pipe';
import { RouterLink } from '@angular/router';
import { PaymentCardPipe } from '../../../shared/pipes/payment-card.pipe';
import { Order } from '../../../shared/models/order';

@Component({
  selector: 'app-checkout-success',
  imports: [
    MatButtonModule,
    RouterLink,
    DatePipe,
    PaymentCardPipe,
    CurrencyPipe,
    AddressPipe,
    MatProgressSpinnerModule,
    NgIf
  ],
  templateUrl: './checkout-success.component.html',
  styleUrl: './checkout-success.component.scss'
})
export class CheckoutSuccessComponent implements OnDestroy, OnInit {
  private orderService = inject(OrderService);
  order?: Order;

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  ngOnDestroy(): void {
    this.orderService.orderComplete.set(false);
  }
}
