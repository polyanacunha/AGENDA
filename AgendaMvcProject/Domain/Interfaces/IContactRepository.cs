using AgendaMvcProject.Domain.Models;

namespace AgendaMvcProject.Domain.Interfaces;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetContacts();
    Task<Contact> GetById(int? id);

    Task<Contact> Create(Contact contact);
    Task<Contact> Update(Contact contact);
    Task<Contact> Remove(Contact contact);
}
