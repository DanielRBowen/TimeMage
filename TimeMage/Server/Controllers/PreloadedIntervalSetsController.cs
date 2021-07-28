using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using TimeMage.Shared;

namespace TimeMage.Server.Controllers
{
    [Route("PreloadedIntervalSets")]
    [ApiController]
    public class PreloadedIntervalSetsController : ControllerBase
    {
        [HttpGet("GetPreloadedIntervalSets")]
        public IActionResult GetPreloadedIntervalSets()
        {
            try
            {
                var preloadedIntervalSetsString = System.IO.File.ReadAllText("IntervalSets.json");
                var preloadedIntervalSets = System.Text.Json.JsonSerializer.Deserialize<List<IntervalSet>>(preloadedIntervalSetsString);
                return Ok(preloadedIntervalSets);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
