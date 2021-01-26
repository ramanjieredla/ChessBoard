namespace ChessBoard.App.Interfaces
{
    public interface IGamingEngine
    {
        void Start(IBoard board, IStriker striker);

        void End();
    }
}
