using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public abstract class ChangeCellsOfField: ICellable
    {
        /// <summary>
        /// Поиск пустого элемента
        /// </summary>
        public void SearchEmptyCell ()
        {
            for ( int i = 0; i < _nums.GetLength ( 0 ); i++ )
            {
                for ( int j = 0; j < _nums.GetLength ( 1 ); j++ )
                {
                    if ( _nums[i, j].num == 0 )
                    {
                        _colPosEmpty = i;
                        _rowPosEmpty = j;
                    }
                }
            }
        }
        /// <summary>
        /// Смена ячеек местами
        /// </summary>
        /// <param name="cell">ячейка которую нужно сместить</param>
        public void SwichCells ( MyCell cell )
        {
            int tmp = _nums[ColPosEmpty, RowPosEmpty].num;
            _nums[ColPosEmpty, RowPosEmpty].num = _nums[cell.Coord.PosX, cell.Coord.PosY].num;
            _nums[cell.Coord.PosX, cell.Coord.PosY].num = tmp;
        }
        /// <summary>
        /// Возвращает ячейку с координатами posX, posY в массиве _nums 
        /// </summary>
        /// <param name="posX">Координата Х</param>
        /// <param name="posY">Координата Y</param>
        /// <returns></returns>
        public MyCell GetCellAt ( int posX, int posY ) 
        {
            return _nums[posX, posY];
        }
        /// <summary>
        /// Метод поиска пустого соседнего элемента
        /// Возвращает значение true если такой элемент имеется
        /// </summary>
        /// <param name="coord">Координаты текущей фишки</param>
        /// <returns></returns>
        public bool GetEmptyNeighborCell ( Coordinates coord )
        {
            if ( _nums[coord.PosX, coord.PosY].num == 0 )
            {
                return false;
            }
            if ( East ( coord.PosX, coord.PosY ).num == 0 )
            {
                SearchEmptyCell ();

                return true;
            }

            if ( West ( coord.PosX, coord.PosY ).num == 0 )
            {
                SearchEmptyCell ();
                return true;
            }

            if ( South ( coord.PosX, coord.PosY ).num == 0 )
            {
                SearchEmptyCell ();
                return true;
            }

            if ( North ( coord.PosX, coord.PosY).num == 0 )
            {
                SearchEmptyCell ();
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Возвращает ячейку на востоке от текущей
        /// </summary>
        /// <param name="posX">Координата Х</param>
        /// <param name="posY">Координата Y</param>
        /// <returns></returns>
        public MyCell East ( int posX, int posY )
        {

            if ( posY != _nums.GetLength ( 0 ) - 1 )
            {
                return GetCellAt ( posX, posY + 1 );
            }
            else
            {
                return _nums[posX, posY];
            }
        }
        /// <summary>
        /// Возвращает ячейку на севере от текущей
        /// </summary>
        /// <param name="posX">Координата Х</param>
        /// <param name="posY">Координата Y</param>
        /// <returns></returns>
        public MyCell North ( int posX, int posY ) 
        {
            if ( posX != 0 )
            {
                return GetCellAt ( posX - 1, posY );
            }
            else
            {
                return _nums[posX, posY];
            }
        }
        /// <summary>
        /// Возвращает ячейку на юге от текущей
        /// </summary>
        /// <param name="posX">Координата Х</param>
        /// <param name="posY">Координата Y</param>
        /// <returns></returns>
        public MyCell South ( int posX, int posY )  
        {
            if ( posX != _nums.GetLength ( 1 ) - 1 )
            {
                return GetCellAt ( posX + 1, posY );
            }
            else
            {
                return _nums[posX, posY];
            }
        }
        /// <summary>
        /// Возвращает ячейку на западе от текущей
        /// </summary>
        /// <param name="posX">Координата Х</param>
        /// <param name="posY">Координата Y</param>
        /// <returns></returns>
        public MyCell West ( int posX, int posY ) 
        {
            if ( posY != 0 )
            {
                return GetCellAt ( posX, posY - 1 );
            }
            else
            {
                return _nums[posX, posY];
            }
        }
        /// <summary>
        /// Индексантор
        /// </summary>
        /// <param name="index1">Координата Х</param>
        /// <param name="index2">Координата У</param>
        /// <returns></returns>
        public MyCell this[int index1, int index2]
        {
            get
            {
                return _nums[index1, index2];
            }
        }
        /// <summary>
        /// Свойство массива фишек
        /// </summary>
        public MyCell[,] GetNums
        {
            get
            {
                return _nums;
            }
        }
        /// <summary>
        /// Свойство позиции пустого элемента в строке
        /// </summary>
        public int RowPosEmpty
        {
            get
            {
                return _rowPosEmpty;
            }
        }
        /// <summary>
        /// Свойство позиции пустого элемента в столбце
        /// </summary>
        public int ColPosEmpty
        {
            get
            {
                return _colPosEmpty;
            }
        }
        public abstract bool IsWinGame(int size); 
        /// <summary>
        /// Номер строки пустого элемента
        /// </summary>
        private int _rowPosEmpty;
        /// <summary>
        /// Номер столбца пустого элемента
        /// </summary>
        private int _colPosEmpty;
        /// <summary>
        /// массив фишек
        /// </summary>
        protected MyCell[,] _nums;
    }
}
