using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SportEventReminder.Common.Enums;
using SportEventReminder.Domain;
using SportEventReminder.DTO;
using SportEventReminder.UnitOfWork;

namespace SportEventReminder.Managers.AreaManager
{
    public class AreaManager : IAreaManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AreaManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddOrUpdate(List<AreaDto> areasDto)
        {
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
                var areasDtoQueryable = areasDto.AsQueryable();

                areasDtoQueryable = areasDtoQueryable.Where(x => x.Name.Equals(areaDomain.Name));
                if (!string.IsNullOrEmpty(areaDomain.ParentArea))
                {
                    areasDtoQueryable = areasDtoQueryable.Where(x => x.ParentArea.Equals(areaDomain.ParentArea));
                }

                int? areaExternalId = areasDtoQueryable.FirstOrDefault()
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

        public async Task<List<AreaDto>> GetAllAsync()
        {
            var areas = await _unitOfWork.AreaRepository.GetAllAsync();

            if (areas == null)
            {
                return null;
            }

            return _mapper.Map<List<Area>, List<AreaDto>>(areas.ToList());
        }
    }
}
