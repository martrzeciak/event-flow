import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient, HttpParams } from '@angular/common/http';
import { EventModel } from '../../shared/models/eventModel';
import { getPaginatedResult } from '../../shared/helpers/paginationHelper';
import { EventParams } from '../../shared/models/eventParams';

@Injectable({
  providedIn: 'root'
})
export class EventService {
  private baseUrl: string = environment.apiUrl;
  private http = inject(HttpClient);
  categories: string[] = [];
  
  getEvents(eventParams: EventParams) {
    let params = new HttpParams();

    params = params.append('pageSize', eventParams.pageSize);
    params = params.append('pageNumber', eventParams.pageNumber);
    params = params.append('orderBy', eventParams.orderBy);

    if (eventParams.categories.length > 0) {
      params = params.append('categories', eventParams.categories.join(','));
    }

    if (eventParams.search) {
      params = params.append('search', eventParams.search);
    }

    return getPaginatedResult<EventModel[]>(this.baseUrl + 'events', params, this.http);
  }

  getCategories() {
    if (this.categories.length > 0) return;

    return this.http.get<string[]>(this.baseUrl + 'events/categories').subscribe({
      next: response => this.categories = response
    })
  }
}
