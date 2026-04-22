using System;
using ContactManagementApp.Interfaces;
using ContactManagementApp.Models;
using ContactManagementApp.Repositories;
using ContactManagementApp.Services;

namespace ContactManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Manual Dependency Injection
            IContactRepository repository = new ContactRepository();
            IContactService service = new ContactService(repository);

            try
            {
                AddContact(service);
                DisplayContacts(service);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // method to add a contact 
        private static void AddContact(IContactService service)
        {
            service.AddContact(new Contact
            {
                Name = "Ankit",
                Email = "ankit@gmail.com",
                Phone = "9999999999"
            });

            Console.WriteLine("Contact added successfully!");
        }

        // method to display all contacts
        private static void DisplayContacts(IContactService service)
        {
            var contacts = service.GetAllContacts();

            Console.WriteLine("\nAll Contacts:");

            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.Id} - {contact.Name} - {contact.Email}");
            }
        }
    }
}
