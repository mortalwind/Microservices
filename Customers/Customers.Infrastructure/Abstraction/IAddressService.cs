using System;
using Customers.Models;
using Customers.Models.Dtos;

namespace Customers.Infrastructure.Abstraction
{
	public interface IAddressService
	{
        Task<Address?> AddAddressAsync(AddAddressDto addAddress);

        Task<bool> RemoveAddressAsync(int id);

        Task<IEnumerable<AddressDto>> GetAddressesAsync(int customerId);
    }
}

