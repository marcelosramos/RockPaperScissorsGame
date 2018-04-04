using GameCore.Interfaces;
using GameCore.Players;

namespace GameCore.Factories
{
    public abstract class PlayerFactory
    {
        public static IPlayer CreatePlayer<T>() where T : IPlayer, new()
        {
            return new T();
        }
        public static IPlayer CreatePlayerFromType(Types.PLAYER_TYPES playerType)
        {
            switch (playerType)
            {
                case Types.PLAYER_TYPES.Human:
                    return CreatePlayer<HumanPlayer>();
                case Types.PLAYER_TYPES.Random:
                    return CreatePlayer<RandomPlayer>();
                case Types.PLAYER_TYPES.Tactic:
                    return CreatePlayer<TacticPlayer>();
                default:
                    return null;
            }
        }
        public static IPlayer CreatePlayerFromType(string playerType)
        {
            switch (playerType)
            {
                case "human":
                    return CreatePlayerFromType(Types.PLAYER_TYPES.Human);
                case "random":
                    return CreatePlayerFromType(Types.PLAYER_TYPES.Random);
                case "tactic":
                    return CreatePlayerFromType(Types.PLAYER_TYPES.Tactic);
                default:
                    return null;
            }
        }
    }
}



