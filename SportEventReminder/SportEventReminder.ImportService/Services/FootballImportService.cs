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
            var areasDtos = await _footballImporter.GetAreasAsync();
            var areas = _mapper.Map<List<AreaDto>, List<Area>>(areasDtos);

            foreach (var area in areas)
            {
                var domainAreas = await _unitOfWork.AreaRepository.FindByAsync(x => x.Name.Equals(area.Name));
                
                var domain = domainAreas.FirstOrDefault();

                if (domain != null)
                {
                    domain.Name = area.Name;
                    domain.ParentArea = area.ParentArea;
                }
                else
                {
                    _unitOfWork.AreaRepository.Add(area);
                }
            }

            await _unitOfWork.CommitAsync();

            foreach (var areaDto in areasDtos)
            {
                var domainAreas = await _unitOfWork.AreaRepository.FindByAsync(p => p.Name.Equals(areaDto.Name));
                var area = domainAreas.FirstOrDefault();

                if (area != null)
                {
                    var externalSourceIntegrations = await _unitOfWork.ExternalSourceIntegrationRepository
                        .FindByAsync(p => p.ExternalSource == ExternalSourceEnum.FootballDataOrg &&
                                          p.ExternalObjectId == areaDto.ExternalId &&
                                          p.ObjectType == ObjectTypeEnum.Area &&
                                          p.ObjectId == area.Id);

                    if (!externalSourceIntegrations.Any())
                    {
                        var externalSourceIntegration = new ExternalSourceIntegration
                        {
                            ExternalSource = ExternalSourceEnum.FootballDataOrg,
                            ExternalObjectId = areaDto.ExternalId,
                            ObjectId = area.Id,
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

        public void UpdateLeagues()
        {
            throw new NotImplementedException();
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