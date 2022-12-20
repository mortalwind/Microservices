using System;
using Customers.Infrastructure.DbConfigurations;
using Customers.Models;
using Microsoft.EntityFrameworkCore;

namespace Customers.Infrastructure.Repositories
{
	public class CustomerContext: DbContext
	{
		public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
		{
		}

		public DbSet<Customer> Customers { get; set; }

		public DbSet<Address> Addresses { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new CustomerEntityConfiguration());
            builder.ApplyConfiguration(new AddressEntityConfiguration());
        }
	}
}

