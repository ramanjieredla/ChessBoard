using ChessBoard.App.Interfaces;

namespace ChessBoard.App
{
    public class FinalBox : Box
    {
        public FinalBox(int x, int y, string xLabel = null, string yLabel = null) : base(x, y, xLabel, yLabel)
        {
        }

        public override void Initialize(IStriker striker, IConsoleWriter consoleWriter)
        {
            consoleWriter.WriteFinalScore(striker.GetMovesTaken());
        }
    }
}
