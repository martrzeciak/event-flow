import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient, HttpParams } from '@angular/common/http';
import { EventModel } from '../../shared/models/eventModel';
import { getPaginatedResult } from '../../shared/helpers/paginationHelper';

@Injectable({
  providedIn: 'root'
})
export class EventService {
  private baseUrl: string = environment.apiUrl;
  private http = inject(HttpClient);
  
  getEvents() {
    let params = new HttpParams();

    params = params.append('pageSize', 10);
    params = params.append('pageNumber', 1);

    return getPaginatedResult<EventModel[]>(this.baseUrl + 'events', params, this.http);
  }
}
