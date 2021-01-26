using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard.App.Interfaces
{
    public interface IBox
    {
        void Initialize(IStriker striker, IConsoleWriter renderer);

        string GetId();

        string GetXLabelName();

        string GetYLabelName();

        int GetXPosition();

        int GetYPosition();
        
    }
}
