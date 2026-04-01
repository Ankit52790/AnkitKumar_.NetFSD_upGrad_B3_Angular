using WebApplication2.Models;
using WebApplication2.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        // Constructor Injection
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // Show All Contacts
        public IActionResult ShowContacts()
        {
            var contacts = _contactService.GetAllContacts();
            return View(contacts);
        }

        // Get Contact By Id
        public IActionResult GetContactById(int id)
        {
            var contact = _contactService.GetContactById(id);
            return View(contact);
        }

        // Add Contact (GET) 
        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        //  Add Contact (POST)
        [HttpPost]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                _contactService.AddContact(contactInfo);
                return RedirectToAction("ShowContacts");
            }

            ViewBag.ErrorMessage = "Invalid contact information. Please try again.";
            return View(contactInfo);
        }
    }
}
