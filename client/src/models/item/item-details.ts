import ItemOverview from './item-overview';

export default interface ItemDetails extends ItemOverview {
    listingIds: number[];
}
