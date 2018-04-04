using System.Collections.Generic;
using GameCore;
using GameCore.Moves;

namespace MatchManagerApi.Interfaces
{
    public interface IMatchManagerService
    {
        Match NextMatch { get; }
        Dictionary<string, Match> Matches { get; }
        Dictionary<string, Game> CurrentGames { get; }
        Types.MOVE_TYPES MoveType { get; }
        Match AddPlayerToMatch(string playerId, string opponentType);
        bool AddMove(string matchId, string playerId, string move);
        void RemoveMatch(string matchId);
        List<MoveSet> GetAllowedMoves();
    }
}
