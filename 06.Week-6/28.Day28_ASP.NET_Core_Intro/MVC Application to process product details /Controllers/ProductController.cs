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

    }
}
