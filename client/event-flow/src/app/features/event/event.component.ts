import { Component, inject, OnInit } from '@angular/core';
import { EventItemComponent } from "./event-item/event-item.component";
import { EventService } from '../../core/services/event.service';
import { EventModel } from '../../shared/models/eventModel';
import { EventParams } from '../../shared/models/eventParams';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { Pagination } from '../../shared/models/pagination';
import { MatListOption, MatSelectionList, MatSelectionListChange } from '@angular/material/list';
import { MatMenu, MatMenuTrigger } from '@angular/material/menu';
import { MatIcon } from '@angular/material/icon';
import { MatButton } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { provideNativeDateAdapter } from '@angular/material/core';
import { MatDialog } from '@angular/material/dialog';
import { FiltersDialogComponent } from './filters-dialog/filters-dialog.component';

@Component({
  selector: 'app-event',
  imports: [
    MatPaginator,
    EventItemComponent,
    MatMenu,
    MatSelectionList,
    MatListOption,
    MatMenuTrigger,
    MatIcon,
    MatButton,
    FormsModule,
    MatFormFieldModule,
    MatDatepickerModule
  ],
  templateUrl: './event.component.html',
  styleUrl: './event.component.scss',
  providers: [provideNativeDateAdapter()],
})
export class EventComponent implements OnInit {
  private eventService = inject(EventService);
  private dialogService = inject(MatDialog);
  eventList?: EventModel[];
  eventObject?: EventModel;
  eventParams = new EventParams();
  pageSizeOptions = [4, 8, 16, 24];
  pagination: Pagination | undefined;
  sortOptions = [
    {name: 'Date: Newest to Oldest', value: 'date'},
    {name: 'Date: Oldest to Newest', value: 'dateDesc'},
    {name: 'Alphabetical', value: 'name'}
  ]
  
  ngOnInit(): void {
    this.initializeEventComponent();
  }

  initializeEventComponent() {
    this.eventService.getCategories();
    this.getEvents();
  }

  getEvents() {
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
    this.getEvents();
  }

  onSortChange(event: MatSelectionListChange) {
    const selectedOption = event.options[0];
    if (selectedOption) {
      this.eventParams.orderBy = selectedOption.value;
      this.eventParams.pageNumber = 1;
      this.getEvents();
    }
  }

  onSearchChange() {
    console.log(this.eventParams.search)
    this.eventParams.pageNumber = 1;
    this.getEvents();
  }

  openFiltersDialog() {
    const dialogRef = this.dialogService.open(FiltersDialogComponent, {
      minWidth: '500px',
      data: {
        selectedCategories: this.eventParams.categories,
      }
    });
    dialogRef.afterClosed().subscribe({
      next: result => {
        if (result) {
          this.eventParams.categories = result.selectedCategories;
          this.eventParams.pageNumber = 1;
          this.getEvents();
        }
      }
    })
  }

  resetParams() {
    this.eventParams = new EventParams();
    this.getEvents();
  }
}
