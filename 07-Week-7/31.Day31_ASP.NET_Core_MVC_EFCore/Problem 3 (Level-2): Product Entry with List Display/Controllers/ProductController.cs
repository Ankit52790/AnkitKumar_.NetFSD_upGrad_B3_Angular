using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("productentry")]
    public class ProductController : Controller
    {
        // Existing CRUD List 
        public static List<Product> products = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Laptop", Category="Electronics", Price = 50000, Stock=10 },
            new Product { ProductId = 2, ProductName = "Mobile", Category="Electronics", Price = 20000, Stock=20 }
        };

        // Static list 
        private static List<dynamic> productList = new List<dynamic>();

        // EXISTING FEATURES

        [HttpGet("index")]
        public IActionResult Index()
        {
            return View(products);
        }

        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            var obj = products.FirstOrDefault(x => x.ProductId == id);
            return View(obj);
        }

        // CREATE
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                products.Add(obj);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid data. Some validations failed.";
                return View(obj);
            }
        }

        // EDIT
        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var obj = products.FirstOrDefault(x => x.ProductId == id);
            return View(obj);
        }

        [HttpPost("edit")]
        public IActionResult Edit(Product p)
        {
            var existProd = products.FirstOrDefault(x => x.ProductId == p.ProductId);

            if (existProd != null)
            {
                existProd.ProductName = p.ProductName;
                existProd.Category = p.Category;
                existProd.Price = p.Price;
                existProd.Stock = p.Stock;
            }

            return RedirectToAction("Index");
        }

        // DELETE
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var obj = products.FirstOrDefault(x => x.ProductId == id);
            return View(obj);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var obj = products.FirstOrDefault(x => x.ProductId == id);

            if (obj != null)
            {
                products.Remove(obj);
            }

            return RedirectToAction("Index");
        }

        //NEW FEATURE 

        // GET: productentry/entry
        [HttpGet("entry")]
        public IActionResult ProductEntry()
        {
            ViewBag.Products = productList;
            return View();
        }

        // POST: productentry/entry
        [HttpPost("entry")]
        public IActionResult ProductEntry(string name, double price, int quantity)
        {
            productList.Add(new
            {
                Name = name,
                Price = price,
                Quantity = quantity
            });

            ViewBag.Products = productList;

            return View();
        }
    }
}
