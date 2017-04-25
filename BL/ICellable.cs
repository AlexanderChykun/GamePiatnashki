using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface ICellable
    {
        bool GetEmptyNeighborCell ( Coordinates coord );
        int ColPosEmpty { get; }
        int RowPosEmpty { get; }
        bool IsWinGame ( int size ); 
        void SwichCells ( MyCell cell );
        
    }
}
