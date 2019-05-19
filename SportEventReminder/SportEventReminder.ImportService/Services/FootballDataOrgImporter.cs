using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Newtonsoft.Json;
using SportEventReminder.Common.Enums;
using SportEventReminder.Domain;
using SportEventReminder.DTO;
using SportEventReminder.ImportService.Comparers;
using SportEventReminder.ImportService.Configuration;
using SportEventReminder.ImportService.Contracts.FootballDataOrgContracts;
using SportEventReminder.ImportService.Interfaces;
using SportEventReminder.Managers.LeagueManager;
using SportEventReminder.UnitOfWork;

namespace SportEventReminder.ImportService.Services
{
    public class FootballDataOrgImporter : IFootballImporter
    {
        private readonly IFlurlClient _client;
        private FootballImportServiceConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILeagueManager _leagueManager;

        private readonly string _areaUrl = "areas";
        private readonly string _competitionUrl = "competitions";
        private readonly string _teamUrl = "teams";

        private readonly int _sourceTimeOutInSeconds = 60;

        public FootballDataOrgImporter(FootballImportServiceConfiguration cfg,
            IFlurlClientFactory flurlClientFactory,
            IMapper mapper,
            ILeagueManager leagueManager)
        {
            _client = flurlClientFactory.Get(cfg.FootballDataOrgApiUrl);
            _client.Headers.Add("X-Auth-Token", cfg.FootballDataOrgApiKey);
            _client.Headers.Add("X-Requests-Available-Minute", "");
            _client.BaseUrl = cfg.FootballDataOrgApiUrl;

            _configuration = cfg;
            _mapper = mapper;
            _leagueManager = leagueManager;
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

        public async Task<List<TeamDto>> GetTeamsAsync()
        {
            var availableLeagues = _mapper.Map<List<AvailableLeague>, List<LeagueDto>>(_configuration
                .FootballDataOrgAvailableLeagues.ToList());

            var availableExternalLeaguesIds =
                await _leagueManager.GetExternalLeaguesIds(availableLeagues, ExternalSourceEnum.FootballDataOrg);

            List<TeamDto> teams = new List<TeamDto>();
        
            foreach (var leaguesId in availableExternalLeaguesIds)
            {
                try
                {
                    List<TeamDto> teamsOfCurrentLeague = await GetTeamsByCompetitionAsync(leaguesId);

                    teams.AddRange(teamsOfCurrentLeague);
                }
                catch (FlurlHttpException ex)
                {
                    //TODO: переделать таймаут перед вызовом каждого метода, используя данные ответа с апи в хедере!!!
                    ErrorContract error = await ex.GetResponseJsonAsync<ErrorContract>();
                    if (error.ErrorCode == 429)
                    {
                        Thread.Sleep( _sourceTimeOutInSeconds*1000);
                        List<TeamDto> teamsOfCurrentLeague = await GetTeamsByCompetitionAsync(leaguesId);

                        teams.AddRange(teamsOfCurrentLeague);
                    }
                    
                }   
            }

            return teams.Distinct(new TeamDtoComparer()).ToList();
        }

        private async Task<List<TeamDto>> GetTeamsByCompetitionAsync(int leagueId)
        {
            var requestUrl = _competitionUrl.AppendPathSegment(leagueId).AppendPathSegment(_teamUrl);
            var responseMessage = await _client.Request(requestUrl).GetAsync();

            var headers = responseMessage.Headers;

            var result = await responseMessage.Content.ReadAsStringAsync();

            var teamResponse = JsonConvert.DeserializeObject<TeamResponse>(result);

            return _mapper.Map<List<TeamContract>, List<TeamDto>>(teamResponse.Teams);
        }
    }
}