namespace EC2.ProductsAPI.Models;

public class ProductCreate
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}