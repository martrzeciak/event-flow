import { Component, Input } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';
import { EventModel } from '../../../shared/models/eventModel';
import { MatIcon } from '@angular/material/icon';
import { CurrencyPipe, DatePipe } from '@angular/common';
import { AddressPipe } from '../../../shared/pipes/address.pipe';
import { MatButtonModule } from '@angular/material/button';
import { RouterLink } from '@angular/router';
import { MinTicketPricePipe } from '../../../shared/pipes/min-ticket-price.pipe';
@Component({
  selector: 'app-event-item',
  imports: [
    MatCardModule, 
    MatChipsModule,
    MatIcon,
    DatePipe,
    AddressPipe,
    MatButtonModule,
    RouterLink,
    MinTicketPricePipe,
    CurrencyPipe
  ],
  templateUrl: './event-item.component.html',
  styleUrl: './event-item.component.scss'
})
export class EventItemComponent {
  @Input() event?: EventModel;

}
