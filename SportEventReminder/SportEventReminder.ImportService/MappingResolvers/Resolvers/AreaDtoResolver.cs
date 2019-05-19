using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SportEventReminder.Common.Enums;
using SportEventReminder.DTO;
using SportEventReminder.ImportService.Configuration;

namespace SportEventReminder.ImportService.MappingResolvers.Resolvers
{
    public class AreaDtoResolver : IValueResolver<AvailableLeague, LeagueDto, AreaDto>
    {
        public AreaDto Resolve(AvailableLeague source, LeagueDto destination, AreaDto destMember, ResolutionContext context)
        {
            return new AreaDto
            {
                Name = source.LeagueCountryName
            };
        }
    }
}
