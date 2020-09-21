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
    public class TeamsController : ControllerBase
    {
        private readonly ITeamManager _teamManager;
        private int i = 120;
        public TeamsController(ITeamManager teamManager)
        {
            _teamManager = teamManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<TeamDto>>> Get()
        {
            var teams = await _teamManager.GetAllAsync();
            if (teams == null)
            {
                return BadRequest();
            }

            return teams;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamDto>> Get(int id)
        {
            var teamDto = await _teamManager.GetByIdAsync(id);
            if (teamDto == null)
            {
                return BadRequest();
            }

            return teamDto;
        }
    }
}