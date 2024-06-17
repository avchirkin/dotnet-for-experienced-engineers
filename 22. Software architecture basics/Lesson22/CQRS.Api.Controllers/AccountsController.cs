using CQRS.Features.Accounts.CreateAccount;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class AccountsController(IMediator sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateAccountCommand createAccountCommand)
    {
        var created = await sender.Send(createAccountCommand);
        return Ok(created);
    }
}