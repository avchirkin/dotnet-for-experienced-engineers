using Accounts.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.API.Infrastructure;

[ApiController]
[Route("[controller]")]
public class AccountsController(IAccountsService accountsService) : ControllerBase
{
    [HttpGet("all")]
    public async Task<IActionResult> GetAll([FromQuery] bool isActiveOnly = true)
    {
        var result = await accountsService.GetAllAccounts(isActiveOnly);
        return Ok(result);
    }
    
    [HttpGet("{number:long}")]
    public async Task<IActionResult> GetAll(long number)
    {
        var result = await accountsService.GetAccountByNumber(number);
        return result == null ? NotFound() : Ok(result);
    }
}