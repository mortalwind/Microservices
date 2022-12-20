using System;
using Customers.Infrastructure.Repositories;
using Customers.Models.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Customers.Api.Models
{
	public static class DbPrepare
	{
		public static void PopulateData(IApplicationBuilder app)
		{
			using (var serviceScope = app.ApplicationServices.CreateScope())
			{
                Seed(serviceScope.ServiceProvider.GetService<CustomerContext>());
			}
		}

		public static void Seed(CustomerContext context) {
			Console.WriteLine("---- >>>> Database migration is started");
			context.Database.Migrate();
            Console.WriteLine("---- >>>> Database migration is finished");

            //Create a customer for test if it doesn't exist.
            if (!context.Customers.Any())
			{
				context.Customers.Add(new Customers.Models.Customer() {
					FirstName ="Ferhat",
					LastName = "Karabulut",
					UserName = "fkarabulut",
					Password = "31Ocak1983".Encrypt(),
					Email = "fkarabulut@gmail.com",
					PhoneNumber = "5547676554"
				});
				context.SaveChanges();
                Console.WriteLine("---- >>>> Test user is created");
            }
		}
	}
}

