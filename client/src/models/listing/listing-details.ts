import ListingOverview from './listing-overview';
import ListingHistoryDetail from './listing-history-detail';

export default interface ListingDetails extends ListingOverview {
    history: ListingHistoryDetail[];
}
