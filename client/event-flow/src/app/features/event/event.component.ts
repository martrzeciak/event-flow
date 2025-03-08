import { Component, inject, OnInit } from '@angular/core';
import { EventItemComponent } from "./event-item/event-item.component";
import { EventService } from '../../core/services/event.service';
import { EventModel } from '../../shared/models/eventModel';
import { EventParams } from '../../shared/models/eventParams';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { Pagination } from '../../shared/models/pagination';

@Component({
  selector: 'app-event',
  imports: [
    MatPaginator,
    EventItemComponent
  ],
  templateUrl: './event.component.html',
  styleUrl: './event.component.scss'
})
export class EventComponent implements OnInit {
  private eventService = inject(EventService);
  eventList?: EventModel[];
  eventObject?: EventModel;
  eventParams = new EventParams();
  pageSizeOptions = [4, 8, 16, 24];
  pagination: Pagination | undefined;
  
  ngOnInit(): void {
    this.initializeEventComponent();
  }

  initializeEventComponent() {
    this.getProducts();
  }

  getProducts() {
    this.eventService.getEvents(this.eventParams).subscribe({
      next: response => {
        this.eventList = response.result;
        this.pagination = response.pagination;
      },
      error: error => console.log(error)
    })
  }

  handlePageEvent(event: PageEvent) {
    this.eventParams.pageNumber = event.pageIndex + 1;
    this.eventParams.pageSize = event.pageSize;
    this.getProducts();
  }
}
