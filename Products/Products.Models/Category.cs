using System;
namespace Products.Models
{
	public class Category : BaseEntity
    {
		
		public required string CatergoryName { get; set; }

		public string? CategoryImage { get; set; }

	}
}

