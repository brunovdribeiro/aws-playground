namespace EC2.ProductsAPI.Entities;

public class Product
{
    public Product(string name, string description, decimal price)
    {
        Id = Guid.NewGuid();
        SetName(name);
        SetDescription(description);
        SetPrice(price);
    }

    public void SetPrice(decimal price)
    {
        Price = price;
    }

    public void SetDescription(string description)
    {
        Description = description;
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
}