using ContactManagement.API.Models;

namespace ContactManagement.API.DataAccess
{
    public class ContactRepository : IContactRepository
    {
        public static List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo
            {
                ContactId = 1,
                FirstName = "Ankit",
                LastName = "Kumar",
                EmailId = "ankit@gmail.com",
                MobileNo = 9999999999,
                Designation = "Developer",
                CompanyId = 1,
                DepartmentId = 1
            }
        };

        public IEnumerable<ContactInfo> GetAll()
        {
            return contacts;
        }

        public ContactInfo GetById(int id)
        {
            return contacts.FirstOrDefault(c => c.ContactId == id);
        }

        public ContactInfo Add(ContactInfo contact)
        {
            contact.ContactId = contacts.Max(c => c.ContactId) + 1;
            contacts.Add(contact);
            return contact;
        }

        public bool Update(int id, ContactInfo contact)
        {
            var existing = contacts.FirstOrDefault(c => c.ContactId == id);

            if (existing == null)
                return false;

            existing.FirstName = contact.FirstName;
            existing.LastName = contact.LastName;
            existing.EmailId = contact.EmailId;
            existing.MobileNo = contact.MobileNo;
            existing.Designation = contact.Designation;
            existing.CompanyId = contact.CompanyId;
            existing.DepartmentId = contact.DepartmentId;

            return true;
        }

        public bool Delete(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);

            if (contact == null)
                return false;

            contacts.Remove(contact);
            return true;
        }
    }
}
