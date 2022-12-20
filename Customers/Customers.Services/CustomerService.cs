using System;
using AutoMapper;
using Customers.Infrastructure;
using Customers.Infrastructure.Abstraction;
using Customers.Infrastructure.Repositories;
using Customers.Models;
using Customers.Models.Dtos;

namespace Customers.Services
{
	public class CustomerService :ICustomerService
	{
        private readonly ICustomerRepository _repository;

        private readonly IMapper _mapper;
		public CustomerService(ICustomerRepository repository, IMapper mapper)
		{
            _repository = repository;
            _mapper = mapper;
            
		}

        
        public async Task<CustomerDto?> LoginAsync(LoginDto login)
        {
            var customer =  await _repository.SignInAsync(login);
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto?> RegisterAsync(AddCustomerDto customer)
        {
            var newcustomer = await _repository.AddCustomerAsync(_mapper.Map<Customer>(customer));
            return _mapper.Map<CustomerDto>(newcustomer);
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordRequestDto resetPassword)
        {
            return await Task.FromResult<bool>(true);
        }
    }
}

