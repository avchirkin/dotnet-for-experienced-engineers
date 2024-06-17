using Microsoft.AspNetCore.Mvc;
using Onion.Application.Models;
using Onion.Application.Services.Abstractions;

namespace Onion.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class AccountsController(IAccountsService accountsService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(NewAccountDto accountCreationInfo)
    {
        var created = await accountsService.CreateAccount(accountCreationInfo);
        return Ok(created);
    }
}