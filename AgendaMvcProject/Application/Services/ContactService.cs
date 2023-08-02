using Application.interfaces;
using Application.Models;
using backend.Models;
using Microsoft.EntityFrameworkCore;


namespace Application.Services
{
    public class ContactService : IContactService
    {
        private readonly ApplicationContext _context;

        public ContactService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task<Contact> AddContactAsync(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return contact;
        }

        public async Task<Contact> UpdateContactAsync(Contact contact)
        {
            _context.Entry(contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(contact.Id))
                {
                    throw new ArgumentException($"Contact with id {contact.Id} not found.");
                }

                throw;
            }

            return contact;
        }

        public async Task DeleteContactAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                throw new ArgumentException($"Contact with id {id} not found.");
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }

        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }

    }
}
