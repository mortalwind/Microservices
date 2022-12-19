using System;
using Customers.Models.Extensions;

namespace Customers.Models.Dtos
{
	public class LoginDto
	{
        public required string Username { get; set; }
        private string _password = "";

		public string Password { get { return _password; } set { _password = value.Encrypt(); } }
	}
}

