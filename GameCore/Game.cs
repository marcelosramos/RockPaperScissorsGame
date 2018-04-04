using System;
using GameCore.Interfaces;
using GameCore.Moves;

namespace GameCore
{
    public class Game
    {
        private string _id;
        private IPlayer _player1 = null;
        private IPlayer _player2 = null;
        private IMove _player1Move;
        private IMove _player2Move;
        private string _winner = null;
        private bool _finished;

        public string Id { get => _id; }
        public IPlayer Player1 { get => _player1; }
        public IPlayer Player2 { get => _player2; }
        public IMove Player1Move { get => _player1Move; }
        public IMove Player2Move { get => _player2Move; }
        public string Winner { get => _winner; }
        public bool Finished { get => _finished; }

        public Game(IPlayer player1, IPlayer player2)
        {
            _id = Guid.NewGuid().ToString();
            _player1 = player1;
            _player2 = player2;
            _finished = false;
        }

        public Game(Match match)
        {
            _id = Guid.NewGuid().ToString();
            _player1 = match.Player1;
            _player2 = match.Player2;
            _finished = false;
        }

        /// <summary>
        /// Add a move to the game
        /// </summary>
        /// <param name="_player"></param>
        /// <param name="_move"></param>
        /// <returns>True if the game is finished (has the two players moves).</returns>
        public bool AddMove(IPlayer player, IMove move)
        {
            if (player.Id == Player1.Id)
            {
                _player1Move = move;
                if (Player2.AutoPlay)
                {
                    _player2Move = ((IComputerPlayer)Player2).MakeNewMove();
                }
            }
            else if (player.Id == Player2.Id)
            {
                _player2Move = move;

                if (Player1.AutoPlay)
                {
                    _player1Move = ((IComputerPlayer)Player1).MakeNewMove();
                }
            }
            else
            {
                throw new Exception("Invalida player ID!");
            }
            if (Player1Move != null && Player2Move != null)
            {
                FinishGame();
            }
            return Finished;
        }

        /// <summary>
        /// Add a move to the game
        /// </summary>
        /// <param name="_player"></param>
        /// <param name="_move"></param>
        /// <returns>True if the game is finished (has the two players moves).</returns>
        public bool AddMove(IPlayer player, string move)
        {
            return AddMove(player, new Move(move));
        }

        private void FinishGame()
        {
            int gameResult = Player1Move.Beats(Player2Move);
            if (gameResult > 0)
            {
                _winner = gameResult == 1 ? Player1.Id : Player2.Id;
            }
            else
            {
                _winner = "";
            }
            _finished = true;
        }

    }
}
