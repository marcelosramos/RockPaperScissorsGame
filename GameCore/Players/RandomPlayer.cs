using System;
using GameCore.Interfaces;
using GameCore.Moves;

namespace GameCore.Players
{
    public class RandomPlayer : IComputerPlayer
    {
        private string _id;

        public string Id { get => _id; }
        public Types.PLAYER_TYPES Type { get => Types.PLAYER_TYPES.Random; }
        public bool AutoPlay { get => true; }

        public RandomPlayer()
        {
            _id = Guid.NewGuid().ToString();
        }

        public RandomPlayer(string id)
        {
            _id = id;
        }

        public IMove MakeNewMove()
        {
            Random rnd = new Random();
            int _nextMove = rnd.Next(Types.GetAllowedMoves().Count);
            return new Move((Types.MOVES)_nextMove);
        }

    }
}
