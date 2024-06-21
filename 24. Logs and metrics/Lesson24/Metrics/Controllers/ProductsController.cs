using Metrics.Services;
using Microsoft.AspNetCore.Mvc;

namespace Metrics.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class ProductsController(ILogger<ProductsController> logger, IProductsService productsService)
    : ControllerBase
{
    private readonly IProductsService _productsService = productsService;
    
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        logger.LogInformation($"Controller - GetById {id}");
        var product = _productsService.GetById(id);
        return Ok(product);
    }
}