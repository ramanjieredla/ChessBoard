using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard.App.Interfaces
{
    public interface IBoard
    {
        void Initialize(int width, int height);
        IBox[,] GenerateBoxes(int boardWidth, int boardHeight, int startPositionX = 0);
        IBox GenerateFinalBox(int endPosX, int boardHeight);
        bool MoveBoxUp();
        bool MoveBoxDown();
        bool MoveBoxLeft();
        bool MoveBoxRight();
        void SetActiveBox(int xPos, int yPos);
        IBox GetActiveBox();
        IBox GetFinalBox();
    }
}
