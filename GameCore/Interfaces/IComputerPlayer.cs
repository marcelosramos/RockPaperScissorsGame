namespace GameCore.Interfaces
{
    public interface IComputerPlayer : IPlayer
    {
        IMove MakeNewMove();
    }
}
