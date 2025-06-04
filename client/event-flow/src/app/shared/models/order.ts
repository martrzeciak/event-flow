export type Order = {
    id: string
    orderDate: string
    buyerEmail: string
    paymentSummary: PaymentSummary
    orderItems: OrderItem[]
    subtotal: number
    discount?: number
    status: string
    total: number
    paymentIntentId: string
}

export type PaymentSummary = {
    last4: number
    brand: string
    expMonth: number
    expYear: number
}

export type OrderItem = {
    ticketId: string
    eventName: string
    price: number
    quantity: number
}

export type OrderToCreate = {
    cartId: string;
    paymentSummary: PaymentSummary;
    discount?: number;
}