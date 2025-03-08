import { Component, Input } from '@angular/core';
import {MatCardModule} from '@angular/material/card';
import {MatChipsModule} from '@angular/material/chips';
import { EventModel } from '../../../shared/models/eventModel';

@Component({
  selector: 'app-event-item',
  imports: [MatCardModule, MatChipsModule],
  templateUrl: './event-item.component.html',
  styleUrl: './event-item.component.scss'
})
export class EventItemComponent {
  @Input() event?: EventModel;
}
