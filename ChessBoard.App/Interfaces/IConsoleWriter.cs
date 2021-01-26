namespace ChessBoard.App.Interfaces
{
    public interface IConsoleWriter
    {
        void WriteHeader();

        void DrawChessBoardGrid(IBox[,] boxes, IBox currentBox, IBox finalBox);

              
        void WriteCurrentPosition(IBox currentBox);


        void WtiteMovesTaken(int movesTaken);

        void WriteHitByMine();

        void WriteLivesLeft(int livesLeft);


        void Clear();

        void WriteFinalScore(int score);        


        void WriteEndOfGame();
    }
}