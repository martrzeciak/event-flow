import { Component } from '@angular/core';
import { EmptyStateComponent } from "../../shared/components/empty-state/empty-state.component";

@Component({
  selector: 'app-cart',
  imports: [EmptyStateComponent],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.scss'
})
export class CartComponent {

}
