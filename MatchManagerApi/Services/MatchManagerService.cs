using System.Collections.Generic;
using GameCore;
using GameCore.Interfaces;
using GameCore.Factories;
using GameCore.Players;
using MatchManagerApi.Interfaces;

namespace MatchManagerApi.Services
{
    public class MatchManagerService: IMatchManagerService
    {
        public Match NextMatch { get; private set; }
        public Dictionary<string, Match> Matches { get; private set; }
        public Dictionary<string, Game> CurrentGames { get; private set; }

        public MatchManagerService()
        {
            NextMatch = new Match();
            Matches = new Dictionary<string, Match>();
            CurrentGames = new Dictionary<string, Game>();
        }

        public Match AddPlayerToMatch(string playerId, string opponentType)
        {
            Match match = NextMatch;
            IPlayer player = new HumanPlayer(playerId);
            NextMatch.AddNewPlayer(player);
            IPlayer opponent = PlayerFactory.CreatePlayerFromType(opponentType);
            if (opponent != null && opponent.AutoPlay)
            {
                NextMatch.AddNewPlayer(opponent);
            }
            if (NextMatch.Complete)
            {
                Matches[NextMatch.Id] = NextMatch;
                NextMatch = new Match();
            }
            return match;
        }

        public bool AddMove(string matchId, string playerId, string move)
        {
            Match match = Matches[matchId];
            IPlayer player = match.Player1.Id == playerId ? match.Player1 : match.Player2;
            Game game;
            if (CurrentGames.ContainsKey(matchId) && CurrentGames[matchId] != null)
            {
                game = CurrentGames[matchId];
            }
            else
            {
                game = new Game(match);
                CurrentGames[matchId] = game;
            }
            if (game.AddMove(player, move))
            {
                match.AddNewGame(game);
                CurrentGames[matchId] = null;
                return true;
            }

            return false;
        }

        public void RemoveMatch(string matchId)
        {
            Matches[matchId] = null;
            CurrentGames[matchId] = null;
        }
    }

}
