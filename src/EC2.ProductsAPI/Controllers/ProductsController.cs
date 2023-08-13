using EC2.ProductsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EC2.ProductsAPI.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController: ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }

    [HttpGet("{id:guid}")]
    public IActionResult FindById(Guid id)
    {
        return Ok(id);
    }

    [HttpPost]
    public IActionResult Create(ProductCreate model)
    {
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public IActionResult Update(Guid id)
    {
        return Ok(id);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        return Ok(id);
    }
}