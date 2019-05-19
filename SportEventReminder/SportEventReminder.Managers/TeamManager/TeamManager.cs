using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportEventReminder.Common.Enums;
using SportEventReminder.Domain;
using SportEventReminder.DTO;
using SportEventReminder.UnitOfWork;

namespace SportEventReminder.Managers.TeamManager
{
    public class TeamManager : ITeamManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeamManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddOrUpdate(List<TeamDto> teamsDto)
        {
            var teams = _mapper.Map<List<TeamDto>, List<Team>>(teamsDto);

            foreach (var team in teams)
            {
                ICollection<Area> areas =
                    await _unitOfWork.AreaRepository.FindByAsync(a => a.Name.Equals(team.Area.Name));

                Area area = areas.FirstOrDefault();

                if (area != null)
                {
                    var teamQueryable = _unitOfWork.TeamRepository.FindBy(t => t.Name.Equals(team.Name) &&
                                                                                        t.Area.Id == area.Id);

                    if (!string.IsNullOrEmpty(team.ShortName))
                    {
                        teamQueryable = teamQueryable.Where(t => t.ShortName.Equals(team.ShortName));
                    }

                    if (!string.IsNullOrEmpty(team.TeamTag))
                    {
                        teamQueryable = teamQueryable.Where(t => t.TeamTag.Equals(team.TeamTag));
                    }

                    Team domainTeam = await teamQueryable.FirstOrDefaultAsync();

                    //TODO: подумать, есть ли смысл что-то обновлять или просто только добавлять новые объекты
                    if (domainTeam != null)
                    {
                        team.Id = domainTeam.Id;
                        domainTeam.TeamTag = team.TeamTag;
                    }
                    else
                    {
                        team.Area = area;
                        _unitOfWork.TeamRepository.Add(team);
                    }
                }
            }

            await _unitOfWork.CommitAsync();

            //TODO: добавить в репозиторий общий метод по обновлению интеграции
            foreach (var teamDomain in teams)
            {
                int? teamExternalId = teamsDto.FirstOrDefault(l => l.Name.Equals(teamDomain.Name) &&
                                                                       l.Area.Name.Equals(teamDomain.Area.Name))
                    ?.ExternalId;

                if (teamExternalId.HasValue)
                {
                    ICollection<ExternalSourceIntegration> externalSourceIntegrations = await _unitOfWork.ExternalSourceIntegrationRepository
                        .FindByAsync(esi => esi.ExternalObjectId == teamExternalId.Value &&
                                            esi.ExternalSource == ExternalSourceEnum.FootballDataOrg &&
                                            esi.ObjectId == teamDomain.Id &&
                                            esi.ObjectType == ObjectTypeEnum.Team);

                    if (!externalSourceIntegrations.Any())
                    {
                        var externalSourceIntegration = new ExternalSourceIntegration
                        {
                            ExternalObjectId = teamExternalId.Value,
                            ExternalSource = ExternalSourceEnum.FootballDataOrg,
                            ObjectId = teamDomain.Id,
                            ObjectType = ObjectTypeEnum.Team
                        };

                        _unitOfWork.ExternalSourceIntegrationRepository.Add(externalSourceIntegration);
                    }
                }
            }

            await _unitOfWork.CommitAsync();
        }
    }
}