using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportEventReminder.DTO;
using SportEventReminder.Managers.MatchManager;

namespace SportEventReminder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchManager _matchManager;

        public MatchesController(IMatchManager matchManager)
        {
            _matchManager = matchManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<MatchDto>>> Get()
        {
            var matches = await _matchManager.GetScheduledMatchesAsync();

            if (matches == null || !matches.Any())
            {
                return BadRequest();
            }

            return matches;
        }
    }
}