import { Component, inject, signal } from '@angular/core';
import { User } from '../../../shared/models/user';
import { AccountService } from '../../../core/services/account.service';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-user-info',
  imports: [
    NgIf
  ],
  templateUrl: './user-info.component.html',
  styleUrl: './user-info.component.scss'
})
export class UserInfoComponent {
  user = signal<User | null>(null);
  private accountService = inject(AccountService);

  ngOnInit(): void {
    if (!this.accountService.currentUser()) {
      this.accountService.getUserInfo().subscribe({
        next: user => this.user.set(user)
      });
    } else {
      this.user.set(this.accountService.currentUser());
    }
  }
}
