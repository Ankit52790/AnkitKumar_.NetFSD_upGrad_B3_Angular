using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations;

namespace ContactManagement.DAL.Models
{
    public class ContactInfo
    {
        [Key]
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public long MobileNo { get; set; }
        public string Designation { get; set; }

        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }

        public Company Company { get; set; }
        public Department Department { get; set; }
    }
}
