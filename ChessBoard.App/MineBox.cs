using ChessBoard.App.Interfaces;

namespace ChessBoard.App
{
    public class MineBox : Box
    {
        public MineBox(int x, int y, string _xLabel = null, string _yLabel = null) : base(x, y, _xLabel, _yLabel)
        {
        }

        public override void Initialize(IStriker striker, IConsoleWriter consoleWriter)
        {
            striker.ReduceLives(1);
            consoleWriter.WriteHitByMine();
        }
    }
}
