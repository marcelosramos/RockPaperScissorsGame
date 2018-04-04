namespace GameCore.Interfaces
{
    public interface IComputerPlayer : IPlayer
    {
        IMoves MakeNewMove(Types.MOVE_TYPES moveType);
    }
}
