import { Pipe, PipeTransform } from '@angular/core';
import { Ticket } from '../models/ticket';

@Pipe({
  name: 'minTicketPrice'
})
export class MinTicketPricePipe implements PipeTransform {

  transform(value: Ticket[], ...args: unknown[]): number | null {
    if (!value || value.length === 0) {
      return null;
    }
    return Math.min(...value.map(ticket => ticket.price));
  }

}
