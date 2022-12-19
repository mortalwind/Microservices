using System;
using Customers.Models;
using Customers.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customers.Infrastructure.DbConfigurations
{
	public class AddressEntityConfiguration : IEntityTypeConfiguration<Address>
	{
		

        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("CustomerAddresses");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
                .UseHiLo("customer_address_hilo")
                .IsRequired();


            builder.Property(ci => ci.Title)
                .IsRequired(true)
                .HasMaxLength(150);

            builder.Property(ci => ci.IsDefault)
                .IsRequired(true);

            builder.Property(ci => ci.AddressLine1)
                .IsRequired(true)
                .HasMaxLength(250);

            builder.Property(ci => ci.AddressLine2)
                .IsRequired(false)
                .HasMaxLength(250);

            builder.Property(ci => ci.District)
                .IsRequired(true)
                .HasMaxLength(30);

            builder.Property(ci => ci.City)
                .IsRequired(true)
                .HasMaxLength(30);

            builder.Property(ci => ci.AddressType)
                .IsRequired(true); 

            builder.HasOne(ci => ci.Customer)
                .WithMany()
                .HasForeignKey(ci => ci.CustomerId);
        }
    }
}
