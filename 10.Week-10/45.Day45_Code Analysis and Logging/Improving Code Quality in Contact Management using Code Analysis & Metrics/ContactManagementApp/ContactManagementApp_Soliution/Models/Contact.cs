using ContactManagementApp.Interfaces;
using ContactManagementApp.Models;
using ContactManagementApp.Services;
using System;
using System.ComponentModel.DataAnnotations;

namespace ContactManagementApp.Models
{
    /// <summary>
    /// Represents a contact entity
    /// </summary>
    public class Contact
    {
        [Required(ErrorMessage ="Id Required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
    }
}
