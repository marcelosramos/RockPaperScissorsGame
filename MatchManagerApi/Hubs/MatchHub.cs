using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using GameCore;
using MatchManagerApi.Interfaces;

namespace MatchManagerApi.Hubs
{
    public class MatchHub : Hub
    {
        private readonly IMatchManagerService _matchManager;

        public MatchHub(IMatchManagerService matchManager)
        {
            _matchManager = matchManager;
        }

        public async Task NewMatch(string matchId)
        {
            await Clients.All.SendAsync(matchId, _matchManager.Matches[matchId], "");
        }

        public async Task NewMove(string matchId, string playerId, string move)
        {
            Match match = _matchManager.Matches[matchId];
            if (_matchManager.AddMove(matchId, playerId, move))
            {
                await Clients.All.SendAsync(matchId, match, "");
                if (match.Over)
                {
                    _matchManager.RemoveMatch(match.Id);
                }
            }
            else
            {
                await Clients.All.SendAsync(matchId, match, playerId);
            }
        }
    }
}
