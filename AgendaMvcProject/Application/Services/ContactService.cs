using AgendaMvcProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using AgendaMvcProject.Data.Context;
using AgendaMvcProject.Application.Interfaces;
using AgendaMvcProject.Application.DTOs;
using AutoMapper;
using AgendaMvcProject.Domain.Interfaces;

namespace AgendaMvcProject.Application.Services
{
    public class ContactService : IContactService
    {
        private IContactRepository _contactRepository;
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository, ApplicationContext context, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            var contactsEntity = await _contactRepository.GetContacts();
            return contactsEntity;
            // return _mapper.Map<IEnumerable<ContactDTO>>(contactsEntity);

        }

        public async Task<Contact> GetById(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task<Contact> Add(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return contact;
        }

        public async Task<Contact> Update(Contact contact)
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
