using Accounts.Application.Models;
using Accounts.Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Accounts.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class AccountsController(IAccountsService accountsService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await accountsService.GetAccountById(id);
        if (result == null) return NotFound();

        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(NewAccountDto accountCreationInfo)
    {
        var created = await accountsService.CreateAccount(accountCreationInfo);
        return Ok(created);
    }
}