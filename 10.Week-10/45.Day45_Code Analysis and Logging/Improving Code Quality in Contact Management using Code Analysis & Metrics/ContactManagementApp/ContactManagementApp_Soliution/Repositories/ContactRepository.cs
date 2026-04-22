using System;
using System.Collections.Generic;
using System.Linq;
using ContactManagementApp.Interfaces;
using ContactManagementApp.Models;

namespace ContactManagementApp.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly List<Contact> _contacts = new();

        // In-memory storage (can be replaced with DB later)

        public void Add(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            _contacts.Add(contact);
        }

        public void Update(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            var existing = GetById(contact.Id);

            // Only data update (no business logic)
            existing.Name = contact.Name;
            existing.Email = contact.Email;
            existing.Phone = contact.Phone;
        }

        public void Delete(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            _contacts.Remove(contact);
        }

        public Contact GetById(int id)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id);

            if (contact == null)
                throw new KeyNotFoundException($"Contact with Id {id} not found");

            return contact;
        }

        public IReadOnlyList<Contact> GetAll()
        {
            return _contacts.AsReadOnly();
        }
    }
}