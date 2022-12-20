using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Customers.Models.Extensions;

namespace Customers.Models
{
	public class Customer
	{

        [Key]
		public int Id { get; set; }

		public required string FirstName { get; set; }

		public required string LastName { get; set; }

		public required string UserName { get; set; }

		public required string Email { get; set; }

		public required string PhoneNumber { get; set; }

		public required string Password { get; set; }

		ICollection<Address>? Addresses { get; set; }
	}
}

