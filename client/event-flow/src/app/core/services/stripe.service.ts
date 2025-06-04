import { inject, Injectable } from '@angular/core';
import { Appearance, ConfirmationToken, loadStripe, Stripe, StripeAddressElement, StripeAddressElementOptions, StripeElements, StripePaymentElement, StripePaymentElementOptions } from '@stripe/stripe-js';
import { HttpClient } from '@angular/common/http';
import { CartService } from './cart.service';
import { Cart } from '../../shared/models/cart';
import { firstValueFrom, map } from 'rxjs';
import { environment } from '../../../environments/environment.development';

const stripeAppearance: Appearance = {
  theme: 'night',
  variables: {
    colorPrimary: '#a21caf',
    colorBackground: '#18181b',
    colorText: '#f3e8ff',
    colorDanger: '#f472b6',
    colorSuccess: '#4ade80',
    colorWarning: '#facc15',
    borderRadius: '8px',
    fontFamily: 'Inter, Roboto, Arial, sans-serif',
    spacingUnit: '6px'
  },
  rules: {
    '.Input, .Block': {
      backgroundColor: '#18181b',
      borderColor: '#a21caf',
      color: '#f3e8ff',
      boxShadow: 'none'
    },
    '.Input:focus, .Block:focus': {
      borderColor: '#f472b6',
      boxShadow: '0 0 0 2px #a21caf'
    },
    '.Label': {
      color: '#c4b5fd',
      fontWeight: '500'
    },
    '.Tab, .Tab--selected': {
      color: '#a21caf'
    }
  }
};


@Injectable({
  providedIn: 'root'
})
export class StripeService {
  baseUrl = environment.apiUrl;
  private cartService = inject(CartService);
  private http = inject(HttpClient);
  private stripePromise?: Promise<Stripe | null>;
  private elements?: StripeElements;
  private paymentElement?: StripePaymentElement;
  private addressElement?: StripeAddressElement;
  
  constructor() { 
    this.stripePromise = loadStripe(environment.stripePublicKey);
  }

  getStripeInstance() {
    return this.stripePromise;
  }

  async initializeElements() {
    if (!this.elements) {
      const stripe = await this.getStripeInstance();
      if (stripe) {
        const cart = await firstValueFrom(this.createOrUpdatePaymentIntent());
        this.elements = stripe.elements(
          {clientSecret: cart.clientSecret, appearance: stripeAppearance, locale: 'en'});
      } else {
        throw new Error('Stripe has not been loaded');
      }
    }

    return this.elements;
  }

  async createAddressElement() {
    if (!this.addressElement) {
      const elements = await this.initializeElements();
      if (elements) {
        const options: StripeAddressElementOptions = {
          mode: 'billing',
        };
        this.addressElement = elements.create('address', options);
      } else {
        throw new Error('Elements instance has not been loaded');
      }
    } 

    return this.addressElement;
  }

  async createPaymentElement() {
    if (!this.paymentElement) {
      const elements = await this.initializeElements();
      if (elements) {
        const options: StripePaymentElementOptions = {
          fields: {
            billingDetails: 'auto'
          },
        };
        this.paymentElement = elements.create('payment');
      } else {
        throw new Error('Elements instance has not been loaded');
      }
    }

    return this.paymentElement;
  }

  createOrUpdatePaymentIntent() {
    const cart = this.cartService.cart();
    const hasClientSecret = !!cart?.clientSecret;
    if (!cart) throw new Error('Problem with cart');
    return this.http.post<Cart>(this.baseUrl + 'payments/' + cart.id, {}).pipe(
      map(async cart => {
        if (!hasClientSecret) {
          await firstValueFrom(this.cartService.setCart(cart));
          return cart;
        }
        return cart;
      })
    )
  }

  async createConfirmationToken() {
    const stripe = await this.getStripeInstance();
    const elements = await this.initializeElements();
    const result = await elements.submit();
    if (result.error) throw new Error(result.error.message);
    if (stripe) {
      return await stripe.createConfirmationToken({elements});
    } else {
      throw new Error('Stripe not available');
    }
  }

  async confirmPayment(confirmationToken: ConfirmationToken) {
    const stripe = await this.getStripeInstance();
    const elements = await this.initializeElements();
    const result = await elements.submit();
    if (result.error) throw new Error(result.error.message);

    const clientSecret = this.cartService.cart()?.clientSecret;

    if (stripe && clientSecret) {
      return await stripe.confirmPayment({
        clientSecret: clientSecret,
        confirmParams: {
          confirmation_token: confirmationToken.id
        },
        redirect: 'if_required'
      })
    } else {
      throw new Error('Unable to load stripe');
    }
  }

  disposeElements() {
    this.elements = undefined;
    this.paymentElement = undefined;
  }
}
