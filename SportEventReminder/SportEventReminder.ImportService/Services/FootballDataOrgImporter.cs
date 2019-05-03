using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Flurl.Http;
using Flurl.Http.Configuration;
using Newtonsoft.Json;
using SportEventReminder.DTO;
using SportEventReminder.ImportService.Configuration;
using SportEventReminder.ImportService.Contracts.FootballDataOrgContracts;
using SportEventReminder.ImportService.Interfaces;

namespace SportEventReminder.ImportService.Services
{
    public class FootballDataOrgImporter : IFootballImporter
    {
        private readonly IFlurlClient _client;
        private FootballImportServiceConfiguration _configuration;
        private readonly string _areaQuery = "areas";
        private readonly IMapper _mapper;

        public FootballDataOrgImporter(IFlurlClientFactory flurlClientFactory, FootballImportServiceConfiguration cfg, IMapper mapper)
        {
            _client = flurlClientFactory.Get(cfg.FootballDataOrgApiUrl);
            _client.Headers.Add("X-Auth-Token", cfg.FootballDataOrgApiKey);
            _client.BaseUrl = cfg.FootballDataOrgApiUrl;

            _configuration = cfg;
            _mapper = mapper;
        }

        public async Task<List<AreaDto>> GetAreasAsync()
        {
            var result = await _client.Request(_areaQuery).GetStringAsync();

            var areaResponse = JsonConvert.DeserializeObject<AreaResponse>(result);

            return _mapper.Map<List<AreaContract>, List<AreaDto>>(areaResponse.Areas);
        }
    }
}
