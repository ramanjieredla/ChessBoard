using ChessBoard.App.Interfaces;

namespace ChessBoard.App
{
    public class Striker : IStriker
    {
        IBoard _board;
        IConsoleWriter _consoleWriter;
        private int _movesTaken = 0;
        private int _maxLives;
        private int _livesRemaining;

        public Striker(IBoard board, IConsoleWriter consoleWriter, int lives = 3)
        {
            _board = board;
            _consoleWriter = consoleWriter;
            _livesRemaining = lives;
            _maxLives = lives;
        }

        public void MoveUp()
        {
            if (_board.MoveBoxUp())
            {
                Move();
            }
        }

        public void MoveDown()
        {
            if (_board.MoveBoxDown())
            {
                Move();
            }
        }

        public void MoveLeft()
        {
            if (_board.MoveBoxLeft())
            {
                Move();
            }
        }

        public void MoveRight()
        {
            if (_board.MoveBoxRight())
            {
                Move();
            }
        }

        private void Move()
        {
            _movesTaken++;
            _consoleWriter.WtiteMovesTaken(_movesTaken);
            
            _board.GetActiveBox().Initialize(this, _consoleWriter);

            if (!Finished()) _consoleWriter.WriteLivesLeft(_livesRemaining);

            if (_livesRemaining == 0) _consoleWriter.WriteEndOfGame();
        }

        public void ReduceLives(int numOfLives)
        {
            _livesRemaining -= numOfLives;
        }

        public int GetMovesTaken()
        {
            return _movesTaken;
        }

        public int GetLivesLeft()
        {
            return _livesRemaining;
        }

        public bool Alive()
        {
            return _livesRemaining > 0 ? true : false;
        }

        public void Reset()
        {
            _livesRemaining = _maxLives;
            _movesTaken = 0;
        }

        public bool Finished()
        {
            return _board.GetActiveBox() == _board.GetFinalBox();
        }
    }
}
