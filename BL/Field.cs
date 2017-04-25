using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace BL
{
    public class Field: ChangeCellsOfField
    {
        public const int defSize = 4;
        /// <summary>
        /// Конструктор игрового поля
        /// </summary>
        /// <param name="size">размер поля</param>
        public Field (int size = defSize): base()
        {
            _nums = new MyCell[size, size];
            setNums ( size );
            sortArr = new int[size, size];
            FillingGameField.FillingSortArr ( ref sortArr);
        }
        /// <summary>
        /// Событие передвижения фишки
        /// </summary>
        public event EventHandler Moving;
        /// <summary>
        /// Событие добавления счетчика
        /// </summary>
        public event EventHandler AddingCounter;
        /// <summary>
        /// Инициализатор события добавления счетчика
        /// </summary>
        public void OnAddingCounter ( )
        {
            if ( AddingCounter != null )
            {
                AddingCounter ( this, new EventArgs () );
            }
        }
        /// <summary>
        /// Инициализатор события передвижения фишки
        /// </summary>
        /// <param name="cell">передвигаемая фишка</param>
        public void OnMoving (MyCell cell)
        {
            if ( Moving != null )
            {
                Moving ( cell, new EventArgs () );
            }
        }
        /// <summary>
        /// Запуск движения фишки
        /// </summary>
        /// <param name="o"></param>
        /// <param name="arg"></param>
        public void Run ( object o, EventArgs arg )
        {
            MyCell cell = o as MyCell;
            cell.Move();
            if ( cell.isMoved )
            {
                OnAddingCounter ();
            }
            cell.isMoved = false;
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
                    if ( _nums[r, k].num == _nums[i, j].num )
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
                    _nums[r, k] = new MyCell ( this, FillingGameField.GetNumber ( size ) ,new Coordinates(r,k));
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
        /// Проверка собраной головоломки
        /// </summary>
        /// <param name="size">размер игрового поля</param>
        /// <returns></returns>
        public override bool IsWinGame(int size) 
        {
            bool win = false;
            for ( int i = 0; i < _nums.GetLength ( 0 ); i++ )
            {
                for ( int j = 0; j < _nums.GetLength ( 1 ); j++ )
                {
                    if ( sortArr[i, j] == _nums[i, j].num )
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
            return GetNums[i, j].num;
        }
        /// <summary>
        /// Добавление счетчика
        /// </summary>
        /// <param name="o"></param>
        /// <param name="arg"></param>
        public void AddCounter ( object o, EventArgs arg )
        {
                _iCount++;
        }
        /// <summary>
        /// Получить значение счетчика
        /// </summary>
        public int GetCount 
        {
            get
            {
                return _iCount;
            }
        }
        /// <summary>
        /// счетчик
        /// </summary>
        private int _iCount = 0;
        /// <summary>
        /// отсортированный массив
        /// </summary>
        private readonly int [,] sortArr;          
    }
}
