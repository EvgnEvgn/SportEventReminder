using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SportEventReminder.DTO;

namespace SportEventReminder.Managers.TeamManager
{
    public interface ITeamManager
    {
        Task AddOrUpdate(List<TeamDto> teamsDto);
        Task<TeamDto> GetByIdAsync(int id);
        Task<List<TeamDto>> GetAllAsync();
    }
}
