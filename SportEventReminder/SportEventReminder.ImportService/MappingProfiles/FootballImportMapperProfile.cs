using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SportEventReminder.Common.Enums;
using SportEventReminder.Common.Helpers;
using SportEventReminder.Domain;
using SportEventReminder.DTO;
using SportEventReminder.ImportService.Contracts.FootballDataOrgContracts;
using SportEventReminder.ImportService.MappingResolvers.Resolvers;

namespace SportEventReminder.ImportService.MappingProfiles
{
    public class FootballImportMapperProfile : Profile
    {
        public FootballImportMapperProfile()
        {
            CreateMap<AreaContract, AreaDto>()
                .ForMember(dst => dst.ExternalId,opt => opt.MapFrom(src => src.Id));
            CreateMap<TeamContract, TeamDto>()
                .ForMember(dst => dst.ExternalId,opt => opt.MapFrom(p => p.Id));
            CreateMap<SeasonContract, SeasonDto>()
                .ForMember(dst => dst.Winner, opt => opt.MapFrom(s => s.Winner));
            CreateMap<CompetitionContract, LeagueDto>()
                .ForMember(dst => dst.LeagueLevel,opt => opt.MapFrom<LeagueLevelResolver>())
                .ForMember(dst => dst.ExternalId, opt => opt.MapFrom(p => p.Id));

            CreateMap<AreaDto, Area>();
            CreateMap<SeasonDto, Season>();
            CreateMap<TeamDto, Team>();
            CreateMap<LeagueDto, League>();
        }
    }
}