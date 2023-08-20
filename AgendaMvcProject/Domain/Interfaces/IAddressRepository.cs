using AgendaMvcProject.Domain.Models;

namespace AgendaMvcProject.Domain.Interfaces;
public interface IAddressRepository
{
    Task<IEnumerable<Address>> GetAddresses();
    Task<Address> GetById(int? id);

    Task<Address> Create(Address address);
    Task<Address> Update(Address address);
    Task<Address> Remove(Address address);
}
