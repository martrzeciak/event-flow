import { Component, inject, OnInit } from '@angular/core';
import { Order } from '../../shared/models/order';
import { OrderService } from '../../core/services/order.service';
import { CurrencyPipe, DatePipe } from '@angular/common';
import { RouterLink, RouterModule } from '@angular/router';
import { OrderParams } from '../../shared/models/orderParams';
import { Pagination } from '../../shared/models/pagination';
import { AccountService } from '../../core/services/account.service';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuTrigger } from '@angular/material/menu';

@Component({
  selector: 'app-order',
  imports: [
    DatePipe,
    CurrencyPipe,
    RouterModule,
    MatPaginator,
    MatIconModule,
    MatMenuTrigger,
    RouterLink
  ],
  templateUrl: './order.component.html',
  styleUrl: './order.component.scss'
})
export class OrderComponent implements OnInit {
  private orderSerice = inject(OrderService);
  private accountService = inject(AccountService);
  orders?: Order[];
  orderParams = new OrderParams();
  pageSizeOptions = [12, 24, 36, 48];
  pagination: Pagination | undefined;
  sortOpions = [
    { name: 'Date: Newest to Oldest', value: 'date' },
    { name: 'Date: Oldest to Newest', value: 'dateDesc' },
  ]

  ngOnInit(): void {
    this.initializeOrderComponent();
  }

  initializeOrderComponent() {
    this.getOrders();
  }

  getOrders() {
    this.orderSerice.getOrdersForUser(this.orderParams).subscribe({
      next: respone => {
        this.orders = respone.result;
        this.pagination = respone.pagination;
        console.log(respone.result);
      },
      error: error => console.log(error)
    });
  }

  handlePageEvent(event: PageEvent) {
    this.orderParams.pageNumber = event.pageIndex + 1;
    this.orderParams.pageSize = event.pageSize;
    this.getOrders();
  }
}