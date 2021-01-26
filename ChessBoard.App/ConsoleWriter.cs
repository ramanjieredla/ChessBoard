using ChessBoard.App.Interfaces;
using System;

namespace ChessBoard.App
{
    public class ConsoleWriter : IConsoleWriter
    {

        public void WriteHeader()
        {
            Console.WriteLine();
            Console.WriteLine(" Welcome to Chessboard!");
            Console.WriteLine();
            Console.WriteLine(" info: Reach other side of the board while avoiding the mines");
            Console.WriteLine("       Press Enter to reset, or Escape to exit");
        }

        public void DrawChessBoardGrid(IBox[,] boxes, IBox currentBox, IBox finalBox)
        {
            Console.CursorVisible = false;

            var width = boxes.GetLength(0);
            var height = boxes.GetLength(1) - 1;

            Console.WriteLine();
            Console.WriteLine();

            for (var y = height; y >= 0; y--)
            {
                Console.Write("  ");
                Console.Write(boxes[0, y].GetYLabelName());
                Console.Write("  ");
                for (var x = 0; x < width; x++)
                {
                    if (boxes[x, y] == currentBox)
                        Console.Write("[x]");
                    else if (boxes[x, y] == finalBox)
                        Console.Write("[o]");
                    else
                        Console.Write("[ ]");
                }
                Console.WriteLine();
            }

            Console.Write("      ");

            for (var x = 0; x < width; x++)
            {
                Console.Write(boxes[x, 0].GetXLabelName());
                Console.Write("  ");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        public void WriteCurrentPosition(IBox currentBox)
        {
            Console.WriteLine($" Current position: {currentBox.GetId()}");
        }

        public void WtiteMovesTaken(int movesTaken)
        {
            Console.WriteLine($" Moves taken: {movesTaken}");
        }


        public void WriteHitByMine()
        {
            Console.WriteLine(" **You've been hit by a mine!**");
        }

        public void WriteLivesLeft(int livesLeft)
        {
            Console.WriteLine($" Lives left: {livesLeft}");
        }

      


        public void Clear()
        {
            Console.Clear();
        }

        public void WriteFinalScore(int score)
        {
            Clear();
            Console.WriteLine();
            Console.WriteLine(" GREAT! You have reached to the end of the game with lives left");
            Console.WriteLine($" Final Score (number of moves taken): {score}");
            Console.WriteLine(" Press Enter to reset and play again, or Escape to exit");
        }


        public void WriteEndOfGame()
        {
            Clear();
            Console.WriteLine();
            Console.WriteLine(" You have run out of lives!");
            Console.WriteLine(" Press Enter to reset and play again, or Escape to exit");
        }
    }
}