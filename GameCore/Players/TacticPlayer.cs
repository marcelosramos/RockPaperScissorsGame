using System;
using GameCore.Factories;
using GameCore.Interfaces;
using GameCore.Moves;

namespace GameCore.Players
{
    public class TacticPlayer : IComputerPlayer
    {
        private string _id;
        private int _nextMove = -1;

        public string Id { get => _id; }
        public Types.PLAYER_TYPES Type { get => Types.PLAYER_TYPES.Tactic; }
        public bool AutoPlay { get => true; }

        public TacticPlayer()
        {
            _id = Guid.NewGuid().ToString();
        }

        public TacticPlayer(string id)
        {
            _id = id;
        }

        public IMoves MakeNewMove(Types.MOVE_TYPES moveType)
        {
            int currentMove = _nextMove;
            if (_nextMove == -1)
            {
                MakeFirstMove(moveType);
                currentMove = _nextMove;
            }
            _nextMove = ComputeNextMove(moveType, currentMove);
            IMoves move = MovesFactory.CreateMovesFromType(moveType);
            move.SetValue(currentMove);
            return move;
        }

        private void MakeFirstMove(Types.MOVE_TYPES moveType)
        {
            Random rnd = new Random();
            IMoves move = MovesFactory.CreateMovesFromType(moveType);
            _nextMove = rnd.Next(move.GetAllowedMoves().Count);
        }

        private int ComputeNextMove(Types.MOVE_TYPES moveType, int currentMove)
        {
            currentMove++;
            IMoves move = MovesFactory.CreateMovesFromType(moveType);
            if (currentMove >= move.GetAllowedMoves().Count)
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
