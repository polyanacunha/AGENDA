using AgendaMvcProject.Application.DTOs;
using AgendaMvcProject.Domain.Models; 
namespace AgendaMvcProject.Application.Interfaces;

    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetContacts();
        Task<Contact> GetById(int id);
        Task<Contact> Add(Contact contact);
        Task<Contact> Update(Contact contact);
        Task Delete(int id);

}
