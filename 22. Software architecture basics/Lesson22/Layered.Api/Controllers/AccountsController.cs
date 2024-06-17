using Layered.ApplicationCore.Models;
using Layered.ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace Layered.Api.Controllers;

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