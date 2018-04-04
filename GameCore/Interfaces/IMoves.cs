using GameCore.Moves;
using System.Collections.Generic;

namespace GameCore.Interfaces
{
    public interface IMoves
    {
        MoveSet Move { get; }
        void SetValue(string value);
        void SetValue(int value);
        int Beats(IMoves move);
        int Beats(string value);
        MoveSet GetMove(int value);
        MoveSet GetMove(string value);
        List<MoveSet> GetAllowedMoves();
    }
}
