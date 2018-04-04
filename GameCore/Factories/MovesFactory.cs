using GameCore.Interfaces;
using GameCore.Moves;
using GameCore.Players;

namespace GameCore.Factories
{
    public abstract class MovesFactory
    {
        public static IMoves CreateMoves<T>() where T : IMoves, new()
        {
            return new T();
        }
        public static IMoves CreateMovesFromType(Types.MOVE_TYPES moveType)
        {
            switch (moveType)
            {
                case Types.MOVE_TYPES.Default:
                    return CreateMoves<DefaultMoves>();
                default:
                    return null;
            }
        }
        public static IMoves CreateMovesFromType(string moveType)
        {
            switch (moveType)
            {
                case "default":
                    return CreateMovesFromType(Types.MOVE_TYPES.Default);
                default:
                    return null;
            }
        }
        public static IMoves CreateMovesFromType(string moveType, string value)
        {
            IMoves moves = CreateMovesFromType(moveType);
            moves.SetValue(value);
            return moves;
        }
        public static IMoves CreateMovesFromType(Types.MOVE_TYPES moveType, string value)
        {
            IMoves moves = CreateMovesFromType(moveType);
            moves.SetValue(value);
            return moves;
        }
    }
}



