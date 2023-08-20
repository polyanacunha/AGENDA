using AgendaMvcProject.Domain.Models;
using AgendaMvcProject.Data.Context;
using Microsoft.EntityFrameworkCore;
using AgendaMvcProject.Domain.Interfaces;

namespace AgendaMvcProject.Data.Repositories;

public class ContactRepository : IContactRepository
{
    private ApplicationContext _contactContext;
    public ContactRepository(ApplicationContext context)
    {
        _contactContext = context;
    }

    public async Task<Contact> Create(Contact contact)
    {
        _contactContext.Add(contact);
        await _contactContext.SaveChangesAsync();
        return contact;
    }

    public async Task<Contact> GetById(int? id)
    {
        var contact = await _contactContext.Contacts.FindAsync(id);
        return contact;
    }

    public async Task<IEnumerable<Contact>> GetContacts()
    {
        return await _contactContext.Contacts.ToListAsync();
    }

    public async Task<Contact> Remove(Contact contact)
    {
        _contactContext.Remove(contact);
        await _contactContext.SaveChangesAsync();
        return contact;
    }

    public async Task<Contact> Update(Contact contact)
    {
        _contactContext.Update(contact);
        await _contactContext.SaveChangesAsync();
        return contact;
    }
}