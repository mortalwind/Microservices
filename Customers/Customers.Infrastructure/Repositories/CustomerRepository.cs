using System;
using Customers.Infrastructure.Abstraction;
using Customers.Models;
using Customers.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Customers.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<Customer> SignInAsync(LoginDto login)
        {
            return await _context.Customers.FirstOrDefaultAsync(x => x.UserName.Equals(login.Username) && x.Password.Equals(login.Password));
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
             _context.Update(customer);
            var changeCount = await _context.SaveChangesAsync();
            if (changeCount > 0)
            {
                return customer;
            }

            return await Task.FromException<Customer>(new Exception("Customer couldn't updated."));
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            await _context.AddAsync<Customer>(customer);
            var changeCount = await _context.SaveChangesAsync();
            if (changeCount > 0)
            {
                return customer;
            }

            return await Task.FromException<Customer>(new Exception("Customer couldn't added."));
        }

    }
}

