using System;
using System.ComponentModel.DataAnnotations;
using Customers.Models.Enums;

namespace Customers.Models
{
	public class Address
	{
		[Key]
		public int Id { get; set; }

		public int CustomerId { get; set; }

		public required string Title { get; set; }

		public bool IsDefault { get; set; } = true;

		public required string AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

		public required string District { get; set; }

		public required string City { get; set; }

		public AddressTypes AddressType { get; set; } = AddressTypes.Delivery;

		public required Customer Customer { get; set; }
	}
}

