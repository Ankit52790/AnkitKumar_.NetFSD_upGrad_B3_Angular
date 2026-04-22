using ContactManagementApp.Interfaces;
using ContactManagementApp.Models;
using ContactManagementApp.Validators;
using System.Collections.Generic;

namespace ContactManagementApp.Services
{
    // <summary>
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;
        // Simple in-memory ID generator for demonstration purposes
        private int _currentId = 0;

        // Constructor with Dependency Injection
        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        // Adds a new contact after validating it
        public void AddContact(Contact contact)
        {
            ContactValidator.Validate(contact);

            contact.Id = GenerateId();
            _repository.Add(contact);
        }

        // Updates an existing contact after validating it
        public void UpdateContact(Contact contact)
        {
            ContactValidator.Validate(contact);

            _repository.Update(contact);
        }

        // Deletes a contact by its ID
        public void DeleteContact(int id)
        {
            var contact = _repository.GetById(id);
            _repository.Delete(contact);
        }

        // Retrieves all contacts
        public IReadOnlyList<Contact> GetAllContacts()
        {
            return _repository.GetAll();
        }

        // Retrieves a contact by its ID
        private int GenerateId()
        {
            return ++_currentId;
        }
    }
}