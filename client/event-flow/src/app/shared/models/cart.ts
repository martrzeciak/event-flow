import { nanoid } from 'nanoid';

export type CartType = {
    id: string;
    items: CartItem[];
    paymentIntentId?: string;
    clientSecret?: string;
}

export type CartItem = {
    ticketId: string;
    eventName: string;
    eventId: string;
    ticketType: string;
    price: number;
    quantity: number;
}

export class Cart implements CartType {
    id = nanoid();
    items: CartItem[] = [];
    paymentIntentId?: string;
    clientSecret?: string;
}