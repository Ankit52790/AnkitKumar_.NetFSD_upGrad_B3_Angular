// Generic Function
function getFirstElement<T>(items: T[]): T {
  return items[0];
}

// Generic Interface
interface Repository<T> {
  add(item: T): void;
  getAll(): T[];
}

// Generic Class
class DataManager<T> implements Repository<T> {
  private items: T[] = [];

  add(item: T): void {
    this.items.push(item);
  }

  getAll(): T[] {
    return this.items;
  }
}

//Create Models for user
interface User {
  id: number;
  name: string;
}

// Create Models for Product
interface Product {
  id: number;
  title: string;
}

// User Manager
const userManager = new DataManager<User>();
userManager.add({ id: 1, name: "Ankit" });
userManager.add({ id: 2, name: "Rahul" });

// Product Manager
const productManager = new DataManager<Product>();
productManager.add({ id: 101, title: "Laptop" });
productManager.add({ id: 102, title: "Mobile" });

// Display
console.log("Users:", userManager.getAll());
console.log("Products:", productManager.getAll());

// Generic Function Usage
console.log("First User:", getFirstElement(userManager.getAll()));
console.log("First Product:", getFirstElement(productManager.getAll()));
