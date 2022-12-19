using System;
using Addresss.Infrastructure.Abstraction;
using Customers.Models;
using Microsoft.EntityFrameworkCore;

namespace Customers.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly CustomerContext _context;

        public AddressRepository(CustomerContext context)
        {
            _context = context;
        }

        public async Task<Address?> AddAddressAsync(Address address)
        {
            await _context.AddAsync<Address>(address);
            var resultCount = await _context.SaveChangesAsync();

            if (resultCount > 0)
            {
                return address;
            }

            return await Task.FromException<Address>(new Exception("Address could not be added."));
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<bool> RemoveAddressAsync(int addressId)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == addressId);
            if (address is not null)
            {
                _context.Addresses.Remove(address);
                var resultCount = await _context.SaveChangesAsync();

                return resultCount > 0;

            }
            return await Task.FromException<bool>(new Exception("Address could not be found."));
        }

        public async Task<Address> UpdateAddressAsync(Address address)
        {


            _context.Addresses.Update(address);
            var resultCount = await _context.SaveChangesAsync();

            if (resultCount > 0)
            {
                return address;
            }

            return await Task.FromException<Address>(new Exception("Address could not be updated."));
        }

        public async Task<IEnumerable<Address>> GetAddresses(int customerId)
        {
            return await _context.Addresses.Where(x => x.CustomerId == customerId).AsNoTracking().ToListAsync();
        }
    }
}

