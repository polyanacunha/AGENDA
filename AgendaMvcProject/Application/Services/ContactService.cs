using AgendaMvcProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using AgendaMvcProject.Data.Context;
using AgendaMvcProject.Application.Interfaces;
using AgendaMvcProject.Application.DTOs;
using AutoMapper;

namespace AgendaMvcProject.Application.Services
{
    public class ContactService : IContactService
    {
        private readonly ApplicationContext _context;
         private readonly IMapper _mapper;

        public ContactService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            var contactsEntity = await _context.Contacts.ToListAsync();
            return _mapper.Map<IEnumerable<ContactDTO>>(contactsEntity);

        }

        public async Task<Contact> GetById(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task<Contact> Add(ContactDTO contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return contact;
        }

        public async Task<Contact> Update(ContactDTO contact)
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

        public async Task Delete(int id)
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
