using System;
using AutoMapper;
using Customers.Models;
using Customers.Models.Dtos;

namespace Customers.Infrastructure.Profiles
{
	public class CustomerProfile : Profile
	{
		public CustomerProfile()
		{
			CreateMap<AddCustomerDto, Customer>();
			CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<AddAddressDto, Address>().ReverseMap();
        }
	}
}

