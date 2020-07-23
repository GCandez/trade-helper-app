import { observable, action } from 'mobx';
import { ItemCreation, ItemDetails } from '~/models/item';
import { ItemService } from '~/services';

export default class ItemsStore {
    readonly items = observable<ItemDetails>([]);

    getAll = action(async () => {
        const items = await ItemService.all();

        const fetchPromises = items.map(item => this.fetchItem(item.id));

        await Promise.all(fetchPromises);
    });

    fetchItem = action(async (id: number) => {
        const item = await ItemService.find(id);

        if(!item) {
            return;
        }

        this.items.push(item);
    });

    createItem = action(async(item: ItemCreation) => {
        const createdItem = await ItemService.create(item);
        this.items.push(createdItem);
    });

    deleteItem = action(async(id: number) => {
        const item = this.items.find(i => i.id === id);

        if(!item) {
            return;
        }

        await ItemService.delete(id);
        this.items.remove(item);
    });
}
