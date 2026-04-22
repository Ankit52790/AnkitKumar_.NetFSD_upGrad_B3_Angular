using System.Collections.Generic;
using ContactManagementApp.Models;

namespace ContactManagementApp.Interfaces
{
    public interface IContactService
    {
        /// <summary>
        /// Adds a new contact
        /// </summary>
        void AddContact(Contact contact);

        /// <summary>
        /// Updates an existing contact
        /// </summary>
        void UpdateContact(Contact contact);

        /// <summary>
        /// Deletes a contact by Id
        /// </summary>
        void DeleteContact(int id);

        /// <summary>
        /// Retrieves all contacts
        /// </summary>
        IReadOnlyList<Contact> GetAllContacts();
    }
}