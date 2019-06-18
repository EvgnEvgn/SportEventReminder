using AutoMapper;
using SportEventReminder.DTO;
using SportEventReminder.Common.Configuration;

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
