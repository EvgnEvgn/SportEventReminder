using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Newtonsoft.Json;
using SportEventReminder.DTO;
using SportEventReminder.ImportService.Configuration;
using SportEventReminder.ImportService.Contracts.FootballDataOrgContracts;
using SportEventReminder.ImportService.Interfaces;
using SportEventReminder.UnitOfWork;

namespace SportEventReminder.ImportService.Services
{
    public class FootballDataOrgImporter : IFootballImporter
    {
        private readonly IFlurlClient _client;
        private FootballImportServiceConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _areaUrl = "areas";
        private readonly string _competitionUrl = "competitions";
        

        public FootballDataOrgImporter(FootballImportServiceConfiguration cfg, 
            IFlurlClientFactory flurlClientFactory, 
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _client = flurlClientFactory.Get(cfg.FootballDataOrgApiUrl);
            _client.Headers.Add("X-Auth-Token", cfg.FootballDataOrgApiKey);
            _client.BaseUrl = cfg.FootballDataOrgApiUrl;

            _configuration = cfg;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<AreaDto>> GetAreasAsync()
        {
            var result = await _client.Request(_areaUrl).GetStringAsync();

            var areaResponse = JsonConvert.DeserializeObject<AreaResponse>(result);

            return _mapper.Map<List<AreaContract>, List<AreaDto>>(areaResponse.Areas);
        }

        public async Task<List<LeagueDto>> GetLeaguesAsync()
        {
            var result = await _client.Request(_competitionUrl).GetStringAsync();

            var competitionResponse = JsonConvert.DeserializeObject<CompetitionResponse>(result);

            return _mapper.Map<List<CompetitionContract>, List<LeagueDto>>(competitionResponse.Competitions);
        }
    }
}
