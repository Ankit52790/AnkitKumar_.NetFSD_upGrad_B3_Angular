using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> products = new List<Product>
        {
            new Product { ProductId = 1, ProductName = "Laptop", Category="Electronics", Price = 50000, Stock=10 },
            new Product { ProductId = 2, ProductName = "Mobile", Category="Electronics", Price = 20000, Stock=20 }
        };

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var obj = products.FirstOrDefault(x => x.ProductId == id);
            return View(obj);
        }

        // CREATE

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                products.Add(obj);
                return RedirectToAction("Index");
            }

            return View(obj); //
        }

        // EDIT
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var obj = products.FirstOrDefault(x => x.ProductId == id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Product p)
        {
            var exist = products.FirstOrDefault(x => x.ProductId == p.ProductId);

            exist.ProductName = p.ProductName;
            exist.Category = p.Category;
            exist.Price = p.Price;
            exist.Stock = p.Stock;

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
            products.Remove(obj);

            return RedirectToAction("Index");
        }
    }
}
