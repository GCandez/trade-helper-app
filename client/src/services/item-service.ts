import RequestOptions from './request-options';
import { STORAGE } from '../config';
import { Item } from '../models';
import { getDataFromStorage } from '../utils';

export function getAll({page, pageSize}: RequestOptions) {
    const items = getDataFromStorage<Item[]>(STORAGE.ITEMS, []);

}
