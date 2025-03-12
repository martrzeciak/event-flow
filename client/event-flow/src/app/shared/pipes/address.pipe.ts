import { Pipe, PipeTransform } from '@angular/core';
import { Address } from '../models/address';

@Pipe({
  name: 'address'
})
export class AddressPipe implements PipeTransform {

  transform(value: Address, ...args: unknown[]): unknown {
    return `${value.country}, ${value.city}, ${value.line1},
      ${value.state} ${value.postalCode}`;
  }

}
