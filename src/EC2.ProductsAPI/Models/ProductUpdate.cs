namespace EC2.ProductsAPI.Models;

public class ProductUpdate : ProductCreate
{
    public Guid Id { get; set; }
}