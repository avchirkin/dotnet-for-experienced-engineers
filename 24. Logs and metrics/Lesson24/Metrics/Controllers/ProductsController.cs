using Metrics.Services;
using Microsoft.AspNetCore.Mvc;

namespace Metrics.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class ProductsController(IProductsService productsService)
    : ControllerBase
{
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var product = productsService.GetById(id);
        return Ok(product);
    }
}