using AgendaMvcProject.Application.Interfaces;
using AgendaMvcProject.Domain.Models;
using AgendaMvcProject.Data.Context;
using Microsoft.EntityFrameworkCore;
using AgendaMvcProject.Application.Interfaces;

namespace Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly ApplicationContext _context;

        public AddressService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Address>> GetAddressesAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            return await _context.Addresses.FindAsync(id);
        }

        public async Task<Address> AddAddressAsync(Address address)
        {
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();

            return address;
        }

        public async Task<Address> UpdateAddressAsync(Address address)
        {
            _context.Entry(address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(address.Id))
                {
                    throw new ArgumentException($"Address with id {address.Id} not found.");
                }

                throw;
            }

            return address;
        }

        public async Task DeleteAddressAsync(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                throw new ArgumentException($"Address with id {id} not found.");
            }

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
        }

        private bool AddressExists(int id)
        {
            return _context.Addresses.Any(e => e.Id == id);
        }

        public Task<IEnumerable<Address>> GetAddressAsync()
        {
            throw new NotImplementedException();
        }
    }
}