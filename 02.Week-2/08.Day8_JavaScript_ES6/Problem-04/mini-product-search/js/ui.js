

export function renderProducts(products) {
    const productContainer = document.getElementById("productContainer");

    productContainer.innerHTML = "";

    if (products.length === 0) {
        productContainer.innerHTML =
            `<div class="no-result">No Results Found</div>`;
        return;
    }

    products.forEach(product => {
        const div = document.createElement("div");
        div.classList.add("product");
        div.dataset.id = product.id;
        div.textContent = product.name;

        productContainer.appendChild(div);
    });
}
