using System.Collections.Generic;
using System.Threading.Tasks;
using SportEventReminder.DTO;

namespace SportEventReminder.Managers.AreaManager
{
    public interface IAreaManager
    {
        Task AddOrUpdate(List<AreaDto> areasDto);
    }
}
