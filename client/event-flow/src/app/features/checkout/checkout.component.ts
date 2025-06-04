import { Component, inject, OnDestroy, OnInit, signal } from '@angular/core';
import { MatStepper, MatStepperModule } from '@angular/material/stepper';
import { OrderSummaryComponent } from "../../shared/components/order-summary/order-summary.component";
import { MatButton } from '@angular/material/button';
import { Router, RouterLink } from '@angular/router';
import { StripeService } from '../../core/services/stripe.service';
import { ConfirmationToken, StripeAddressElement, StripePaymentElement, StripePaymentElementChangeEvent } from '@stripe/stripe-js';
import { SnackbarService } from '../../core/services/snackbar.service';
import { CartService } from '../../core/services/cart.service';
import { CurrencyPipe } from '@angular/common';
import { CheckoutReviewComponent } from "./checkout-review/checkout-review.component";
import { StepperSelectionEvent } from '@angular/cdk/stepper';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { OrderService } from '../../core/services/order.service';
import { firstValueFrom } from 'rxjs';

const stripeAppearance = {
  theme: 'night',
  variables: {
    colorPrimary: '#a21caf',        // violet-700 (Tailwind)
    colorBackground: '#18181b',     // neutral-900
    colorText: '#f3e8ff',           // violet-100
    colorDanger: '#f472b6',         // fuchsia-400
    colorSuccess: '#4ade80',        // green-400
    colorWarning: '#facc15',        // yellow-400
    borderRadius: '8px',
    fontFamily: 'Inter, Roboto, Arial, sans-serif',
    spacingUnit: '6px'
  },
  rules: {
    '.Input, .Block': {
      backgroundColor: '#18181b',   // neutral-900
      borderColor: '#a21caf',       // violet-700
      color: '#f3e8ff',             // violet-100
      boxShadow: 'none'
    },
    '.Input:focus, .Block:focus': {
      borderColor: '#f472b6',       // fuchsia-400
      boxShadow: '0 0 0 2px #a21caf'
    },
    '.Label': {
      color: '#c4b5fd',             // violet-300
      fontWeight: '500'
    },
    '.Tab, .Tab--selected': {
      color: '#a21caf'
    }
  }
};


@Component({
  selector: 'app-checkout',
  imports: [
    MatStepperModule,
    OrderSummaryComponent,
    OrderSummaryComponent,
    MatButton,
    RouterLink,
    CurrencyPipe,
    CheckoutReviewComponent,
    MatProgressSpinnerModule
  ],
  templateUrl: './checkout.component.html',
  styleUrl: './checkout.component.scss'
})
export class CheckoutComponent implements OnInit, OnDestroy {
  private stripeService = inject(StripeService);
  private snackbarService = inject(SnackbarService);
  private orderService = inject(OrderService);
  private router = inject(Router);
  private paymentElement?: StripePaymentElement;
  cartService = inject(CartService);
  addressElement?: StripeAddressElement;
  paymentStatus = signal<boolean>(false);
  loading = signal<boolean>(false);
  confirmationToken?: ConfirmationToken;


  async ngOnInit() {
    try {
      this.paymentElement = await this.stripeService.createPaymentElement();
      this.paymentElement.mount('#payment-element');
      this.paymentElement.on('change', this.handlePaymentCompletion);
    } catch (error: any) {
      this.snackbarService.error(error.message);
    }
  }

  handlePaymentCompletion = (event: StripePaymentElementChangeEvent) => {
    this.paymentStatus.update(() => event.complete);

  }

  async getConfirmationToken() {
    try {
      if (this.paymentStatus() == true) {
        const result = await this.stripeService.createConfirmationToken();
        if (result.error) throw new Error(result.error.message);
        this.confirmationToken = result.confirmationToken;
        console.log(result.confirmationToken);
      }
    } catch (error: any) {
      this.snackbarService.error(error.message);
    }
  }

  async onStepChange(event: StepperSelectionEvent) {
    if (event.selectedIndex === 1) {
      await this.getConfirmationToken();
    }
  }

  async confirmPayment(stepper: MatStepper) {
    this.loading.set(true);
    try {
      if (this.confirmationToken) {
        const result = await this.stripeService.confirmPayment(this.confirmationToken);

        if (result.paymentIntent?.status === 'succeeded') {
          const order = await this.createOrderModel();
          const orderResult = await firstValueFrom(this.orderService.createOrder(order));
          if (orderResult) {
            this.orderService.orderComplete.set(true);
            this.cartService.deleteCart();
            this.router.navigateByUrl('/checkout/success');
          } else {
            throw new Error('Order creation failed');
          }
        } else if (result.error) {
          throw new Error(result.error.message);
        } else {
          throw new Error('Something went wrong');
        }
      }
    } catch (error: any) {
      this.snackbarService.error(error.message);
      stepper.previous();
    } finally {
      this.loading.set(false);
    }
  }

  private async createOrderModel() {
    const cart = this.cartService.cart();
    const card = this.confirmationToken?.payment_method_preview.card;

    if (!cart?.id || !card) {
      throw new Error('Problem creating order');
    }

    return {
      cartId: cart.id,
      paymentSummary: {
        last4: +card.last4,
        brand: card.brand,
        expMonth: card.exp_month,
        expYear: card.exp_year
      },
      discount: this.cartService.totals()?.discount
    }
  }

  ngOnDestroy(): void {
    this.stripeService.disposeElements();
  }
}
