using ContactManagement.DAL.Models;
using ContactManagement.DAL.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _repo;
        private readonly ILogger<ContactsController> _logger;

        // Constructor injection of repository and logger
        public ContactsController(IContactRepository repo, ILogger<ContactsController> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        // GET: api/contacts
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAllAsync());
        }

        // GET: api/contacts/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _repo.GetByIdAsync(id);

            return Ok(contact);
        }

        // POST: api/contacts
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(ContactInfo contact)
        {
            _logger.LogInformation("Creating contact: {FirstName}", contact.FirstName);

            await _repo.AddAsync(contact);

            _logger.LogInformation("Contact created successfully");

            return Ok(contact);
        }


        // PUT: api/contacts/{id}

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, ContactInfo contact)
        {
            contact.ContactId = id;
            await _repo.UpdateAsync(contact);
            return Ok(contact);
        }

        // DELETE: api/contacts/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning("Deleting contact with ID: {Id}", id);

            await _repo.DeleteAsync(id);

            _logger.LogInformation("Contact deleted successfully");

            return Ok();
        }
    }
}
