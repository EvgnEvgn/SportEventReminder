using System;
using System.Collections.Generic;
using System.Text;
using SportEventReminder.Domain;
using SportEventReminder.Repositories.Base;

namespace SportEventReminder.Repositories.Interfaces
{
    public interface IExternalSourceIntegrationRepository : IGenericRepository<ExternalSourceIntegration>
    {
    }
}