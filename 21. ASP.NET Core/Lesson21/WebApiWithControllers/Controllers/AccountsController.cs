using Microsoft.AspNetCore.Mvc;
using WebApiWithControllers.Models;
using WebApiWithControllers.Services;

namespace WebApiWithControllers.Controllers;

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