using System.Collections.Generic;
using System.Threading.Tasks;
using SportEventReminder.Common.Enums;
using SportEventReminder.DTO;

namespace SportEventReminder.Managers.LeagueManager
{
    public interface ILeagueManager
    {
        Task AddOrUpdate(List<LeagueDto> leaguesDto);
        Task<List<int>> GetExternalLeaguesIds(List<LeagueDto> leaguesDto, ExternalSourceEnum externalSource);
    }
}
