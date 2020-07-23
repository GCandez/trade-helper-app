import CityOverview from './city-overview';

export default interface CityDetails extends CityOverview {
    shopIds: number[];
}
