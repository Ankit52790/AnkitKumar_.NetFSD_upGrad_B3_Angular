using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        //In-memory list to store contact in formation
        public static List<ContactInfo> contacts = new List<ContactInfo>();

        // Show all contact information
        public IActionResult ShowContacts()
        {
            return View(contacts);
        }
        
        //Get contact information by id
        public IActionResult GetContactById(int id)
        {
            // LINQ used to find the contact with the specified id
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);

            if(contact == null)
            {
                ViewBag.Message = "Contact not found.";
                return View();
            }
            return View(contact);
        }
        // Get: Add new contact information

        public  IActionResult AddContact()
        {
            return View();
        }
        // Post: Add new contact information
        [HttpPost]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                contacts.Add(contactInfo);
                return RedirectToAction("ShowContacts");
            }
            return View(contactInfo);
        }
    }
}
