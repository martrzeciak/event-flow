import { Component } from '@angular/core';
import { MatIcon } from '@angular/material/icon'
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { MatButton } from '@angular/material/button';


@Component({
  selector: 'app-header',
  imports: [MatIcon, RouterLink, RouterLinkActive, MatButton],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {

}
