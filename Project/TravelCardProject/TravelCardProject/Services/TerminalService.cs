using TravelCardProject.Entities;
using TravelCardProject.Models;

namespace TravelCardProject.Services
{
    public sealed class TerminalService(TravelCardsDbContext context) : ITerminalService
    {
        public async Task<TerminalInfoDto> CreateTerminal(NewTerminalDto terminalCreationInfo)
        {
            var terminal = new Terminal
            {
                Id = Guid.NewGuid(),
                Name = terminalCreationInfo.Name,
                TransportType = terminalCreationInfo.TransportType,
            };

            var entry = await context.AddAsync(terminal);
            await context.SaveChangesAsync();

            return TerminalInfoDto.FromEntity(entry.Entity);
        }
    }
}
