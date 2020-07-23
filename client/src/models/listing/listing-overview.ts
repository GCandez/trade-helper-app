export default interface ListingOverview {
    id: number;
    shopId: number;
    itemId: number;

    currentPrice: number;
    currentStock: number;
    lastUpdate: Date;
}
