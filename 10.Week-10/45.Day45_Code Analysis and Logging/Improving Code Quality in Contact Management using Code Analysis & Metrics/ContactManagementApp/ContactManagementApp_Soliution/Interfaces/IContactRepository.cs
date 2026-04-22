using System;
using System.Collections.Generic;
using System.Text;
using ContactManagementApp.Models;

namespace ContactManagementApp.Interfaces
{
    public interface IContactRepository
    {
        void Add(Contact contact);
        void Update(Contact contact);
        void Delete(Contact contact);
        Contact GetById(int id);
        IReadOnlyList<Contact> GetAll();
    }
}
