using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Quartz;
using SportEventReminder.ImportService.Interfaces;

namespace SportEventReminder.ScheduleService.Jobs
{
    public class FootballImportJob : IJob
    {
        private readonly ILogger _logger;
        private readonly IFootballImportService _footballImportService;

        public FootballImportJob(ILogger<FootballImportJob> logger, IFootballImportService footballImportService)
        {
            _logger = logger;
            _footballImportService = footballImportService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Import football data!");
            await _footballImportService.UpdateAreas();
            await _footballImportService.UpdateTeams();
            await _footballImportService.UpdateLeagues();
            await _footballImportService.UpdateMatches();
        }
    }
}
