import 'core-js/stable';
import 'regenerator-runtime/runtime';
import 'mobx-react-lite/batchingForReactDom';

import React, { useState, useEffect } from 'react';
import { render } from 'react-dom';
import { observer } from 'mobx-react';
import { ItemOverview, ItemDetails } from '~/models/item';
import { ItemService } from '~/services';
import ItemsStore from './stores/items-store';

const store = new ItemsStore();
void store.getAll();

const App = observer(() => {
    const [name, setName] = useState('');
    const { items } = store;

    const itemList = items.map(item =>
        <Item key={item.id} item={item} />,
    );

    const handleNameChange = (e: React.ChangeEvent<HTMLInputElement>) => setName(e.target.value);
    const createItem = () => store.createItem({ name });

    return (
        <div>
            <div>
                <input type="text" value={name} onChange={handleNameChange}/>
                <button onClick={createItem}>
                    CREATE
                </button>
            </div>
            <h1>
                ITEMS
            </h1>
            <ul>
                {itemList}
            </ul>
        </div>
    );
});

interface ItemProps {
    item: ItemDetails;
}

const Item = ({item}: ItemProps) => {
    const deleteSelf = () => store.deleteItem(item.id);

    return (
        <li>
            <b>
                {item.name}
            </b>
            (
            {item.id}
            )

            <button onClick={deleteSelf}>
                DELETE
            </button>
        </li>
    );
};

const mountingNode = document.getElementById('root');
render(<App />, mountingNode);
