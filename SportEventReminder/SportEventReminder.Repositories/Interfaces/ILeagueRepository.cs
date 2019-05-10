using System.Collections.Generic;
using System.Threading.Tasks;
using SportEventReminder.Common.Enums;
using SportEventReminder.Domain;
using SportEventReminder.Repositories.Base;

namespace SportEventReminder.Repositories.Interfaces
{
    public interface ILeagueRepository : IGenericRepository<League>
    {
        Task<List<League>> GetLeaguesByNameLevelAndArea(string leagueName, LeagueLevel leagueLevel, int areaId);
    }
}
