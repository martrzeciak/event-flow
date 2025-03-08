import { EventOrganizer } from "./eventOrganizer";
import { Venue } from "./venue";

export type EventModel = {
    id: string;
    name: string;
    date: Date;
    description: string;
}