using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ContactInfo
    {
        [Required(ErrorMessage = "Contact ID is required")]
        public int ContactId { get; set;}

        [Required(ErrorMessage = "Company Name is required")]
        public string FirstName { get;set; }

        public string LastName { get; set; }
        public string CompanyName { get; set; }

        [Required (ErrorMessage = "Email Id is required!")]
        public string EmailId { get; set; }
        public long MobileNo { get; set; }
        public string Designation { get; set; }

    }
}
