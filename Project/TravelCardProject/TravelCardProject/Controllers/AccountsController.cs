using Microsoft.AspNetCore.Mvc;
using TravelCardProject.Models;
using TravelCardProject.Services;

namespace TravelCardProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class AccountsController(IAccountService accountService) : ControllerBase
    {

    }
}