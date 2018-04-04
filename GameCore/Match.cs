using System;
using System.Collections.Generic;
using GameCore.Interfaces;

namespace GameCore
{
    public class Match
    {
        private string _id;
        private Types.MOVE_TYPES _moveType;
        private IPlayer _player1 = null;
        private IPlayer _player2 = null;
        private Dictionary<string, int> _scores = new Dictionary<string, int>();
        private List<Game> _games = new List<Game>();
        private bool _complete = false;
        private bool _over = false;
        private string _winner = null;

        public string Id { get => _id; }
        public Types.MOVE_TYPES MoveType { get => _moveType; }
        public IPlayer Player1 { get => _player1; }
        public IPlayer Player2 { get => _player2; }
        public Dictionary<string, int> Scores { get => _scores; }
        public List<Game> Games { get => _games; set => _games = value; }
        public bool Complete { get => _complete; }
        public bool Over { get => _over; }
        public string Winner { get => _winner; }

        public Match(Types.MOVE_TYPES moveType)
        {
            _id = Guid.NewGuid().ToString();
            _moveType = moveType;
        }

        public void AddNewPlayer(IPlayer player)
        {
            if (player == null)
            {
                return;
            }
            if (Player1 != null && Player2 != null)
            {
                throw new Exception("Maximum number of players reached!");
            }
            if (Player1 != null && Player1.Id == player.Id)
            {
                return;
            }
            if (Player1 == null)
            {
                _player1 = player;
            }
            else
            {
                _player2 = player;
                _complete = true;
            }
            Scores[player.Id] = 0;
        }
        /*
        public void AddNewPlayer(Types.PLAYER_TYPES playerType)
        {
            if (playerType != Types.PLAYER_TYPES.Human)
            {
                AddNewPlayer(PlayerFactory.CreatePlayerFromType(playerType));
            }
        }

        public void AddNewPlayer(string playerType)
        {
            if (playerType != "human")
            {
                AddNewPlayer(PlayerFactory.CreatePlayerFromType(playerType));
            }
        }
        */
        public void AddNewGame(Game game)
        {
            if (!game.Finished)
            {
                throw new Exception("A game must be finished so it can be added to the match.");
            }
            if (Over)
            {
                throw new Exception("This match is over!");
            }
            Games.Add(game);
            if (!string.IsNullOrEmpty(game.Winner))
            {
                Scores[game.Winner]++;
                if (Scores[game.Winner] > Constants.NUMBER_OF_GAMES / 2)
                {
                    _over = true;
                }
            }
            if (Games.Count>= Constants.NUMBER_OF_GAMES)
            {
                _over = true;
            }
            if (_over)
            {

                if (Scores[Player1.Id] > Scores[Player2.Id])
                {
                    _winner = Player1.Id;
                }
                else if (Scores[Player1.Id] < Scores[Player2.Id])
                {
                    _winner = Player2.Id;
                }
            }
        }
    }
}
