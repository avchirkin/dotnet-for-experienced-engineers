using Logging.Services;
using Microsoft.AspNetCore.Mvc;

namespace Logging.Controllers;

// Логгер прокидываем через DI и интерфейс ILogger
[ApiController]
[Route("[controller]")]
public sealed class ProductsController(ILogger<ProductsController> logger, IProductsService productsService)
    : ControllerBase
{
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        // Публикуем событие в лог. Параметры в фигурных скобках - не интерполяция строки, а специальные шаблоны,
        // которые используются в структурном логировании.
        logger.LogInformation("Controller - {Controller}: {RequestedId}", nameof(ProductsController), id);
        var product = productsService.GetById(id);
        return Ok(product);
    }

    [HttpGet("{name}")]
    public IActionResult GetByNameEx(string name)
    {
        try
        {
            throw new Exception("Some internal exception");
        }
        catch(Exception ex)
        {
            /* Помимо текста и сложных типов данных, можно логировать исключения. Экземпляр исключения в логах будет 
             представлен объектом, содержащим все публичные свойства исключения (Message, StackTrace и пр.)
             Обратите внимание на символ @ в параметре шаблона. Этот символ означает, что параметр в скобках является
             сложным объектом, и его нужно представлять в логах как набор полей, а не просто вызвать ToString()
            */
            logger.LogError("{@Exception}", ex);
            throw;
        }
    }
}