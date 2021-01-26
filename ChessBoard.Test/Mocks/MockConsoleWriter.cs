using ChessBoard.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard.Test.Mocks
{
    public class MockConsoleWriter : IConsoleWriter
    {
        public void Clear()
        {
            
        }

        public void DrawChessBoardGrid(IBox[,] boxes, IBox currentBox, IBox finalBox)
        {
            
        }

        public void WriteCurrentPosition(IBox currentBox)
        {
            
        }

        public void WriteEndOfGame()
        {
            
        }

        public void WriteFinalScore(int score)
        {
            
        }

        public void WriteHeader()
        {
            
        }

        public void WriteHitByMine()
        {
            
        }

        public void WriteLivesLeft(int livesLeft)
        {
            
        }

        public void WtiteMovesTaken(int movesTaken)
        {
            
        }
    }
}
