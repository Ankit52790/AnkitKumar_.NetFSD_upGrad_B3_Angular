using ContactManagement.API.Models;

namespace ContactManagement.API.DataAccess
{
    public interface IContactRepository
    {
        IEnumerable<ContactInfo> GetAll();
        ContactInfo GetById(int id);
        ContactInfo Add(ContactInfo contact);
        bool Update(int id, ContactInfo contact);
        bool Delete(int id);
    }
}
