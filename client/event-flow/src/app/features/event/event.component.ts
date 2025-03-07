import { Component } from '@angular/core';
import { EventItemComponent } from "./event-item/event-item.component";

@Component({
  selector: 'app-event',
  imports: [EventItemComponent],
  templateUrl: './event.component.html',
  styleUrl: './event.component.scss'
})
export class EventComponent {

}
