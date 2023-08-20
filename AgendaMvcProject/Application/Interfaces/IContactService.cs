using AgendaMvcProject.Domain.Models; 
using AgendaMvcProject.Application.DTOs;

namespace AgendaMvcProject.Application.Interfaces;

    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetContactsAsync();
        Task<Contact> GetContactByIdAsync(int id);
        Task<Contact> AddContactAsync(Contact contact);
        Task<Contact> UpdateContactAsync(Contact contact);
        Task DeleteContactAsync(int id);

}
