using AgendaMvcProject.Application.DTOs;
using AgendaMvcProject.Domain.Models; 
namespace AgendaMvcProject.Application.Interfaces;

    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetContacts();
        Task<Contact> GetById(int id);
        Task<Contact> Add(ContactDTO contact);
        Task<Contact> Update(ContactDTO contact);
        Task Delete(int id);

}
