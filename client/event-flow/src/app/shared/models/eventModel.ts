import { EventOrganizer } from "./eventOrganizer";
import { Ticket } from "./ticket";
import { Venue } from "./venue";

export type EventModel = {
    id: string;
    name: string;
    date: Date;
    tickets: Ticket[];
    categories: string[];
    description: string;
    venue: Venue;
    organizers: EventOrganizer[];
}