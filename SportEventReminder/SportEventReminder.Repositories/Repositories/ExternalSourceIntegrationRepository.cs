using System;
using System.Collections.Generic;
using System.Text;
using SportEventReminder.Domain;
using SportEventReminder.EntityFramework;
using SportEventReminder.Repositories.Base;
using SportEventReminder.Repositories.Interfaces;

namespace SportEventReminder.Repositories.Repositories
{
    public class ExternalSourceIntegrationRepository : GenericRepository<ExternalSourceIntegration>, IExternalSourceIntegrationRepository
    {
        public ExternalSourceIntegrationRepository(SportEventReminderDbContext context) : base(context)
        {
        }
    }
}
