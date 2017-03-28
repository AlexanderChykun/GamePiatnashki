using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace BL
{
    public class MovingEventArgs : EventArgs
    {

    }
    public delegate void Moving ( object sender, MovingEventArgs arg );
    public class Field: ICellable
    {
        public const int defSize = 4;
        public Field (int size = defSize)
        {
            _nums = new Button[size, size];
            setNums ( size );
            sortArr = new int[size, size];
            sortArr = FillingSortArr ( size, out sortArr );
        }
        public event Moving MovingUp
        {
            add
            {
                _moveUp += value;
            }
            remove
            {
                _moveUp -= value;

            }
        }
        public event Moving MovingDown
        {
            add
            {
                _moveDown += value;
            }
            remove
            {
                _moveDown -= value;

            }
        }
        public event Moving MovingLeft
        {
            add
            {
                _moveLeft += value;
            }
            remove
            {
                _moveLeft -= value;

            }
        }
        public event Moving MovingRight
        {
            add
            {
                _moveRight += value;
            }
            remove
            {
                _moveRight -= value;

            }
        }
        public void onMoveUp ()
        {
            if ( _moveUp != null )
            {
                _moveUp ( this, new MovingEventArgs () );
            }
        }
        public void onMoveDown ()
        {
            if ( _moveDown != null )
            {
                _moveDown ( this, new MovingEventArgs () );
            }
        }
        public void onMoveLeft ()
        {
            if ( _moveLeft != null )
            {
                _moveLeft ( this, new MovingEventArgs () );
            }
        }
        public void onMoveRight ()
        {
            if ( _moveRight != null )
            {
                _moveRight ( this, new MovingEventArgs () );
            }
        }
        private Moving _moveUp;
        private Moving _moveDown;
        private Moving _moveLeft;
        private Moving _moveRight;
        /// <summary>
        /// Заполнение отсортированного массива
        /// </summary>
        /// <param name="size">размер игрового поля</param>
        /// <param name="sortArr">размер игрового поля по-умолчанию</param>
        /// <returns></returns>
        private int[,] FillingSortArr(int size, out int[,] sortArr) 
        {
            sortArr = new int[size, size];
            int count = 0;
            for (int i = 0; i < sortArr.GetLength(0); i++)
            {
                for (int j = 0; j < sortArr.GetLength(1); j++)
                {
                    if ((i == (sortArr.GetLength(0) - 1)) && (j == (sortArr.GetLength(1) - 1)))
                    {
                        sortArr[i, j] = 0;                              // последняя ячейка с пустым символом 
                        break;
                    }
                    count++;
                    sortArr[i, j] = count;
                }
            }
            return sortArr;
        }
       
        /// <summary>
        /// проверка на повторение чисел при заполнении
        /// </summary>
        /// <param name="r">номер строки</param>
        /// <param name="k">номер столбца</param>
        /// <returns></returns>
        public bool IsSameNum(int r, int k) 
        {
            bool isSame = false;
            bool thisNum = false;
            for (int i = 0; i <= r; i++)
            {
                for (int j = 0; j < _nums.GetLength(1); j++)
                {
                    if (r == i && k == j)
                    {
                        thisNum = true;
                        break;
                    }
                    if (_nums[r, k].num == _nums[i, j].num)
                    {
                        isSame = true;
                        break;
                    }
                }
                if (isSame || thisNum)
                {
                    break;
                }
            }
            return isSame;
        }
        /// <summary>
        /// Заполнение номеров фишек
        /// </summary>
        /// <param name="size">размер игрового поля</param>
        public void setNums(int size) 
        {
            for (int r = 0; r < _nums.GetLength(0); r++)
            {
                for (int k = 0; k < _nums.GetLength(1); k++)
                {
                    _nums[r, k] = new Button ( this, FillingGameField.GetNumber ( size ) );
                    if ((r == (_nums.GetLength(0) - 1)) && (k == (_nums.GetLength(1) - 1)))
                    {
                        
                        _nums[r, k].num = 0;                              // последняя ячейка с пустым символом 
                        break;
                    }
                    if (IsSameNum(r, k))                                    //проверка на повторение чисел
                    {
                        k--;
                    }
                }
            }
        }
        
        /// <summary>
        /// Поиск пустого элемента
        /// </summary>
        public void SearchEmptyCell() 
        {
            for (int i = 0; i < _nums.GetLength(0); i++)
            {
                for (int j = 0; j < _nums.GetLength(1); j++)
                {
                    if (_nums[i, j].num == 0)
                    {
                        _colPosEmpty = i;
                        _rowPosEmpty = j;
                    }
                }
            }
        }
        public Button GetCellAt ( int posX, int posY ) //Возвращает ячейку с координатами aCoord в массиве cells из _o
        {
            return _nums[posX, posY];
        }
        public bool GetEmptyNeighborCell ( int posX, int posY )
        {
            if ( East ( posX, posY ).num == 0 )
            {
                SearchEmptyCell ();
              
                return true;
            }

            if ( West ( posX, posY ).num == 0 )
            {
                SearchEmptyCell ();
                return true;
            }

            if ( South ( posX, posY ).num == 0 )
            {
                SearchEmptyCell ();
                return true;
            }

            if ( North ( posX, posY ).num == 0 )
            {
                SearchEmptyCell ();
                return true;
            }
            else
            {
                return false;
            }
        }
        public Button East ( int posX, int posY )
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
        public Button North ( int posX, int posY ) //Возвращает ячейку которая находится на севере от данной
        {
            if ( posX != 0)
            {
                return GetCellAt ( posX-1, posY ); 
            }
            else
            {
                return _nums[posX, posY];
            }
        }
        public Button South ( int posX, int posY )  //Возвращает ячейку которая находится на юге от данной
        {
            if ( posX!= _nums.GetLength ( 1 ) - 1 )
            {
                return GetCellAt ( posX + 1, posY ); 
            }
            else
            {
                return _nums[posX, posY];
            }
        }
        public Button West ( int posX, int posY ) //Возвращает ячейку которая находится на западе от данной
        {
            if ( posY != 0 )
            {
                return GetCellAt ( posX , posY-1 ); 
            }
            else
            {
                return _nums[posX, posY];
            }
        }
        /// <summary>
        /// Перемещение фишки вверх
        /// </summary>
       
        public void MoveUp(object o, MovingEventArgs arg) 
        {
            SearchEmptyCell();
            if (_rowPosEmpty == (_nums.GetLength(0) - 1))
            {
                _isWrongWay = true; 
            }
            else
            {
                _isWrongWay = false;
                Button tmp = _nums[_colPosEmpty, _rowPosEmpty];
                _nums[_colPosEmpty, _rowPosEmpty] = _nums[_colPosEmpty, _rowPosEmpty + 1];
                _nums[_colPosEmpty, _rowPosEmpty + 1] = tmp;
            }
        }
        /// <summary>
        /// Перемещение фишки вниз
        /// </summary>
      
        public void MoveDown (object o, MovingEventArgs arg) 
        {
          
            SearchEmptyCell ();
            if ( _rowPosEmpty == 0 )
            {
                _isWrongWay = true;
            }
            else
            {
                _isWrongWay = false;
                Button tmp = _nums[_colPosEmpty, _rowPosEmpty];
                _nums[_colPosEmpty, _rowPosEmpty] = _nums[_colPosEmpty, _rowPosEmpty - 1];
                _nums[_colPosEmpty, _rowPosEmpty - 1] = tmp;
            }
        }
        /// <summary>
        /// Перемещение фишки влево
        /// </summary>

        public void MoveLeft (object o, MovingEventArgs arg) 
        {
           
            SearchEmptyCell ();
            if ( _colPosEmpty == (_nums.GetLength ( 0 ) - 1) )
            {
                _isWrongWay = true;
            }
            else
            {
                _isWrongWay = false;
                Button tmp = _nums[_colPosEmpty, _rowPosEmpty];
                _nums[_colPosEmpty, _rowPosEmpty] = _nums[_colPosEmpty + 1, _rowPosEmpty];
                _nums[_colPosEmpty + 1, _rowPosEmpty] = tmp;
            }
        }
        /// <summary>
        /// Перемещение фишки вправо
        /// </summary>
        
        public void MoveRight (object o, MovingEventArgs arg) 
        {
            SearchEmptyCell ();
            if ( _colPosEmpty == 0 )
            {
                _isWrongWay = true;
            }
            else
            {
                _isWrongWay = false;
                Button tmp = _nums[_colPosEmpty, _rowPosEmpty];
                _nums[_colPosEmpty, _rowPosEmpty] = _nums[_colPosEmpty - 1, _rowPosEmpty];
                _nums[_colPosEmpty - 1, _rowPosEmpty] = tmp;
            }
        }
       
        /// <summary>
        /// Проверка собраной головоломки
        /// </summary>
        /// <param name="size">размер игрового поля</param>
        /// <returns></returns>
        public bool IsWinGame(int size) 
        {
            bool win = false;
            //int[,] sortArr = new int[size, size];
            //sortArr = FillingSortArr(size, out sortArr);

            for (int i = 0; i < _nums.GetLength(0); i++)
            {
                for (int j = 0; j < _nums.GetLength(1); j++)
                {
                    if (sortArr[i, j] == _nums[i, j].num)
                    {
                        win = true;
                    }
                    else
                    {
                        win = false;
                        break;
                    }
                }
                if (win == false)
                {
                    break;
                }
            }
            return win;
        }
        /// <summary>
        /// Получение длины столбца
        /// </summary>
        /// <returns></returns>
        public int GetCol ()
        {
            return _nums.GetLength ( 0 );
        }
        /// <summary>
        /// Получение длины строки
        /// </summary>
        /// <returns></returns>
        public int GetRow ()
        {
            return _nums.GetLength ( 1 );
        }
        /// <summary>
        /// Получение символа
        /// </summary>
        /// <param name="i">номер строки</param>
        /// <param name="j">номер столбца</param>
        /// <returns></returns>
        public int GetSymbol ( int i, int j )
        {
            return _nums[i, j].num;
        }
        public void AddCounter ( object a, MovingEventArgs arg )
        {
            if ( !_isWrongWay )
            {
                _iCount++;
            }
        }
        public int GetCount 
        {
            get
            {
                return _iCount;
            }
        }
        public Cell<int> this[int index1, int index2]
        {
            get
            {
                return _nums[index1, index2];
            }
        }
        public int RowPosEmpty
        {
            get
            {
                return _rowPosEmpty;
            }
        }
        public int ColPosEmpty
        {
            get
            {
                return _colPosEmpty;
            }
        }
       
        private int _iCount = 0;
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
        private Button [,] _nums;
        private int[,] sortArr;          
        /// <summary>
        /// Переменная ошибочного хода
        /// </summary>
        private bool _isWrongWay;            
    }
}
