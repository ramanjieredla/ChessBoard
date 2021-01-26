using ChessBoard.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard.App
{
    public class Board : IBoard
    {
        private IConsoleWriter _consoleWriter;
        private IBox[,] _boxes;
        private IBox _currentBox;
        private IBox _finalBox;
        private Dictionary<int, string> _boardLabels;
        private int _boardWidth;
        private int _boardHeight;
        private const int _randomNumberMatch = 6;
        private const int _startPositionY = 0;


        public Board(IConsoleWriter consoleWriter)
        {
            this._consoleWriter = consoleWriter;

        }
        public IBox[,] GenerateBoxes(int boardWidth, int boardHeight, int startPositionX = 0)
        {
            var boxes = new IBox[boardWidth, boardHeight];

            if (_boardLabels == null) GenerateBoardLabelMap();

            for (var x = 0; x < boardWidth; x++)
            {
                for (var y = 0; y < boardHeight; y++)
                {
                    //Allocate mines randomly
                    var rolledMine = GetRandomNumber(1, _randomNumberMatch + 1) == _randomNumberMatch ? true : false;

                    if (x == startPositionX & y == _startPositionY || !rolledMine)
                    {
                        boxes[x, y] = new Box(x, y, _boardLabels[x]);
                    }
                    else
                    {
                        boxes[x, y] = new MineBox(x, y, _boardLabels[x]);
                    }
                }
            }

            return boxes;
        }

        public IBox GenerateFinalBox(int endPosX, int boardHeight)
        {
            if (_boardLabels == null) GenerateBoardLabelMap();

            return new FinalBox(endPosX, boardHeight - 1, _boardLabels[endPosX]);

        }

        public IBox GetActiveBox()
        {
            return _currentBox;
        }

        public IBox GetFinalBox()
        {
            return _finalBox;
        }

        public void Initialize(int width, int height)
        {
            _boardWidth = width;
            _boardHeight = height;

            var startPositionX = GetRandomNumber(0, _boardWidth);
            var endPositionX = GetRandomNumber(0, _boardWidth);
            var endPositionY = height - 1;

            _boxes = GenerateBoxes(_boardWidth, _boardHeight, startPositionX);

            //Set start tile
            _currentBox = _boxes[startPositionX, _startPositionY];

            //Set end tile
            _finalBox = GenerateFinalBox(endPositionX, _boardHeight);
            _boxes[endPositionX, endPositionY] = _finalBox;

            Redraw();
        }

        public void Redraw()
        {
            _consoleWriter.Clear();
            _consoleWriter.WriteHeader();
            _consoleWriter.DrawChessBoardGrid(_boxes, _currentBox, _finalBox);
            _consoleWriter.WriteCurrentPosition(_currentBox);
        }

        public void SetActiveBox(int xPos, int yPos)
        {
            _currentBox = _boxes[xPos, yPos];
        }

        public bool MoveBoxDown()
        {
            if (_currentBox.GetYPosition() > 0)
            {
                _currentBox = _boxes[_currentBox.GetXPosition(), _currentBox.GetYPosition() - 1];
                Redraw();
                return true;
            }
            return false;
        }

        public bool MoveBoxLeft()
        {
            if (_currentBox.GetXPosition() > 0)
            {
                _currentBox = _boxes[_currentBox.GetXPosition() - 1, _currentBox.GetYPosition()];
                Redraw();
                return true;
            }
            return false;
        }

        public bool MoveBoxRight()
        {
            if (_currentBox.GetXPosition() < _boardWidth - 1)
            {
                _currentBox = _boxes[_currentBox.GetXPosition() + 1, _currentBox.GetYPosition()];
                Redraw();
                return true;
            }
            return false;
        }

        public bool MoveBoxUp()
        {
            if (_currentBox.GetYPosition() < _boardHeight - 1)
            {
                _currentBox = _boxes[_currentBox.GetXPosition(), _currentBox.GetYPosition() + 1];
                Redraw();
                return true;
            }
            return false;
        }

        private void GenerateBoardLabelMap()
        {
            _boardLabels = new Dictionary<int, string>()
            {
                { 0, "A"}, { 1, "B"}, { 2, "C"}, { 3, "D"},
                { 4, "E"}, { 5, "F"}, { 6, "G"}, { 7, "H"},
                { 8, "I"}, { 9, "J"}, { 10, "K"}, { 11, "L"},
                { 12, "M"}, { 13, "N"}, { 14, "O"}, { 15, "P"},
                { 16, "Q"}, { 17, "R"}, { 18, "S"}, { 19, "T"},
                { 20, "U"}, { 21, "V"}, { 22, "W"}, { 23, "X"},
                { 24, "Y"}, { 25, "Z"}
            };
        }

        private int GetRandomNumber(int min = 0, int max = 0)
        {
            return new Random().Next(min, max);
        }
    }
}
