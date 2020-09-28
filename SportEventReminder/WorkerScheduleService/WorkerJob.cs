using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Threading.Tasks;

namespace WorkerScheduleService
{
    [DisallowConcurrentExecution]
    public class WorkerJob : IJob
    {
        private readonly ILogger _logger;
        private readonly RequestService _requestService;
        public WorkerJob(ILogger<WorkerJob> logger, RequestService requestService)
        {
            _logger = logger;
            _requestService = requestService;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Started WorkerJob!");
            var data = context.JobDetail.JobDataMap;
            string apiUrl = data.GetString("apiUrl");
            string requestUrl = data.GetString("requestUrl");
            _logger.LogWarning($"{apiUrl}/{requestUrl}");

            await _requestService.OnGet($"{apiUrl}/{requestUrl}");

            await Task.CompletedTask;
        }
    }
}
