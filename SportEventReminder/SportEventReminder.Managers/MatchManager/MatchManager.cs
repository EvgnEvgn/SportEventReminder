using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SportEventReminder.Common.Enums;
using SportEventReminder.Domain;
using SportEventReminder.DTO;
using SportEventReminder.UnitOfWork;

namespace SportEventReminder.Managers.MatchManager
{
    public class MatchManager : IMatchManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MatchManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddOrUpdate(List<MatchDto> matchesDto)
        {
            var matches = new List<Match>();

            foreach (var matchDto in matchesDto)
            {
                League league = null;
                Team homeTeam = null;
                Team awayTeam = null;

                var externalIntegrations = await _unitOfWork.ExternalSourceIntegrationRepository.FindByAsync(ext =>
                    ext.ExternalObjectId == matchDto.League.ExternalId &&
                    ext.ObjectType == ObjectTypeEnum.League &&
                    ext.ExternalSource == ExternalSourceEnum.FootballDataOrg);

                int? leagueId = externalIntegrations.FirstOrDefault()?.ObjectId;

                if (leagueId != null)
                {
                    league = await _unitOfWork.LeagueRepository.GetAsync(leagueId.Value);
                }

                externalIntegrations = await _unitOfWork.ExternalSourceIntegrationRepository.FindByAsync(ext =>
                    ext.ExternalObjectId == matchDto.HomeTeam.ExternalId &&
                    ext.ObjectType == ObjectTypeEnum.Team &&
                    ext.ExternalSource == ExternalSourceEnum.FootballDataOrg);

                int? homeTeamId = externalIntegrations.FirstOrDefault()?.ObjectId;

                if (homeTeamId != null)
                {
                    homeTeam = await _unitOfWork.TeamRepository.GetAsync(homeTeamId.Value);
                }


                externalIntegrations = await _unitOfWork.ExternalSourceIntegrationRepository.FindByAsync(ext =>
                    ext.ExternalObjectId == matchDto.AwayTeam.ExternalId &&
                    ext.ObjectType == ObjectTypeEnum.Team &&
                    ext.ExternalSource == ExternalSourceEnum.FootballDataOrg);

                int? awayTeamId = externalIntegrations.FirstOrDefault()?.ObjectId;

                if (awayTeamId != null)
                {
                    awayTeam = await _unitOfWork.TeamRepository.GetAsync(awayTeamId.Value);
                }

                if (league != null && homeTeam != null && awayTeam != null)
                {
                    ICollection<Match> domainMatches = await _unitOfWork.MatchRepository.FindByAsync(m =>
                        m.League.Id == league.Id &&
                        m.HomeTeam.Id == homeTeam.Id &&
                        m.AwayTeam.Id == awayTeam.Id);

                    Match match = domainMatches.FirstOrDefault();

                    if (match == null)
                    {
                        match = new Match
                        {
                            League = league,
                            AwayTeam = awayTeam,
                            HomeTeam = homeTeam,
                            StartDate = matchDto.StartDate
                        };
                        match.Status = matchDto.Status;

                        _unitOfWork.MatchRepository.Add(match);
                    }
                    else
                    {
                        match.StartDate = matchDto.StartDate;
                        match.Status = matchDto.Status;
                    }

                    matches.Add(match);
                }
            }

            await _unitOfWork.CommitAsync();


            foreach (var match in matches)
            {
                int? matchExternalId = matchesDto.FirstOrDefault(dto => dto.StartDate == match.StartDate &&
                                                                        dto.AwayTeam.Name.Equals(match.AwayTeam.Name) &&
                                                                        dto.HomeTeam.Name.Equals(match.HomeTeam.Name) &&
                                                                        dto.League.Name.Equals(match.League.Name))
                    ?.ExternalId;

                if (matchExternalId.HasValue)
                {
                    ICollection<ExternalSourceIntegration> externalSourceIntegrations = await _unitOfWork
                        .ExternalSourceIntegrationRepository
                        .FindByAsync(esi => esi.ExternalObjectId == matchExternalId.Value &&
                                            esi.ExternalSource == ExternalSourceEnum.FootballDataOrg &&
                                            esi.ObjectId == match.Id &&
                                            esi.ObjectType == ObjectTypeEnum.Match);

                    if (!externalSourceIntegrations.Any())
                    {
                        var externalSourceIntegration = new ExternalSourceIntegration
                        {
                            ExternalObjectId = matchExternalId.Value,
                            ExternalSource = ExternalSourceEnum.FootballDataOrg,
                            ObjectId = match.Id,
                            ObjectType = ObjectTypeEnum.Match
                        };

                        _unitOfWork.ExternalSourceIntegrationRepository.Add(externalSourceIntegration);
                    }
                }
            }

            await _unitOfWork.CommitAsync();
        }
    }
}