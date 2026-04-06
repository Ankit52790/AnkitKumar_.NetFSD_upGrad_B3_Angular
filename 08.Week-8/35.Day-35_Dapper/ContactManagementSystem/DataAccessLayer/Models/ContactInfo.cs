using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class ContactInfo
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public long MobileNo { get; set; }
        public string Designation { get; set; }

        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }

        // JOIN display
        public string CompanyName { get; set; }
        public string DepartmentName { get; set; }
    }
}
