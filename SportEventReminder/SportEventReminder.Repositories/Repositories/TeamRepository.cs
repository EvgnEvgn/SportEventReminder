using System;
using System.Collections.Generic;
using System.Text;
using SportEventReminder.EntityFramework;
using SportEventReminder.Repositories.Base;
using SportEventReminder.Repositories.Interfaces;

namespace SportEventReminder.Repositories.Repositories
{
    public class TeamRepository: GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(SportEventReminderDbContext context) : base(context)
        {

        }
    }
}
