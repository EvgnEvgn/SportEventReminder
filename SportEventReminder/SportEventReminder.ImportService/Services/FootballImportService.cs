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
using SportEventReminder.UnitOfWork;

namespace SportEventReminder.ImportService.Services
{
    public class FootballImportService
    {
        private readonly IFootballImporter _footballImporter;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FootballImportService(IUnitOfWork unitOfWork, IFootballImporter footballImporter, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _footballImporter = footballImporter;
            _mapper = mapper;
        }

        public async Task UpdateAreas()
        {
            var areasDto = await _footballImporter.GetAreasAsync();
            var areas = _mapper.Map<List<AreaDto>, List<Area>>(areasDto);

            foreach (var area in areas)
            {
                var domainAreas = await _unitOfWork.AreaRepository.FindByAsync(x => x.Name.Equals(area.Name));

                var domain = domainAreas.FirstOrDefault();

                if (domain != null)
                {
                    domain.Name = area.Name;
                    domain.ParentArea = area.ParentArea;
                    area.Id = domain.Id;
                }
                else
                {
                    _unitOfWork.AreaRepository.Add(area);
                }
            }

            await _unitOfWork.CommitAsync();

            foreach (var areaDomain in areas)
            {
                int? areaExternalId = areasDto.FirstOrDefault(x => x.Name.Equals(areaDomain.Name) &&
                                                                   x.ParentArea.Equals(areaDomain.ParentArea))
                    ?.ExternalId;

                if (areaExternalId.HasValue)
                {
                    var externalSourceIntegrations = await _unitOfWork.ExternalSourceIntegrationRepository
                        .FindByAsync(p => p.ExternalSource == ExternalSourceEnum.FootballDataOrg &&
                                          p.ExternalObjectId == areaExternalId.Value &&
                                          p.ObjectType == ObjectTypeEnum.Area &&
                                          p.ObjectId == areaDomain.Id);

                    if (!externalSourceIntegrations.Any())
                    {
                        var externalSourceIntegration = new ExternalSourceIntegration
                        {
                            ExternalSource = ExternalSourceEnum.FootballDataOrg,
                            ExternalObjectId = areaExternalId.Value,
                            ObjectId = areaDomain.Id,
                            ObjectType = ObjectTypeEnum.Area
                        };

                        _unitOfWork.ExternalSourceIntegrationRepository.Add(externalSourceIntegration);
                    }
                }
            }

            await _unitOfWork.CommitAsync();
        }

        public void UpdateTeams()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateLeagues()
        {
            var leaguesDto = await _footballImporter.GetLeaguesAsync();
            var leagues = _mapper.Map<List<LeagueDto>, List<League>>(leaguesDto);

            foreach (var league in leagues)
            {
                Area area = (await _unitOfWork.AreaRepository.FindByAsync(a => a.Name.Equals(league.Area.Name))).FirstOrDefault();
                if (area != null)
                {
                    List<League> domainLeagues = await _unitOfWork.LeagueRepository.GetLeaguesByNameLevelAndArea(league.Name, league.LeagueLevel, area.Id);

                    var domainLeague = domainLeagues.FirstOrDefault();

                    if (domainLeague != null)
                    {
                        league.Id = domainLeague.Id;
                        //TODO: нужно подумать, как обновлять сезоны(и нужно ли). Пока что обновляем один текущий сезон
                        var currentSeason = domainLeague.Seasons.FirstOrDefault() ?? new Season();

                        currentSeason.EndDate = league.CurrentSeason.EndDate;
                        currentSeason.StartDate = league.CurrentSeason.StartDate;

                        domainLeague.Seasons = new List<Season>{ currentSeason };
                        domainLeague.LeagueLevel = league.LeagueLevel;
                    }
                    else
                    {
                        league.Area = area;

                        if (league.CurrentSeason != null)
                        {
                            league.Seasons = new List<Season> { league.CurrentSeason };
                        }

                        _unitOfWork.LeagueRepository.Add(league);
                    }
                }
            }

            await _unitOfWork.CommitAsync();

            foreach (var leagueDomain in leagues)
            {
                int? leagueExternalId = leaguesDto.FirstOrDefault(l => l.Name.Equals(leagueDomain.Name) &&
                                                                       l.Area.Name.Equals(leagueDomain.Area.Name))
                    ?.ExternalId;

                if (leagueExternalId.HasValue)
                {
                    ICollection<ExternalSourceIntegration> externalSourceIntegrations = await _unitOfWork.ExternalSourceIntegrationRepository
                        .FindByAsync(esi => esi.ExternalObjectId == leagueExternalId.Value &&
                                            esi.ExternalSource == ExternalSourceEnum.FootballDataOrg &&
                                            esi.ObjectId == leagueDomain.Id &&
                                            esi.ObjectType == ObjectTypeEnum.League);

                    if (!externalSourceIntegrations.Any())
                    {
                        var externalSourceIntegration = new ExternalSourceIntegration
                        {
                            ExternalObjectId = leagueExternalId.Value,
                            ExternalSource = ExternalSourceEnum.FootballDataOrg,
                            ObjectId = leagueDomain.Id,
                            ObjectType = ObjectTypeEnum.League
                        };

                        _unitOfWork.ExternalSourceIntegrationRepository.Add(externalSourceIntegration);
                    }
                }
            }

            await _unitOfWork.CommitAsync();
        }

        public void UpdateMatches()
        {
            throw new NotImplementedException();
        }

        public void UpdatePlayers()
        {
            throw new NotImplementedException();
        }
    }
}