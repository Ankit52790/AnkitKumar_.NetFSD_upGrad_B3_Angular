using Microsoft.EntityFrameworkCore;
using ContactManagement.DAL.DbContext;
using ContactManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManagement.DAL.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContactInfo>> GetAllAsync()
        {
            return await _context.Contacts
                .Include(c => c.Company)
                .Include(c => c.Department)
                .ToListAsync();
        }

        public async Task<ContactInfo> GetByIdAsync(int id)
        {
            return await _context.Contacts
                .Include(c => c.Company)
                .Include(c => c.Department)
                .FirstOrDefaultAsync(c => c.ContactId == id);
        }

        public async Task AddAsync(ContactInfo contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ContactInfo contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }
    }
}
