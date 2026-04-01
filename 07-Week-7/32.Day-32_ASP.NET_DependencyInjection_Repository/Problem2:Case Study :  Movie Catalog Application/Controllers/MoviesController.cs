using Microsoft.AspNetCore.Mvc;
using MovieCatalogApp.Data;
using MovieCatalogApp.Models;

namespace MovieCatalogApp.Controllers
{
    public class MoviesController : Controller
    {
        // Dependency Injection of the ApplicationDbContext
        private readonly ApplicationDbContext _context;

        // Constructor for MoviesController that takes ApplicationDbContext as a paramete
        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // READ
        public IActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        // CREATE (GET)
        public IActionResult Create()
        {
            return View();
        }

        // CREATE (POST)
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                // If the model state is valid, add the movie to the database and save changes
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Please fill in all required fields correctly.";
                return View(movie);
            }
           
            
        }

        // EDIT (GET)
        public IActionResult Edit(int id)
        {
            // Find the movie by its ID and pass it to the view for editing
            var movie = _context.Movies.Find(id);
            return View(movie);
        }

        // EDIT (POST)
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var movie = _context.Movies.Find(id);
            return View(movie);
        }
    }
}
