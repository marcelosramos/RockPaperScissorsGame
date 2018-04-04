using Microsoft.AspNetCore.Mvc;
using GameCore;

namespace MatchManagerApi.Controllers
{
    [Route("api/Moves")]
    public class MovesController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Json(Types.GetAllowedMoves());
        }
    }
}
