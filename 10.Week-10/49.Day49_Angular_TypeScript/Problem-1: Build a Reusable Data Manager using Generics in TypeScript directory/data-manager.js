"use strict";
// Generic Function
function getFirstElement(items) {
    return items[0];
}
// Generic Class
class DataManager {
    items = [];
    add(item) {
        this.items.push(item);
    }
    getAll() {
        return this.items;
    }
}
// User Manager
const userManager = new DataManager();
userManager.add({ id: 1, name: "Ankit" });
userManager.add({ id: 2, name: "Rahul" });
// Product Manager
const productManager = new DataManager();
productManager.add({ id: 101, title: "Laptop" });
productManager.add({ id: 102, title: "Mobile" });
// Display
console.log("Users:", userManager.getAll());
console.log("Products:", productManager.getAll());
// Generic Function Usage
console.log("First User:", getFirstElement(userManager.getAll()));
console.log("First Product:", getFirstElement(productManager.getAll()));
