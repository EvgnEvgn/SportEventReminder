using System.Collections.Generic;
using System.Threading.Tasks;
using SportEventReminder.DTO;

namespace SportEventReminder.Managers.MatchManager
{
    public interface IMatchManager
    {
        Task AddOrUpdate(List<MatchDto> matchesDto);
    }
}
