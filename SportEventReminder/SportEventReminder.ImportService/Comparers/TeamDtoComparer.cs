using System.Collections.Generic;
using SportEventReminder.DTO;

namespace SportEventReminder.ImportService.Comparers
{
    public class TeamDtoComparer : IEqualityComparer<TeamDto>
    {
        public bool Equals(TeamDto x, TeamDto y)
        {
            return x.ExternalId == y.ExternalId;
        }

        public int GetHashCode(TeamDto obj)
        {
            return (obj.Name + obj.ExternalId).GetHashCode();
        }
    }
}
