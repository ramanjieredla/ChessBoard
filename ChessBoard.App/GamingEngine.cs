using ChessBoard.App.Interfaces;
using System;

namespace ChessBoard.App
{
    public class GamingEngine : IGamingEngine
    {
       
        public void End()
        {
            var input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.Enter:
                    {
                        Initialise();
                        break;
                    }
                case ConsoleKey.Escape: { return; }
                default: { End(); break; }
            }
        }

        public void Start(IBoard board, IStriker striker)
        {
            board.Initialize(8, 8);

            while (striker.Alive() && !striker.Finished())
            {
                var input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            striker.MoveUp();
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            striker.MoveDown();
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                        {
                            striker.MoveLeft();
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            striker.MoveRight();
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            board.Initialize(8, 8);
                            striker.Reset();
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            return;
                        }
                }
            }

            End();
        }
        internal void Initialise()
        {
            var consoleWriter = new ConsoleWriter();
            var board = new Board(consoleWriter);
            Start(board, new Striker(board, consoleWriter));
        }

    }
}
