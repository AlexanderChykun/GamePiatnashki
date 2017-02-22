using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserInterface;
using BL;

namespace piatnashki
{
    class Program
    {
        /// <summary>
        /// Размерность поля по-умолчанию
        /// </summary>
        public const int defSize = 4 ;                   

        static void Main(string[] args)
        {
            
            int size = defSize; 
            size = UI.GetSizeOfField(defSize);          //Задание размерности игрового поля
            
            Field num = new Field(size) ;
            UI.NewGame();
            num.setNums(size);                  //Заполнение игрового поля
            
            bool cont = true;
            BL.Action Move;
            int iCount = 0;

            do
            {
                bool newGame = false;

                UI.NameOfGame(size, defSize);                    //Название игры
                UI.MenuOfGame(size, defSize);                    //Меню игры
                UI.InitField(size);                              //Инициализация игрового поля
                UI.ShowField(num);                              //Отображение игрового поля

                if (num.IsWinGame(size))                          //Проверка на собранность головоломки
                {
                    UI.Winner();
                    UI.MenuAfterWin(iCount);
                }
                Move = Field.GetUserAction();
                switch (Move)
                {
                    case BL.Action.Up:
                    {
                        num.MoveUp(ref iCount, size, defSize, Move);
                        if (num.IsWrongWay)
                        {
                            UI.WrongWay(size, defSize);
                        }
                        break;
                    }
                    case BL.Action.Down:
                    {
                        num.MoveDown(ref iCount, size, defSize, Move);
                        if (num.IsWrongWay)
                        {
                            UI.WrongWay(size, defSize);
                        }
                        break;
                    }
                    case BL.Action.Left:
                    {
                        num.MoveLeft(ref iCount, size, defSize, Move);
                        if (num.IsWrongWay)
                        {
                            UI.WrongWay(size, defSize);
                        }
                        break;
                    }
                    case BL.Action.Right:
                    {
                        num.MoveRight(ref iCount, size, defSize, Move);
                        if (num.IsWrongWay)
                        {
                            UI.WrongWay(size, defSize);
                        }
                        break;
                    }
                    case BL.Action.Retry:
                    {
                        size = UI.GetSizeOfField(defSize);
                        num = new Field(size);
                        UI.NewGame();
                        num.setNums(size);
                        iCount = 0;
                        newGame = true;
                        break;
                    }
                    case BL.Action.Exit:
                    {
                        cont = false;
                        Console.Clear();
                        Console.SetCursorPosition(24, 10);
                        Console.WriteLine("До свидания!!!");
                        Thread.Sleep(2000);
                        break;
                    }
                }
                Console.Clear();
                if (!cont)              //прервать не добавляя счетчик
                {
                    break;
                }
                if (newGame)            //продолжить не добавляя счетчик
                {
                    continue;
                }
                num.IsWrongWay = false;
                iCount++;
                UI.Counter(iCount,size,defSize);
            } while (cont);
        }
    }
}
