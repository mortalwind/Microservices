namespace Products.Models;
public class Product : BaseEntity
{

    public Guid CategoryId { get; set; }

    public required string ProductName { get; set; }

    public string? Description { get; set; }

    public IEnumerable<ProductProperty> Properties { get; set; }

    public decimal Price { get; set; }

    public int Tax { get; set; }

    public decimal CargoPrice { get; set; }

    public decimal TotalPrice { get; set; }

}

