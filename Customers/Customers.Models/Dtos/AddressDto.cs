using System;
using Customers.Models.Enums;

namespace Customers.Models.Dtos
{
	public class AddressDto
	{
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public required string Title { get; set; }

        public bool IsDefault { get; set; } = true;

        public required string AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        public required string District { get; set; }

        public required string City { get; set; }

        public AddressTypes AddressType { get; set; } = AddressTypes.Delivery;
    }
}

