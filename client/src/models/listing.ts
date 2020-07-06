export default interface Listing {
    id: string;
    itemId: string;
    shopId: string;
    history: Array<{price: number; stock: number; date: Date}>;
}
