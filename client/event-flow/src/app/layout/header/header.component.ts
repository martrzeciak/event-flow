import { Component, inject } from '@angular/core';
import { MatIcon } from '@angular/material/icon'
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { MatButton } from '@angular/material/button';
import { AccountService } from '../../core/services/account.service';
import { MatMenu, MatMenuItem, MatMenuTrigger } from '@angular/material/menu';
import { MatDivider } from '@angular/material/divider';
import { CartService } from '../../core/services/cart.service';
import { MatBadge } from '@angular/material/badge';


@Component({
  selector: 'app-header',
  imports: [
    MatIcon,
    MatButton,
    RouterLink,
    RouterLinkActive,
    MatMenuTrigger,
    MatMenu,
    MatDivider,
    MatMenuItem,
    MatBadge
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {
  accountService = inject(AccountService);
  cartService = inject(CartService);
  private router = inject(Router);

  logout() {
    this.accountService.logout().subscribe({
      next: () => {
        this.accountService.currentUser.set(null);
        this.router.navigateByUrl('/');
      }
    })
  }
}
