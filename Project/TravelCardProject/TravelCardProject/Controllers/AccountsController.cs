using Microsoft.AspNetCore.Mvc;
using TravelCardProject.Models;
using TravelCardProject.Services;

namespace TravelCardProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class AccountsController(IAccountService accountService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(NewAccountDto accountCreationInfo)
        {
            var created = await accountService.CreateAccount(accountCreationInfo);
            return Ok(created);
        }
    }
}