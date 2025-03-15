import { EventOrganizer } from "./eventOrganizer";
import { Venue } from "./venue";

export type EventModel = {
    id: string;
    name: string;
    date: Date;
    categories: string[];
    description: string;
    venue: Venue;
    organizers: EventOrganizer[];
}