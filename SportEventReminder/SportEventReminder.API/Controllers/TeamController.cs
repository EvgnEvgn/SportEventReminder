using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportEventReminder.DTO;
using SportEventReminder.Managers.TeamManager;

namespace SportEventReminder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamManager _teamManager;

        public TeamController(ITeamManager teamManager)
        {
            _teamManager = teamManager;
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<TeamDto>> Get(int id)
        {
            var teamDto = await _teamManager.GetById(id);
            if (teamDto == null)
            {
                return BadRequest();
            }

            return teamDto;
        }
    }
}