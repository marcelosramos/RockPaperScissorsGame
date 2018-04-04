namespace GameCore.Interfaces
{
    public interface IMove
    {
        Types.MOVES Value { get; }
        int Beats(IMove move);
        int Beats(string value);
        int Beats(Types.MOVES value);
    }
}
