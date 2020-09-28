using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace WorkerScheduleService
{
    public class RequestService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<RequestService> _logger;

        public RequestService(ILogger<RequestService> logger, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        }

        public async Task OnGet(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                _logger.LogInformation("Successfull");
                _logger.LogInformation(result);
            }
            else
            {
                _logger.LogError($"{response.StatusCode}");
            }
        }
    }
}
