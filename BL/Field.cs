using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace BL
{
    /// <summary>
    /// Перечисление действий пользователя
    /// </summary>
    public enum Action
    {
        NoAction = 0,
        Left,
        Right,
        Up,
        Down,
        Retry,
        Exit
    } 

    public struct Field
    {
        /// <summary>
        /// Заполнение отсортированного массива
        /// </summary>
        /// <param name="size">размер игрового поля</param>
        /// <param name="sortArr">размер игрового поля по-умолчанию</param>
        /// <returns></returns>
        private static int[,] FillingSortArr(int size, out int[,] sortArr) 
        {
            sortArr = new int[size, size];
            int count = 0;
            for (int i = 0; i < sortArr.GetLength(0); i++)
            {
                for (int j = 0; j < sortArr.GetLength(1); j++)
                {
                    if ((i == (sortArr.GetLength(0) - 1)) && (j == (sortArr.GetLength(1) - 1)))
                    {
                        sortArr[j, i] = 0;                              // последняя ячейка с пустым символом 
                        break;
                    }
                    count++;
                    sortArr[j, i] = count;
                }
            }
            return sortArr;
        }
        /// <summary>
        /// Инициализация массива
        /// </summary>
        /// <param name="size">размер игрового поля</param>
        public Field(int size) 
        {
            _nums = new Cell[size, size];
            _rowPosEmpty = 0;
            _colPosEmpty = 0;
            _isWrongWay = false;
        }
        /// <summary>
        /// Получение символа
        /// </summary>
        /// <param name="i">номер строки</param>
        /// <param name="j">номер столбца</param>
        /// <returns></returns>
        public int GetSymbol(int i, int j) 
        {
            return _nums[i, j].num;
        }
        /// <summary>
        /// Получение длины столбца
        /// </summary>
        /// <returns></returns>
        public int GetCol() 
        {
            return _nums.GetLength(0);
        }
        /// <summary>
        /// Получение длины строки
        /// </summary>
        /// <returns></returns>
        public int GetRow() 
        {
            return _nums.GetLength(1);
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
                    if ((r == (_nums.GetLength(0) - 1)) && (k == (_nums.GetLength(1) - 1)))
                    {
                        _nums[r, k].num = 0;                              // последняя ячейка с пустым символом 
                        break;
                    }
                    _nums[r, k].num = GettingNumbers.GetNumber(size);              //присвоение числа
                    if (IsSameNum(r, k))                                    //проверка на повторение чисел
                    {
                        k--;
                    }
                }
            }
        }
        /// <summary>
        /// Действия пользователя
        /// </summary>
        /// <returns></returns>
        public static Action GetUserAction() 
        {
            Action аct = Action.NoAction;
            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    {
                        аct = Action.Left;
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        аct = Action.Right;
                        break;
                    }
                case ConsoleKey.UpArrow:
                    {
                        аct = Action.Up;
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        аct = Action.Down;
                        break;
                    }
                case ConsoleKey.Enter:
                    {
                        аct = Action.Retry;
                        break;
                    }
                case ConsoleKey.Escape:
                    {
                        аct = Action.Exit;
                        break;
                    }
            }
            return аct;
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
        /// <summary>
        /// Перемещение фишки вверх
        /// </summary>
        /// <param name="iCount">счетчик</param>
        /// <param name="size">размер игрового поля</param>
        /// <param name="defSize">размер игрового поля по-умолчанию</param>
        /// <param name="act">действие пользователя</param>
        public void MoveUp(ref int iCount, int size, int defSize, Action act) 
        {
            SearchEmptyCell();
            if (_rowPosEmpty == (_nums.GetLength(0) - 1))
            {
                iCount--;
                _isWrongWay = true; 
            }
            else
            {
                SwapCells(act);
            }
        }
        /// <summary>
        /// Перемещение фишки вниз
        /// </summary>
        /// <param name="iCount">счетчик</param>
        /// <param name="size">размер игрового поля</param>
        /// <param name="defSize">размер игрового поля по-умолчанию</param>
        /// <param name="act">действие пользователя</param>
        public void MoveDown(ref int iCount, int size, int defSize, Action act) 
        {
            SearchEmptyCell();
            if (_rowPosEmpty == 0)
            {
                iCount--;
                _isWrongWay = true;
               
            }
            else
            {
                SwapCells(act);
            }
        }
        /// <summary>
        /// Перемещение фишки влево
        /// </summary>
        /// <param name="iCount">счетчик</param>
        /// <param name="size">размер игрового поля</param>
        /// <param name="defSize">размер игрового поля по-умолчанию</param>
        /// <param name="act">действие пользователя</param>
        public void MoveLeft(ref int iCount, int size, int defSize, Action act) 
        {
            SearchEmptyCell();
            if (_colPosEmpty == (_nums.GetLength(1) - 1))
            {
                iCount--;
                _isWrongWay = true;
            }
            else
            {
                SwapCells(act);
            }
        }
        /// <summary>
        /// Перемещение фишки вправо
        /// </summary>
        /// <param name="iCount">счетчик</param>
        /// <param name="size">размер игрового поля</param>
        /// <param name="defSize">размер игрового поля по-умолчанию</param>
        /// <param name="act">действие пользователя</param>
        public void MoveRight(ref int iCount, int size, int defSize, Action act) 
        {
            SearchEmptyCell();
            if (_colPosEmpty == 0)
            {
                iCount--;
                _isWrongWay = true;
            }
            else
            {
                SwapCells(act);
            }
        }
        /// <summary>
        /// Обмен фишек
        /// </summary>
        /// <param name="act">действие пользователя</param>
        public void SwapCells(Action act) 
        {
            switch (act)
            {
                case Action.NoAction:
                    break;
                case Action.Left:
                    {
                        Cell tmp = _nums[_colPosEmpty, _rowPosEmpty];
                        _nums[_colPosEmpty, _rowPosEmpty] = _nums[_colPosEmpty + 1, _rowPosEmpty];
                        _nums[_colPosEmpty + 1, _rowPosEmpty] = tmp;
                        break;
                    }
                case Action.Right:
                    {
                        Cell tmp = _nums[_colPosEmpty, _rowPosEmpty];
                        _nums[_colPosEmpty, _rowPosEmpty] = _nums[_colPosEmpty - 1, _rowPosEmpty];
                        _nums[_colPosEmpty - 1, _rowPosEmpty] = tmp;
                        break;
                    }
                case Action.Up:
                    {
                        Cell tmp = _nums[_colPosEmpty, _rowPosEmpty];
                        _nums[_colPosEmpty, _rowPosEmpty] = _nums[_colPosEmpty, _rowPosEmpty + 1];
                        _nums[_colPosEmpty, _rowPosEmpty + 1] = tmp;
                        break;
                    }
                case Action.Down:
                    {
                        Cell tmp = _nums[_colPosEmpty, _rowPosEmpty];
                        _nums[_colPosEmpty, _rowPosEmpty] = _nums[_colPosEmpty, _rowPosEmpty - 1];
                        _nums[_colPosEmpty, _rowPosEmpty - 1] = tmp;
                        break;
                    }
                case Action.Retry:
                    break;
                case Action.Exit:
                    break;
                default:
                    break;
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
            int[,] sortArr = new int[size, size];
            sortArr = FillingSortArr(size, out sortArr);

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
        /// Конструктор переменной ошибочного хода
        /// </summary>
        public bool IsWrongWay
        {
            get
            {
                return _isWrongWay;        //Показать номер фишки
            }
            set
            {
                _isWrongWay = value;       //Установить номер фишки
            }

        }
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
        private Cell[,] _nums;                      
        /// <summary>
        /// Переменная ошибочного хода
        /// </summary>
        private bool _isWrongWay;            
    }
}
