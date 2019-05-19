using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportEventReminder.Common.Enums;
using SportEventReminder.Domain;
using SportEventReminder.DTO;
using SportEventReminder.UnitOfWork;

namespace SportEventReminder.Managers.LeagueManager
{
    public class LeagueManager : ILeagueManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LeagueManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddOrUpdate(List<LeagueDto> leaguesDto)
        {
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
                        if (league.CurrentSeason != null)
                        {
                            var currentSeason = domainLeague.Seasons.FirstOrDefault() ?? new Season();

                            currentSeason.EndDate = league.CurrentSeason.EndDate;
                            currentSeason.StartDate = league.CurrentSeason.StartDate;

                            domainLeague.Seasons = new List<Season> { currentSeason };
                        }
                        
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

        public async Task<List<int>> GetExternalLeaguesIds(List<LeagueDto> leaguesDto, ExternalSourceEnum externalSource)
        {
            var existedLeagues = new List<League>();
            var externalLeaguesIds = new List<int>();

            foreach (var leagueDto in leaguesDto)
            {
                IQueryable<League> leaguesQueryable = _unitOfWork.LeagueRepository.FindBy(l => l.Name.Equals(leagueDto.Name));

                if (!string.IsNullOrEmpty(leagueDto.Area.Name))
                {
                    leaguesQueryable = leaguesQueryable.Where(l => l.Area.Name.Equals(leagueDto.Area.Name));
                }

                League league = await leaguesQueryable.FirstOrDefaultAsync();

                if (league != null)
                {
                    existedLeagues.Add(league);
                }
            }

            foreach (var existedLeague in existedLeagues)
            {
                var integrations = await _unitOfWork.ExternalSourceIntegrationRepository
                    .FindByAsync(ext => ext.ObjectId == existedLeague.Id &&
                                                 ext.ExternalSource == externalSource &&
                                                 ext.ObjectType == ObjectTypeEnum.League);

                ExternalSourceIntegration integration = integrations.FirstOrDefault();

                if (integration != null)
                {
                    externalLeaguesIds.Add(integration.ExternalObjectId);
                }
            }

            return externalLeaguesIds;
        }
    }
}