using ChessBoard.App;
using ChessBoard.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard.Test.Mocks
{
    public class MockBoard : IBoard
    {
        private IBox[,] _boxes;
        private IBox _currentBox;
        private IBox _finalBox;
        private int _width;
        private int _height;


        public IBox[,] GenerateBoxes(int boardWidth, int boardHeight, int startPosX = 0)
        {
            return new Box[0, 0];
        }

        public IBox GetActiveBox()
        {
            return new Box(0, 0);
        }


        public void SetActiveBox(int xPos, int yPos)
        {

        }


        public bool MoveBoxDown()
        {
            return true;
        }

        public bool MoveBoxLeft()
        {
            return true;
        }

        public bool MoveBoxRight()
        {
            return true;
        }

        public bool MoveBoxUp()
        {
            return true;
        }

        public void Initialize(int width, int height)
        {
            _width = width;
            _height = height;
            _boxes = new Box[_width, _height];
            _currentBox = new FinalBox(0, 0);
            _finalBox = new FinalBox(width == 0 ? 0 : 1, 0);
        }

        public IBox GenerateFinalBox(int endPosX, int boardHeight)
        {
            return new Box(0, 0);
        }

        public IBox GetFinalBox()
        {
            return new Box(0, 0);
        }
    }
}
