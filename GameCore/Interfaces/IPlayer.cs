namespace GameCore.Interfaces
{
    public interface IPlayer
    {
        string Id { get; }
        Types.PLAYER_TYPES Type { get; }
        bool AutoPlay { get; }
    }
}
