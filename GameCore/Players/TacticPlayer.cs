using System;
using GameCore.Interfaces;
using GameCore.Moves;

namespace GameCore.Players
{
    public class TacticPlayer : IComputerPlayer
    {
        private string _id;
        private int _nextMove;

        public string Id { get => _id; }
        public Types.PLAYER_TYPES Type { get => Types.PLAYER_TYPES.Tactic; }
        public bool AutoPlay { get => true; }

        public TacticPlayer()
        {
            _id = Guid.NewGuid().ToString();
            MakeFirstMove();
        }

        public TacticPlayer(string id)
        {
            _id = id;
            MakeFirstMove();
        }

        public IMove MakeNewMove()
        {
            int currentMove = _nextMove;
            _nextMove = ComputeNextMove(currentMove);
            return new Move((Types.MOVES)currentMove);
        }

        private void MakeFirstMove()
        {
            Random rnd = new Random();
            _nextMove = rnd.Next(Types.GetAllowedMoves().Count);
        }

        private int ComputeNextMove(int currentMove)
        {
            currentMove++;
            if (currentMove >= Types.GetAllowedMoves().Count)
            {
                return 0;
            }
            else
            {
                return currentMove;
            }
        }
    }
}
