using System;
using Customers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customers.Infrastructure.DbConfigurations
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {


        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
                .UseHiLo("customers_hilo")
                .IsRequired();

            builder.Property(ci => ci.FirstName)
                .IsRequired(true)
                .HasMaxLength(150);

            builder.Property(ci => ci.LastName)
                .IsRequired(true)
                .HasMaxLength(100);
            
            builder.Property(ci => ci.UserName)
                .IsRequired(true)
                .HasMaxLength(150);

            builder.Property(ci => ci.Email)
                .IsRequired(true)
                .HasMaxLength(300);

            builder.Property(ci => ci.PhoneNumber)
                .IsRequired(true)
                .HasMaxLength(12);

        }

    }
}

