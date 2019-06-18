using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportEventReminder.DTO;
using SportEventReminder.Managers.LeagueManager;

namespace SportEventReminder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaguesController : ControllerBase
    {
        private readonly ILeagueManager _leagueManager;

        public LeaguesController(ILeagueManager leagueManager)
        {
            _leagueManager = leagueManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeagueDto>>> Get()
        {
            var leagues = await _leagueManager.GetAvailableLeaguesAsync();

            if (leagues == null || !leagues.Any())
            {
                return BadRequest();
            }

            return leagues;
        }
    }
}