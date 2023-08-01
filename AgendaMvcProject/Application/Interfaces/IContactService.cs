using Application.Models;
using Microsoft.EntityFrameworkCore;
//<PackageReference Include="Microsoft.EntityFrameworkCore" Version="7.0.5">

//<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="7.0.5">

namespace Application.interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetContactsAsync();
        Task<Contact> GetContactByIdAsync(int id);
        Task<Contact> AddContactAsync(Contact contact);
        Task<Contact> UpdateContactAsync(Contact contact);
        Task DeleteContactAsync(int id);
    }
}
