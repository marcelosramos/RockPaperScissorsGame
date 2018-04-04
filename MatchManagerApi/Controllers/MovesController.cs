using Microsoft.AspNetCore.Mvc;
using GameCore;
using MatchManagerApi.Interfaces;

namespace MatchManagerApi.Controllers
{
    [Route("api/Moves")]
    public class MovesController : Controller
    {
        private readonly IMatchManagerService _matchManager;

        public MovesController(IMatchManagerService matchManager)
        {
            _matchManager = matchManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(_matchManager.GetAllowedMoves());
        }
    }
}
