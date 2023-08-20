using AgendaMvcProject.Domain.Models;
using AgendaMvcProject.Application.DTOs;

namespace AgendaMvcProject.Application.Interfaces;

    public interface IAddressService
    {
        Task<IEnumerable<Address>> GetAddresses();
        Task<Address> GetById(int id);
        Task<Address> Add(Address address);
        Task<Address> Update(Address address);
        Task Delete(int id);
    }
