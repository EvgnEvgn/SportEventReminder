using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SportEventReminder.Common.Enums;
using SportEventReminder.Domain;
using SportEventReminder.EntityFramework;
using SportEventReminder.Repositories.Base;
using SportEventReminder.Repositories.Interfaces;

namespace SportEventReminder.Repositories.Repositories
{
    public class LeagueRepository : GenericRepository<League>, ILeagueRepository
    {
        public LeagueRepository(SportEventReminderDbContext context) : base(context)
        {
        }

        public async Task<List<League>> GetLeaguesByNameLevelAndArea(string leagueName, LeagueLevel leagueLevel,
            int areaId)
        {
            return await _context.Leagues
                .Where(l => l.Name.Equals(leagueName) &&
                            l.LeagueLevel == leagueLevel &&
                            l.Area.Id == areaId)
                .Include(l => l.Seasons)
                .ToListAsync();
        }
    }
}