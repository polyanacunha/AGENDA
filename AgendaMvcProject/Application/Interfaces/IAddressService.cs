using Application.Models;

namespace Application.interfaces
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