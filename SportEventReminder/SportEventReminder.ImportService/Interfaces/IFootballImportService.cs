using System.Threading.Tasks;

namespace SportEventReminder.ImportService.Interfaces
{
    public interface IFootballImportService
    {
        Task UpdateAreas();
        Task UpdateLeagues();
        Task UpdateTeams();
        Task UpdateMatches();
    }
}
