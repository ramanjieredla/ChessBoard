using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard.App.Interfaces
{
    public interface IStriker
    {
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void ReduceLives(int numberOfLives);
        int GetMovesTaken();
        bool Alive();
        void Reset();
        bool Finished();
    }
}
