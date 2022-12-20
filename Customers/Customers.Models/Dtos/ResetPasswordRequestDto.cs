using System;
namespace Customers.Models.Dtos
{
	public class ResetPasswordRequestDto
	{
        public ResetPasswordRequestDto(string username, string email)
        {
            Username = username;
            Email = email;
        }

        public required string  Username { get; set; }

		public required string  Email { get; set; }
	}
}

