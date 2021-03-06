﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SportEventReminder.Common.Enums;
using SportEventReminder.Common.Helpers;
using SportEventReminder.Domain;
using SportEventReminder.DTO;
using SportEventReminder.Common.Configuration;
using SportEventReminder.ImportService.Contracts.FootballDataOrgContracts;
using SportEventReminder.ImportService.MappingResolvers.Resolvers;

namespace SportEventReminder.ImportService.MappingProfiles
{
    public class FootballImportMapperProfile : Profile
    {
        public FootballImportMapperProfile()
        {
            CreateMap<AreaContract, AreaDto>()
                .ForMember(dst => dst.ExternalId,opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Id, opt => opt.Ignore());

            CreateMap<TeamContract, TeamDto>()
                .ForMember(dst => dst.ExternalId,opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Id, opt => opt.Ignore());

            CreateMap<SeasonContract, SeasonDto>()
                .ForMember(dst => dst.Winner, opt => opt.MapFrom(src => src.Winner))
                .ForMember(dst => dst.Id, opt => opt.Ignore());

            CreateMap<CompetitionContract, LeagueDto>()
                .ForMember(dst => dst.LeagueLevel,opt => opt.MapFrom<LeagueLevelResolver>())
                .ForMember(dst => dst.ExternalId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Id, opt => opt.Ignore());

            CreateMap<AvailableLeague, LeagueDto>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.LeagueName))
                .ForMember(dst => dst.Area, opt => opt.MapFrom<AreaDtoResolver>());

            CreateMap<MatchContract, MatchDto>()
                .ForMember(dst => dst.ExternalId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.StartDate, opt => opt.MapFrom(src => src.UtcDate))
                .ForMember(dst => dst.League, opt => opt.MapFrom(src => src.Competition))
                .ForMember(dst => dst.Status, opt => opt.MapFrom<MatchStatusResolver>())
                .ForMember(dst => dst.Id, opt => opt.Ignore());

            CreateMap<AreaDto, Area>();
            CreateMap<SeasonDto, Season>();
            CreateMap<TeamDto, Team>();
            CreateMap<LeagueDto, League>();
            CreateMap<MatchDto, Match>();

            CreateMap<Team, TeamDto>();
            CreateMap<League, LeagueDto>();
            CreateMap<Area, AreaDto>();
            CreateMap<Match, MatchDto>();
        }
    }
}