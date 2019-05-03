using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SportEventReminder.Domain;
using SportEventReminder.DTO;
using SportEventReminder.ImportService.Contracts.FootballDataOrgContracts;

namespace SportEventReminder.ImportService.MappingProfiles
{
    public class FootballImportMapperProfile : Profile
    {
        public FootballImportMapperProfile()
        {
            CreateMap<AreaContract, AreaDto>().ForMember(
                dst => dst.ExternalId,
                opt => opt.MapFrom(src => src.Id));



            CreateMap<AreaDto, Area>();
        }
    }
}