using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportEventReminder.Common.Enums;
using SportEventReminder.Domain;
using SportEventReminder.DTO;
using SportEventReminder.ImportService.Interfaces;
using SportEventReminder.Managers.AreaManager;
using SportEventReminder.Managers.LeagueManager;
using SportEventReminder.Managers.MatchManager;
using SportEventReminder.Managers.TeamManager;
using SportEventReminder.UnitOfWork;

namespace SportEventReminder.ImportService.Services
{
    public class FootballImportService
    {
        private readonly IFootballImporter _footballImporter;
        private readonly IAreaManager _areaManager;
        private readonly ILeagueManager _leagueManager;
        private readonly ITeamManager _teamManager;
        private readonly IMatchManager _matchManager;

        public FootballImportService(IFootballImporter footballImporter,
                                     IAreaManager areaManager, 
                                     ILeagueManager leagueManager,
                                     ITeamManager teamManager,
                                     IMatchManager matchManager)
        {
            _footballImporter = footballImporter;

            _areaManager = areaManager;
            _leagueManager = leagueManager;
            _teamManager = teamManager;
            _matchManager = matchManager;
        }

        public async Task UpdateAreas()
        {
            var areasDto = await _footballImporter.GetAreasAsync();

            await _areaManager.AddOrUpdate(areasDto);
        }

        public async Task UpdateTeams()
        {
            var teamsDto = await _footballImporter.GetTeamsAsync();

            await _teamManager.AddOrUpdate(teamsDto);
        }

        public async Task UpdateLeagues()
        {
            var leaguesDto = await _footballImporter.GetLeaguesAsync();

            await _leagueManager.AddOrUpdate(leaguesDto);
        }

        public async Task UpdateMatches()
        {
            var matchesDto = await _footballImporter.GetMatchesAsync();

            await _matchManager.AddOrUpdate(matchesDto);
        }

        public void UpdatePlayers()
        {
            throw new NotImplementedException();
        }
    }
}