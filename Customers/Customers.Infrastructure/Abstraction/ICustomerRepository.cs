using System;
using Customers.Models;
using Customers.Models.Dtos;

namespace Customers.Infrastructure.Abstraction
{
	public interface ICustomerRepository: IDisposable
	{
		Task<Customer> AddCustomerAsync(Customer customer);

		Task<Customer> UpdateCustomerAsync(Customer customer);

		Task<Customer> SignInAsync(LoginDto login);


	}
}

