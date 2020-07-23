import { ItemOverview, ItemDetails, ItemCreation, ItemUpdate } from '../models/item';
import { API } from '~/config';

const ITEMS_API = API.url('/items');

export default abstract class ItemService {
    static async all(): Promise<ItemOverview[]> {
        const data = await ITEMS_API.get().json();

        return data as ItemOverview[];
    }

    static async find(id: number): Promise<ItemDetails | undefined> {
        const item = await ITEMS_API.url(`/${id}`).get().json();

        return item as ItemDetails;
    }

    static async create(item: ItemCreation): Promise<ItemDetails> {
        const createdItem = await ITEMS_API.post(item).json();

        return createdItem as ItemDetails;
    }

    static async update(id: number, item: ItemUpdate): Promise<void> {
        await ITEMS_API.url(`/${id}`).post(item);
    }

    static async delete(id: number): Promise<void> {
        await ITEMS_API.url(`/${id}`).delete();
    }
}

