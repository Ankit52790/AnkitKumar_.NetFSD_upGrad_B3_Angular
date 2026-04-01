using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("student")]
    public class StudentController : Controller
    {
        // GET: student/register
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        // POST: student/register
        [HttpPost("register")]
        public IActionResult Register(string name, int age, string course)
        {
            TempData["Name"] = name;
            TempData["Age"] = age;
            TempData["Course"] = course;


            return RedirectToAction("Display");
        }

        // GET: student/display
        [HttpGet("display")]
        public IActionResult Display()
        {
            ViewBag.Name = TempData["Name"];
            ViewBag.Age = TempData["Age"];
            ViewBag.Course = TempData["Course"];

            return View();
        }
    }
}
