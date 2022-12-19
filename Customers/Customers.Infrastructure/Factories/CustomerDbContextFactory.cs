using System;
using Customers.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Customers.Infrastructure.Factories
{
	public class CustomerDbContextFactory : IDesignTimeDbContextFactory<CustomerContext>
    {
        public CustomerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CustomerContext>();

            optionsBuilder.UseSqlServer("Server=sqldata,1433;Initial Catalog=Customer;User ID=sa;Password=P@ssW0rd1!;TrustServerCertificate=True;",
                sqlServerOptionsAction: o => o.MigrationsAssembly("Customers.Infrastructure"));

            return new CustomerContext(optionsBuilder.Options);
        }
    }
}
