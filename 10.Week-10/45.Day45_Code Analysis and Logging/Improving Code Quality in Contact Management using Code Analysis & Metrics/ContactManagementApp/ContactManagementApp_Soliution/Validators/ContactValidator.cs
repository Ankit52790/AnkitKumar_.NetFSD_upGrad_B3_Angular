using System;
using System.Collections.Generic;
using System.Text;
using ContactManagementApp.Models;
using System.Text.RegularExpressions;
using System;


namespace ContactManagementApp.Validators
{
    public static class ContactValidator
    {
        // Minimum length for a valid phone number (e.g., 10 digits)
        private const int MinimumPhoneLength = 10;

        // Validates a Contact object and throws exceptions if validation fails
        public static void Validate(Contact contact)
        {
            // Check if the contact object is null
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            // Validate the Name property
            if (string.IsNullOrWhiteSpace(contact.Name))
                throw new ArgumentException("Name is required");

            // Validate the Email property
            if (string.IsNullOrWhiteSpace(contact.Email) ||
                !Regex.IsMatch(contact.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Valid email is required");

            // Validate the Phone property
            if (string.IsNullOrWhiteSpace(contact.Phone) ||
                contact.Phone.Length < MinimumPhoneLength)
                throw new ArgumentException("Valid phone number is required");
        }
    }
}
