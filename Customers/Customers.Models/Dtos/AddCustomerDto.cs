using System;
using Customers.Models.Extensions;

namespace Customers.Models.Dtos
{
	public class AddCustomerDto
	{
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string UserName { get; set; }

        public required string Email { get; set; }

        public required string PhoneNumber { get; set; }

        private string _password = "";

        public string Password { get { return _password; } set { _password = value.Encrypt(); } }
    }
}

