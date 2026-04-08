using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContactManagement.API.Models;

namespace ContactManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private static List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo
            {
                ContactId = 1,
                FirstName = "Ankit",
                LastName = "Kumar",
                EmailId = "ankit@gmail.com",
                MobileNo = 9999999999,
                Designation = "Developer",
                CompanyId = 1,
                DepartmentId = 1
            }
        };

        // GET ALL
        [HttpGet]
        public IActionResult GetContacts()
        {
            return Ok(contacts);
        }

        // GET BY ID
        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = contacts.Find(c => c.ContactId == id);

            if (contact == null)
            {
                return NotFound("Contact not found");
            }
            else
            {
                return Ok(contact);
            }
        }

        // CREATE
        [HttpPost]
        public IActionResult AddContact(ContactInfo contact)
        {
            // Auto-generate ID
            contact.ContactId = contacts.Max(c => c.ContactId) + 1;

            contacts.Add(contact);

            return Ok(new
            {
                contact,
                status = "New contact added successfully!"
            });
        }

        // UPDATE
        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, ContactInfo contact)
        {
            var existing = contacts.Find(c => c.ContactId == id);

            if (existing == null)
            {
                return NotFound("Contact not found");
            }
            else
            {
                existing.FirstName = contact.FirstName;
                existing.LastName = contact.LastName;
                existing.EmailId = contact.EmailId;
                existing.MobileNo = contact.MobileNo;
                existing.Designation = contact.Designation;
                existing.CompanyId = contact.CompanyId;
                existing.DepartmentId = contact.DepartmentId;

                return Ok(new
                {
                    updatedContact = existing,
                    status = "Contact updated successfully!"
                });
            }
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var contact = contacts.Find(c => c.ContactId == id);

            if (contact == null)
            {
                return NotFound("Contact not found");
            }
            else
            {
                contacts.Remove(contact);

                return Ok(new
                {
                    contact,
                    status = "Contact deleted successfully!"
                });
            }
        }
    }
}
