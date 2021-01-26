using ChessBoard.App.Interfaces;

namespace ChessBoard.App
{
    public class Box : IBox
    {
        private string _id;
        private int _xPos;
        private int _yPos;
        private string _xLabel;
        private string _yLabel;

        public Box(int x, int y, string xLabel = null, string yLabel = null)
        {
            _xPos = x;
            _yPos = y;

            if (xLabel != null)
                _xLabel = xLabel;
            else _xLabel = x.ToString();

            if (yLabel != null)
                _yLabel = yLabel;

            else _yLabel = (y + 1).ToString();

            _id = _xLabel + _yLabel;
        }

        public string Id { get; }
        public int GetXPosition() { return _xPos; }
        public int GetYPosition() { return _yPos; }
        public string GetXLabelName() { return _xLabel; }
        public string GetYLabelName() { return _yLabel; }
        public string GetId() { return _id; }

        public virtual void Initialize(IStriker striker, IConsoleWriter renderer)
        {

        }
    }
}
