// js/filter.js

import { state } from "./state.js";
import { renderProducts } from "./ui.js";

export function filterProducts(keyword) {

    state.filteredProducts = state.products.filter(product =>
        product.name.toLowerCase().includes(keyword.toLowerCase())
    );

    renderProducts(state.filteredProducts);
}
