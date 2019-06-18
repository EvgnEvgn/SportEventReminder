using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportEventReminder.Domain;
using SportEventReminder.EntityFramework;
using SportEventReminder.Repositories.Base;
using SportEventReminder.Repositories.Interfaces;

namespace SportEventReminder.Repositories.Repositories
{
    public class MatchRepository : GenericRepository<Match>, IMatchRepository
    {
        public MatchRepository(SportEventReminderDbContext context) : base(context)
        {

        }

        public Task<List<Match>> GetScheduledMatchesByLeaguesId(List<int> leaguesId)
        {
            return _context.Match
                .Where(m => leaguesId.Contains(m.League.Id))
                .Include(x => x.League)
                .Include(x => x.AwayTeam)
                .Include(x => x.HomeTeam)
                .ToListAsync();
        }
    }
}
