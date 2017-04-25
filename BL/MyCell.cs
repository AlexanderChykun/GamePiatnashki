using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class MyCell: Cell<int>
    {

        public bool isChoosed = false;
        public bool isMoved = false;
        /// <summary>
        /// Конструктор фишки
        /// </summary>
        /// <param name="c">Интерфейсная ссылка</param>
        /// <param name="num">номер фишки</param>
        /// <param name="coord">координаты фишки</param>
        public MyCell (ICellable c, int num,Coordinates coord): base(c,num,coord)
        {
            
        }
        /// <summary>
        /// Переопределенный метод перемещение фишки 
        /// </summary>
        public override void Move (  )
        {
            if ( _c.GetEmptyNeighborCell ( Coord ) )
            {
                _c.SwichCells ( this );
                isMoved = true;
                isChoosed = false;
            }
        }
    }
}
