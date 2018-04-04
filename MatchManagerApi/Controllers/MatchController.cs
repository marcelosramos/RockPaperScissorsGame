using Microsoft.AspNetCore.Mvc;
using MatchManagerApi.Interfaces;
using MatchManagerApi.Models;

namespace MatchManagerApi.Controllers
{
    [Route("api/match")]
    public class MatchController : Controller
    {
        private readonly IMatchManagerService _matchManager;

        public MatchController(IMatchManagerService matchManager)
        {
            _matchManager = matchManager;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]MatchPostRequestModel model)
        {
            return Json(_matchManager.AddPlayerToMatch(model.PlayerId, model.OpponentType));
        }

    }
}
