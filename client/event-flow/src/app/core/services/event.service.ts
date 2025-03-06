import { inject, Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Pagination } from '../../shared/models/pagination';

@Injectable({
  providedIn: 'root'
})
export class EventService {
  private baseUrl: string = environment.apiUrl;
  private http = inject(HttpClient);
  
  getEvents() {
    return this.http.get<Pagination<Event>>(this.baseUrl + 'events');
  }

  getEvent(id: string) {
    return this.http.get<Event>(this.baseUrl + 'events/' + id);
  }
}
