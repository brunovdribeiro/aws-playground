using EC2.ProductsAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace EC2.ProductsAPI.Context;

public class AwsPlaygroundContext : DbContext
{
    public AwsPlaygroundContext(DbContextOptions<AwsPlaygroundContext> options) :
        base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}