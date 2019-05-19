using System.Collections.Generic;
using System.Threading.Tasks;
using SportEventReminder.DTO;

namespace SportEventReminder.ImportService.Interfaces
{
    public interface IFootballImporter
    {
        Task<List<AreaDto>> GetAreasAsync();

        Task<List<LeagueDto>> GetLeaguesAsync();

        Task<List<TeamDto>> GetTeamsAsync();

        Task<List<MatchDto>> GetMatchesAsync();
    }
}
