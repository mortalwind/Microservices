using System;
using Customers.Models;
using Customers.Models.Dtos;

namespace Addresss.Infrastructure.Abstraction
{
    public interface IAddressRepository : IDisposable
    {
        Task<Address?> AddAddressAsync(Address address);

        Task<Address> UpdateAddressAsync(Address address);

        Task<bool> RemoveAddressAsync(int addressId);

        Task<IEnumerable<Address>> GetAddresses(int customerId);

    }
}

