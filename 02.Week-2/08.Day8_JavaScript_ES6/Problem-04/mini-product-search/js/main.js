// js/main.js

import { state } from "./state.js";
import { renderProducts } from "./ui.js";
import { filterProducts } from "./filter.js";

// DOM references
const searchInput = document.getElementById("searchInput");
const productContainer = document.getElementById("productContainer");

// Real-time filtering
searchInput.addEventListener("input", (e) => {
    const value = e.target.value.trim();
    filterProducts(value);
});

// Event Delegation
productContainer.addEventListener("click", (e) => {
    if (e.target.classList.contains("product")) {
        alert("You clicked: " + e.target.textContent);
    }
});

// Initialization
function init() {
    state.filteredProducts = state.products;
    renderProducts(state.products);
}

init();
