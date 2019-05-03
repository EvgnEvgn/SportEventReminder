using System.Collections.Generic;
using System.Threading.Tasks;
using SportEventReminder.DTO;

namespace SportEventReminder.ImportService.Interfaces
{
    public interface IFootballImporter
    {
        Task<List<AreaDto>> GetAreasAsync();
    }
}
