import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../../environments/environment.development';
import { Order, OrderToCreate } from '../../shared/models/order';
import { HttpClient, HttpParams } from '@angular/common/http';
import { OrderParams } from '../../shared/models/orderParams';
import { getPaginatedResult } from '../../shared/helpers/paginationHelper';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  baseUrl: string = environment.apiUrl;
  private http = inject(HttpClient);
  orderComplete = signal<boolean>(false);

  createOrder(orderToCreate: OrderToCreate) {
    return this.http.post<Order>(this.baseUrl + 'orders', orderToCreate);
  }

  getOrdersForUser(orderParams: OrderParams) {
    let params = new HttpParams();

    params = params.append('pageSize', orderParams.pageSize);
    params = params.append('pageNumber', orderParams.pageNumber);
    params = params.append('orderBy', orderParams.orderBy);

    return getPaginatedResult<Order[]>(this.baseUrl + 'orders', params, this.http);
  }

  getOrderDetailed(id: string) {
    return this.http.get<Order>(this.baseUrl + 'orders/' + id);
  }
}
