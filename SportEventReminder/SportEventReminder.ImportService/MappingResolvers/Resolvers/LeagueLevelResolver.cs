using AutoMapper;
using SportEventReminder.Common.Enums;
using SportEventReminder.DTO;
using SportEventReminder.ImportService.Contracts.FootballDataOrgContracts;

namespace SportEventReminder.ImportService.MappingResolvers.Resolvers
{
    public class LeagueLevelResolver : IValueResolver<CompetitionContract, LeagueDto, LeagueLevel>
    {
        public LeagueLevel Resolve(CompetitionContract source, LeagueDto destination, LeagueLevel destMember,
            ResolutionContext context)
        {
            switch (source.Plan)
            {
                case "TIER_ONE":
                    return LeagueLevel.TierOne;

                case "TIER_TWO":
                    return LeagueLevel.TierTwo;

                case "TIER_THREE":
                    return LeagueLevel.TierThree;

                case "TIER_FOUR":
                    return LeagueLevel.TierFour;

                default:
                    return LeagueLevel.TierFour;
            }
        }
    }
}
