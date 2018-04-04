using System.Collections.Generic;
using GameCore;
using GameCore.Interfaces;
using GameCore.Factories;
using GameCore.Players;
using MatchManagerApi.Interfaces;
using GameCore.Moves;

namespace MatchManagerApi.Services
{
    public class MatchManagerService: IMatchManagerService
    {
        public Match NextMatch { get; private set; }
        public Dictionary<string, Match> Matches { get; private set; }
        public Dictionary<string, Game> CurrentGames { get; private set; }
        public Types.MOVE_TYPES MoveType { get; private set; }

        public MatchManagerService(Types.MOVE_TYPES moveType)
        {
            Matches = new Dictionary<string, Match>();
            CurrentGames = new Dictionary<string, Game>();
            MoveType = moveType;
        }
        
        public Match AddPlayerToMatch(string playerId, string opponentType)
        {
            if (NextMatch == null)
            {
                NextMatch = new Match(MoveType);
            }
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
                //Lets take care not to flood the memory
                if (Matches.Count > 100)
                {
                    Matches = new Dictionary<string, Match>();
                }
                Matches[NextMatch.Id] = NextMatch;
                NextMatch = new Match(MoveType);
            }
            return match;
        }

        public bool AddMove(string matchId, string playerId, string moveValue)
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
            IMoves move = MovesFactory.CreateMovesFromType(MoveType);
            move.SetValue(moveValue);
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

        public List<MoveSet> GetAllowedMoves()
        {
            IMoves move = MovesFactory.CreateMovesFromType(MoveType);
            return move.GetAllowedMoves();
        }
    }

}
