using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportEventReminder.DTO;
using SportEventReminder.Managers.AreaManager;

namespace SportEventReminder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly IAreaManager _areaManager;

        public AreasController(IAreaManager areaManager)
        {
            _areaManager = areaManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<AreaDto>>> Get()
        {
            var areas = await _areaManager.GetAllAsync();

            if (areas == null)
            {
                return BadRequest();
            }

            return areas;
        }
    }
}