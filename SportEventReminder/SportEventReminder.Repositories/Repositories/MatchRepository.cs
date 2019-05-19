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
    }
}
