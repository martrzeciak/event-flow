import { Address } from "./address";

export type Venue = {
    id: string;
    name: string;
    capacity: number;
    address: Address;
}