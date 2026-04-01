using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("feedback")]
    public class FeedbackController : Controller
    {
        // GET: feedback/form
        [HttpGet("form")]
        public IActionResult Form()
        {
            return View();
        }

        // POST: feedback/form
        [HttpPost("form")]
        public IActionResult Form(string name, string comments, int rating)
        {
            if (rating >= 4)
            {
                ViewData["Message"] = "Thank You for your positive feedback!";
            }
            else
            {
                ViewData["Message"] = "We will improve based on your feedback.";
            }

            ViewData["Name"] = name; // optional (for personalization)

            return View(); // same page
        }
    }
}
