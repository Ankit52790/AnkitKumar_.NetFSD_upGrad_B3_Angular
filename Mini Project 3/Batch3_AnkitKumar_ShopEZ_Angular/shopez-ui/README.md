---
# 🛒 ShopEZ - Angular E-Commerce Frontend

A modern, scalable e-commerce frontend built with **Angular**, featuring authentication, product browsing, cart management, checkout flow, and a dedicated admin panel. This application integrates seamlessly with a RESTful backend API.

---

##  Project Overview

**ShopEZ UI** is a modern, scalable **Angular-based e-commerce frontend application** that provides a complete shopping experience including product browsing, cart management, authentication, checkout flow, and admin dashboard.

It integrates with a **RESTful ASP.NET Core backend API** using JWT authentication.

---

##  Features

###  User Features

* User Registration & Login
* JWT Authentication
* Product Listing & Search
* Product Details Page
* Add / Remove from Cart
* Checkout Flow
* Order History

###  Admin Features

* Admin Dashboard
* Product Management
* Order Management

### Technical Highlights

* Angular Standalone Components
* Service-based architecture
* RxJS reactive programming
* HTTP Interceptor (JWT handling)
* Route Guards (Auth & Admin)
* Modular and scalable structure

---

## 📁 Project Structure

```text
src/app
│── admin/             # Admin layout
│── components/        # UI components
│── pages/             # Page views
│── services/          # Business logic + API calls
│── guards/            # Route protection
│── interceptors/      # JWT handling
│── models/            # Interfaces
│── app.routes.ts      # Routing
│── app.config.ts      # App config
```

---

## System Architecture

```text id="arch1"
Component → Service → HTTP Client → Interceptor → Backend API → Database
```

---

## 🔁 Project Flow Diagram

###  Full System Flow

```text id="flow_main"
User
 │
 ▼
Angular App (ShopEZ UI)
 │
 ├── Home / Products / Cart / Checkout / Admin
 │
 ▼
Services Layer
 │
 ├── AuthService
 ├── ProductService
 ├── CartService
 ├── OrderService
 │
 ▼
HTTP Interceptor (JWT Attach)
 │
 ▼
ASP.NET Core API
 │
 ▼
SQL Server
```

---

## User Journey Flow

```text id="flow_user"
Login/Register → Browse Products → Search → View Product → Add to Cart → Checkout → Order Success → Order History
```

---

## Authentication Flow

```text id="flow_auth"
Login → AuthService → API → JWT Token → LocalStorage → Interceptor → Protected Routes (Guard)
```

---

## 🛒 Cart Flow

```text id="flow_cart"
Product → Add to Cart → CartService (RxJS) → Cart UI Update → Checkout → Order API
```

---

## 🔎 Search Flow

```text id="flow_search"
Navbar Input → Debounce → ProductService → API Call → Filter Results → Suggestions → Navigate Product
```

---

## Testing Strategy

### Unit Testing Flow

```text id="test_flow"
Component → Mock Service → Test Data → Expect Assertions
```

### Example Coverage:

* AuthService (Login, Role Check)
* CartService (Add/Remove items)
* Components (Navbar, Cart, Product List)

---

## API Integration

* Auth APIs → Login/Register
* Product APIs → CRUD operations
* Cart APIs → Cart handling
* Order APIs → Order processing

---

## Setup & Run

### Install dependencies

```bash
npm install
```

### Run application

```bash
ng serve
```

Open:

```
http://localhost:4200
```

---

## Testing

```bash
ng test
```

---

## Future Improvements

* Payment Gateway (Razorpay / Stripe)
* Wishlist feature
* Product reviews & ratings
* NgRx state management
* Lazy loading modules

---

## Author

**Ankit Kumar**
Full Stack Developer (Angular + .NET)

---

# What I improved for you

✔ Cleaner structure
✔ Reduced repetition
✔ Professional architecture section
✔ Clear testing strategy added
✔ Better readability for recruiters
✔ Interview-ready documentation

---
