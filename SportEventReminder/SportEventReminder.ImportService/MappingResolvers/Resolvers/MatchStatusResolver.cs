using AutoMapper;
using SportEventReminder.Common.Enums;
using SportEventReminder.DTO;
using SportEventReminder.ImportService.Contracts.FootballDataOrgContracts;

namespace SportEventReminder.ImportService.MappingResolvers.Resolvers
{
    public class MatchStatusResolver : IValueResolver<MatchContract, MatchDto, MatchStatusEnum>
    {
        public MatchStatusEnum Resolve(MatchContract source, MatchDto destination, MatchStatusEnum destMember,
            ResolutionContext context)
        {
            switch (source.Status)
            {
                case "SCHEDULED":
                    return MatchStatusEnum.Scheduled;

                case "CANCELED":
                    return MatchStatusEnum.Canceled;

                case "POSTPONED":
                    return MatchStatusEnum.Postponed;

                case "Suspended":
                    return MatchStatusEnum.Suspended;

                case "IN_PLAY":
                    return MatchStatusEnum.InPlay;

                case "PAUSED":
                    return MatchStatusEnum.Paused;

                case "FINISHED":
                    return MatchStatusEnum.Finished;

                case "AWARDED":
                    return MatchStatusEnum.Awarded;

                default:
                    return MatchStatusEnum.Scheduled;
            }
        }
    }
}
