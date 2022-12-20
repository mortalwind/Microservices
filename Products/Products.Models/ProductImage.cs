using System;
namespace Products.Models
{
	public class ProductImage : BaseEntity
    {

		public Guid ProductId { get; set; }

		public required string Path { get; set; }

		public int Order { get; set; }

	}
}

