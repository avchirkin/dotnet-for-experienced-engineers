using TravelCardProject.Models;

namespace TravelCardProject.Services
{
    public interface ITerminalService
    {
        Task<TerminalInfoDto> CreateTerminal(NewTerminalDto terminalCreationInfo);
    }
}
