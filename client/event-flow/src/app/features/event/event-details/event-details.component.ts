import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EventModel } from '../../../shared/models/eventModel';
import { EventService } from '../../../core/services/event.service';
import { MatDivider } from '@angular/material/divider';
import { MatFormField, MatHint, MatLabel } from '@angular/material/form-field';
import { MatIcon } from '@angular/material/icon';
import { MatButton } from '@angular/material/button';
import { MatInput } from '@angular/material/input';
import { CurrencyPipe, DatePipe } from '@angular/common';
import { AddressPipe } from '../../../shared/pipes/address.pipe';
import { MinTicketPricePipe } from '../../../shared/pipes/min-ticket-price.pipe';

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
    MatHint,
    MinTicketPricePipe,
    CurrencyPipe
  ],
  templateUrl: './event-details.component.html',
  styleUrl: './event-details.component.scss'
})
export class EventDetailsComponent implements OnInit {
  private eventService = inject(EventService);
  private activatedRoute = inject(ActivatedRoute);
  event?: EventModel;
  quantity: number = 0;

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (!id) return;
    this.eventService.getEvent(id).subscribe({
      next: response => {
        this.event = response;
      },
      error: error => console.log(error)
    })
  }
}

