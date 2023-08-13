using EC2.ProductsAPI.Context;
using EC2.ProductsAPI.Entities;
using EC2.ProductsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EC2.ProductsAPI.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly AwsPlaygroundContext _context;

    public ProductsController(AwsPlaygroundContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _context.Products
            .Select(product => MappingProductDto(product))
            .AsNoTracking()
            .ToListAsync();

        return Ok(products);
    }

    private static ProductDto MappingProductDto(Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };
    }

    [HttpGet("{id:guid}")]
    public ActionResult FindById(Guid id)
    {
        var product = FindProduct(id);

        if (product is null)
        {
            return NotFound(id);
        }

        return Ok(product);
    }

    private ProductDto? FindProduct(Guid id)
    {
        return _context.Products.Select(MappingProductDto).FirstOrDefault(product => product.Id == id);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductCreate model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var product = new Product(model.Name, model.Description, model.Price);

        _context.Products.Add(product);

        await _context.SaveChangesAsync();

        return Ok(product.Id);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, ProductUpdate model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(model);
        }

        var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);

        if (product is null)
        {
            return NotFound(id);
        }

        product.SetName(model.Name);
        product.SetDescription(model.Description);
        product.SetPrice(model.Price);

        await _context.SaveChangesAsync();

        return Ok(product);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);

        if (product is null)
        {
            return NotFound(id);
        }

        _context.Products.Remove(product);

        await _context.SaveChangesAsync();

        return Ok(id);
    }
}