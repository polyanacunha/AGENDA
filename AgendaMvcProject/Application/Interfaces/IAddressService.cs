using AgendaMvcProject.Domain.Models;

namespace AgendaMvcProject.Application.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<Address>> GetAddressAsync();
        Task<Address> GetAddressByIdAsync(int id);
        Task<Address> AddAddressAsync(Address address);
        Task<Address> UpdateAddressAsync(Address address);
        Task DeleteAddressAsync(int id);
    }
}