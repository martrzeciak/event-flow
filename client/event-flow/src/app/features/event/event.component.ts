import { Component, inject, OnInit } from '@angular/core';
import { EventItemComponent } from "./event-item/event-item.component";
import { PaginatedResult, Pagination } from '../../shared/models/pagination';
import { EventService } from '../../core/services/event.service';
import { EventModel } from '../../shared/models/eventModel';
@Component({
  selector: 'app-event',
  imports: [EventItemComponent],
  templateUrl: './event.component.html',
  styleUrl: './event.component.scss'
})
export class EventComponent implements OnInit {
  private eventService = inject(EventService);
  eventList?: EventModel[];
  eventObject?: EventModel;
  
  ngOnInit(): void {
    this.initializeEventComponent();
  }

  initializeEventComponent() {
    this.getProducts();
  }

  getProducts() {
    this.eventService.getEvents().subscribe({
      next: response => {
        this.eventList = response.result;
        console.log(this.eventList)
      },
      error: error => console.log(error)
    })
  }
}
