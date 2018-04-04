using Microsoft.AspNetCore.Mvc;
using GameCore;
using GameCore.Factories;
using GameCore.Players;

namespace MatchManagerApi.Controllers
{
    [Route("api/player")]
    public class PlayerController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Json(Types.GetPlayerTypes());
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Json(PlayerFactory.CreatePlayer<HumanPlayer>());
        }
    }
}
