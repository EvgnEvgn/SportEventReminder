using System.Collections.Generic;
using System.Threading.Tasks;
using SportEventReminder.Domain;
using SportEventReminder.Repositories.Base;

namespace SportEventReminder.Repositories.Interfaces
{
    public interface IMatchRepository : IGenericRepository<Match>
    {
        Task<List<Match>> GetScheduledMatchesByLeaguesId(List<int> leaguesId);
    }
}
