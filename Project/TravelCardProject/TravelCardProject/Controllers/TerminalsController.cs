using Microsoft.AspNetCore.Mvc;
using TravelCardProject.Models;
using TravelCardProject.Services;

namespace TravelCardProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TerminalsController(ITerminalService terminalService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create(NewTerminalDto terminalCreationInfo)
        {
            var created = await terminalService.CreateTerminal(terminalCreationInfo);
            return Ok(created);
        }
    }
}
