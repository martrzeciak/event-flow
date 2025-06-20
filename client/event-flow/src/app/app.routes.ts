import { Routes } from '@angular/router';
import { LoginComponent } from './features/account/login/login.component';
import { RegisterComponent } from './features/account/register/register.component';
import { EventComponent } from './features/event/event.component';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';
import { ServerErrorComponent } from './shared/components/server-error/server-error.component';
import { EventDetailsComponent } from './features/event/event-details/event-details.component';
import { TestErrorComponent } from './shared/components/test-error/test-error.component';
import { CartComponent } from './features/cart/cart.component';
import { CheckoutComponent } from './features/checkout/checkout.component';
import { CheckoutSuccessComponent } from './features/checkout/checkout-success/checkout-success.component';
import { OrderComponent } from './features/order/order.component';
import { OrderDetailedComponent } from './features/order/order-detailed/order-detailed.component';
import { HomeComponent } from './home/home.component';
import { UserInfoComponent } from './features/account/user-info/user-info.component';

export const routes: Routes = [
    {path: '', component: HomeComponent},
    {path: 'events', component: EventComponent},
    {path: 'event/:id', component: EventDetailsComponent},
    {path: 'cart', component: CartComponent},
    {path: 'checkout', component: CheckoutComponent},
    {path: 'checkout/success', component: CheckoutSuccessComponent},
    {path: 'orders', component: OrderComponent},
    {path: 'orders/:id', component: OrderDetailedComponent},
    {path: 'account/login', component: LoginComponent},
    {path: 'account/register', component: RegisterComponent},
    {path: 'account/info', component: UserInfoComponent},
    {path: 'test-error', component: TestErrorComponent},
    {path: 'not-found', component: NotFoundComponent},
    {path: 'server-error', component: ServerErrorComponent},
    {path: '**', redirectTo: 'not-found', pathMatch: 'full'},
];
