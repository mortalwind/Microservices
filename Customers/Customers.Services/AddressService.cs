using System;
using Addresss.Infrastructure.Abstraction;
using AutoMapper;
using Customers.Infrastructure.Abstraction;
using Customers.Models;
using Customers.Models.Dtos;

namespace Customers.Services
{
	public class AddressService : IAddressService
	{
        private readonly IAddressRepository _repository;
        private readonly IMapper _mapper;
        public AddressService(IAddressRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Address?> AddAddressAsync(AddAddressDto addAddress)
        {
            var address = _mapper.Map<Address>(addAddress);
            return await _repository.AddAddressAsync(address);

        }

        public async Task<IEnumerable<AddressDto>> GetAddressesAsync(int customerId)
        {
            var adresses = await _repository.GetAddresses(customerId);

            return _mapper.Map<List<AddressDto>>(adresses.ToList());
        }

        public async Task<bool> RemoveAddressAsync(int id)
        {
            return await _repository.RemoveAddressAsync(id);
        }
    }
}

