using System;
using Customers.Models;
using Customers.Models.Dtos;

namespace Customers.Infrastructure.Abstraction
{
	public interface ICustomerService
	{
		Task<CustomerDto?> LoginAsync(LoginDto login);

		Task<bool> ResetPasswordAsync(ResetPasswordRequestDto resetPassword);

		Task<CustomerDto?> RegisterAsync(AddCustomerDto customer);

	}
}

