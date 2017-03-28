using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface ICellable
    {
        void SearchEmptyCell ();
        bool GetEmptyNeighborCell ( int posX, int posY );
        bool IsWinGame ( int size );
        int ColPosEmpty{get;}
        int RowPosEmpty { get; }
    }
}
