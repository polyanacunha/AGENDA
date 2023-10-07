using Application.DTOs;
using Domain.Models; 
namespace Application.Interfaces;

    public interface IContactService
    {
        Task<IEnumerable<ContactDTO>> GetContacts();
        Task<ContactDTO> GetById(int id);
        Task Add(ContactDTO contactDto);
        Task Update(ContactDTO contactDto);
        Task Remove(int id);

}
