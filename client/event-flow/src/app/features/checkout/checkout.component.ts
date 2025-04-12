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
        if (result.error) {
          throw new Error(result.error.message);
        } else {
          this.cartService.deleteCart();
          this.router.navigateByUrl('/checkout/success');
        }
      }
    } catch (error: any) {
      this.snackbarService.error(error.message);
      stepper.previous();
    } finally {
      this.loading.set(false);
    }
  }

  ngOnDestroy(): void {
    this.stripeService.disposeElements();
  }
}
