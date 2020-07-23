import ShopOverview from './shop-overview';

export default interface ShopDetails extends ShopOverview {
    cityId: number;
    listingIds: number[];
}
