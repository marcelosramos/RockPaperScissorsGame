using System;
using GameCore.Factories;
using GameCore.Interfaces;
using GameCore.Moves;

namespace GameCore
{
    public class Game
    {
        private string _id;
        private Types.MOVE_TYPES _moveType;
        private IPlayer _player1 = null;
        private IPlayer _player2 = null;
        private IMoves _player1Move;
        private IMoves _player2Move;
        private string _winner = null;
        private bool _finished;

        public string Id { get => _id; }
        private Types.MOVE_TYPES MoveType { get => _moveType; }
        public IPlayer Player1 { get => _player1; }
        public IPlayer Player2 { get => _player2; }
        public IMoves Player1Move { get => _player1Move; }
        public IMoves Player2Move { get => _player2Move; }
        public string Winner { get => _winner; }
        public bool Finished { get => _finished; }
        /*
        public Game(Types.MOVE_TYPES moveType, IPlayer player1, IPlayer player2)
        {
            _id = Guid.NewGuid().ToString();
            _moveType = moveType;
            _player1 = player1;
            _player2 = player2;
            _finished = false;
        }
        */
        public Game(Match match)
        {
            _id = Guid.NewGuid().ToString();
            _moveType = match.MoveType;
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
        public bool AddMove(IPlayer player, IMoves move)
        {
            if (player.Id == Player1.Id)
            {
                _player1Move = move;
                if (Player2.AutoPlay)
                {
                    _player2Move = ((IComputerPlayer)Player2).MakeNewMove(MoveType);
                }
            }
            else if (player.Id == Player2.Id)
            {
                _player2Move = move;

                if (Player1.AutoPlay)
                {
                    _player1Move = ((IComputerPlayer)Player1).MakeNewMove(MoveType);
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
        public bool AddMove(IPlayer player, Types.MOVE_TYPES moveType, string value)
        {
            IMoves move = MovesFactory.CreateMovesFromType(moveType);
            move.SetValue(value);
            return AddMove(player, move);
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
