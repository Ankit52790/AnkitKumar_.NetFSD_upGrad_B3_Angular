using ContactManagement.DAL.DbContext;
using ContactManagement.DAL.Exceptions;
using ContactManagement.DAL.Exceptions.ContactManagement.DAL.Exceptions;
using ContactManagement.DAL.Models;
using Microsoft.EntityFrameworkCore;
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
        // Get all contacts
        public async Task<IEnumerable<ContactInfo>> GetAllAsync()
        {
            return await _context.Contacts
                .Include(c => c.Company)
                .Include(c => c.Department)
                .ToListAsync();
        }

        // Get a contact by Id
        public async Task<ContactInfo> GetByIdAsync(int id)
        {
            var contact = await _context.Contacts
                .Include(c => c.Company)
                .Include(c => c.Department)
                .FirstOrDefaultAsync(c => c.ContactId == id);

            if (contact == null)
                throw new NotFoundException($"Contact with ID {id} not found");

            return contact;
        }

        // Add a new contact
        public async Task AddAsync(ContactInfo contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        // Update an existing contact
        public async Task UpdateAsync(ContactInfo contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
        }

        // Delete a contact by ID
        public async Task DeleteAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
                throw new NotFoundException($"Contact with ID {id} not found");

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }
    }
}
