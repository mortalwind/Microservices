using System;
namespace Products.Models
{
	public class ProductProperty : BaseEntity
    {
		public required string PropertyName { get; set; }

		public required string PropetyValue { get; set; }
	}
}

