using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BL;


namespace piatnashki
{
    public class Viewer
    {
        /// <summary>
        /// Новая игра
        /// </summary>
        public static void NewGame() 
        {
            for (int i = 0; i < 3; i++)                       //Мигание экрана трижды
            {
                const int posX = 24;    //Стартовые координаты  надписи     
                const int posY = 7;
                Console.Clear();
                Thread.Sleep(500);
                Console.SetCursorPosition(posX, posY + 1);
                Console.WriteLine("        ***         ");
                Console.SetCursorPosition(posX, posY + 2);
                Console.WriteLine("     *********      ");
                Console.SetCursorPosition(posX, posY + 3);
                Console.WriteLine("  ***************   ");
                Console.SetCursorPosition(posX, posY + 4);
                Console.WriteLine("Начинаем новую игру!");
                Console.SetCursorPosition(posX, posY + 5);
                Console.WriteLine("  ***************   ");
                Console.SetCursorPosition(posX, posY + 6);
                Console.WriteLine("     *********      ");
                Console.SetCursorPosition(posX, posY + 7);
                Console.WriteLine("        ***         ");
                Thread.Sleep(300);
                Console.Clear();
            }
        }
        /// <summary>
        /// Запрос размера игрового поля
        /// </summary>
        /// <param name="defSize">размер поля по-умолчанию</param>
        /// <returns></returns>
        public static int GetSizeOfField(int defSize)
        {
            Console.Clear();
            Console.Write("Введите размер игрового поля (от 4):");
            int size = int.Parse(Console.ReadLine());
            if (size < 4)
            {
                size = defSize;
            }
            return size;
        }
        /// <summary>
        /// название игры
        /// </summary>
        /// <param name="size">размер игрового поля</param>
        /// <param name="defSize">размер поля по-умолчанию</param>
        public static void NameOfGame(int size, int defSize) 
        {
            const int posXName = 24;                              //Стартовые координаты расположения названия игры
            const int posYName = 1;
            int setXPos = posXName + ((size - defSize) * 5) / 2;   //Смещение названия игры после увеличения поля
            Console.WriteLine();
            Console.SetCursorPosition(setXPos, posYName);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("---XXX ПЯТНАШКИ XXX---");
        }
        /// <summary>
        /// Изображение фишки
        /// </summary>
        /// <param name="posX">позиция фишки по горизонтали</param>
        /// <param name="posY">позиция фишки по вертикали</param>
        /// <param name="c">число внутри фишки</param>
        public static void ShowCell(int posX, int posY, int c) 
        {
            if (c == 0)
            {
                
                Console.SetCursorPosition ( posX, posY );
                Console.WriteLine ( "    " );
                Console.SetCursorPosition ( posX, posY + 1 );
                Console.WriteLine ( "    " );
                Console.SetCursorPosition ( posX, posY + 2 );
                Console.WriteLine ( "    " );
            }
            else
            {
                if (c / 10 == 0)
                {
                    //Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(posX, posY);
                    Console.WriteLine("╔══╗");
                    Console.SetCursorPosition(posX, posY + 1);
                    Console.WriteLine("║{0} ║", c);
                    Console.SetCursorPosition(posX, posY + 2);
                    Console.WriteLine("╚══╝");
                }
                else
                {
                    //Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(posX, posY);
                    Console.WriteLine("╔══╗");
                    Console.SetCursorPosition(posX, posY + 1);
                    Console.WriteLine("║{0}║", c);
                    Console.SetCursorPosition(posX, posY + 2);
                    Console.WriteLine("╚══╝");
                }
            }
        }
        /// <summary>
        /// Изображение поля 
        /// </summary>
        /// <param name="size">размер игрового поля</param>
        public static void InitField(int size) 
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int posX = i * 5 + 24;
                    int posY = j * 4;
                    Console.SetCursorPosition(posX, posY + 2);
                    Console.WriteLine("┌────┐");
                    Console.SetCursorPosition(posX, posY + 3);
                    Console.WriteLine("│    │");
                    Console.SetCursorPosition(posX, posY + 4);
                    Console.WriteLine("│    │");
                    Console.SetCursorPosition(posX, posY + 5);
                    Console.WriteLine("│    │");
                    Console.SetCursorPosition(posX, posY + 6);
                    Console.WriteLine("└────┘");
                }
            }
        }
        /// <summary>
        /// Показать ячейки
        /// </summary>
        /// <param name="f">переменная типа Field </param>
        public static void ShowField(Field f) 
        {
            for (int i = 0; i < f.GetCol(); i++)
            {
                for (int j = 0; j < f.GetRow(); j++)
                {
                    if ( f[i,j].isChoosed )
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Viewer.ShowCell ( i * 5 + 25, j * 4 + 3, f.GetSymbol ( i, j ) );
                    }
                    else 
                    { 
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Viewer.ShowCell ( i * 5 + 25, j * 4 + 3, f.GetSymbol ( i, j ) );
                    }
                   
                }
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Меню игры
        /// </summary>
        /// <param name="size">размер игрового поля</param>
        /// <param name="defSize">размер игрового поля по-умолчанию</param>
        public static void MenuOfGame(int size, int defSize) 
        {
            const int posXMenu = 0;  //Стартовые координаты расположения меню
            const int posYMenu = 3;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(posXMenu, posYMenu);
            Console.WriteLine("Меню игры:");
            Console.SetCursorPosition(posXMenu, posYMenu + 3);
            Console.WriteLine("Enter - Новая игра");
            Console.SetCursorPosition(posXMenu, posYMenu + 4);
            Console.WriteLine("Escape - Выход");

            const int posXControl = 46;   //Стартовые координаты расположения клавиш управления
            const int posYControl = 3;
            int setXPos = posXControl + (size - defSize) * 5;   //Смещение слева меню клавиш управления после увеличения поля

            Console.SetCursorPosition(setXPos, posYControl);
            Console.WriteLine("Клавиши управления:");
            Console.SetCursorPosition(setXPos, posYControl + 3);
            Console.WriteLine("Стрелка вверх");
            Console.SetCursorPosition(setXPos, posYControl + 4);
            Console.WriteLine("Стрелка вниз");
            Console.SetCursorPosition(setXPos, posYControl + 5);
            Console.WriteLine("Стрелка влево");
            Console.SetCursorPosition(setXPos, posYControl + 6);
            Console.WriteLine("Стрелка вправо");
            Console.SetCursorPosition ( setXPos, posYControl + 7 );
            Console.WriteLine ( "Пробел - переместить" );
        }
        /// <summary>
        /// Отображение счетчика ходов
        /// </summary>
        /// <param name="iCount">счетчик ходов</param>
        /// <param name="size">размер игрового поля</param>
        /// <param name="defSize">размер игрового поля по-умолчанию</param>
        public static void Counter(int iCount, int size, int defSize) 
        {
            const int posX = 26;                                //Стартовые координаты расположения счетчика                  
            const int posY = 20;
            int setXPos = posX + ((size - defSize) * 4) / 2;    //Смещение слева сообщения после увеличения поля
            int setYPos = posY + (size - defSize) * 4;          //Смещение вниз сообщения после увеличения поля
            Console.SetCursorPosition(setXPos, setYPos);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Счетчик ходов:{0}", iCount);
        }
        /// <summary>
        /// Отображение счетчика
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        public static void Counter ( object sender, EventArgs arg )
        {
            const int posX = 26;                                //Стартовые координаты расположения счетчика                  
            const int posY = 20;
            int setXPos = posX + (((sender as Field).GetRow () -Field.defSize) * 4) / 2;    //Смещение слева сообщения после увеличения поля
            int setYPos = posY + ((sender as Field).GetCol () - Field.defSize) * 4;          //Смещение вниз сообщения после увеличения поля
            Console.SetCursorPosition ( setXPos, setYPos );
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine ( "Счетчик ходов:{0}", (sender as Field).GetCount );
        }
        /// <summary>
        /// Отображение окна после выиграша
        /// </summary>
        public static void Winner() 
        {
            const int posX = 24;          //Стартовые координаты расположения надписи                 
            const int posY = 7;
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 3; i++)             //Мигание экрана трижды
            {
                Console.Clear();
                Thread.Sleep(500);
                Console.SetCursorPosition(posX - 12, posY);
                Console.WriteLine("***************     ***      ***************");
                Console.SetCursorPosition(posX - 9, posY);
                Console.WriteLine("*********     *********      *********");
                Console.SetCursorPosition(posX - 4, posY);
                Console.WriteLine("***   ***************    ***");
                Console.SetCursorPosition(posX, posY);
                Console.WriteLine("   ВЫ ПОБЕДИЛИ!!!   ");
                Console.SetCursorPosition(posX - 4, posY);
                Console.WriteLine("***   ***************    ***");
                Console.SetCursorPosition(posX - 9, posY);
                Console.WriteLine("*********     *********      *********");
                Console.SetCursorPosition(posX - 12, posY);
                Console.WriteLine("***************     ***      ***************");
                Thread.Sleep(500);
                Console.Clear();
            }
        }
        /// <summary>
        /// Меню после выиграша
        /// </summary>
        /// <param name="iCount">счетчик ходов</param>
        public static void MenuAfterWin(int iCount) 
        {
            const int posX = 24;          //Стартовые координаты расположения меню                  
            const int posY = 10;
            Console.Clear();
            Console.SetCursorPosition(posX, posY - 4);
            Console.WriteLine("Вы собрали игру за {0} ходов.", iCount);
            Console.SetCursorPosition(posX, posY);
            Console.WriteLine("Enter - новая игра");
            Console.SetCursorPosition(posX, posY + 1);
            Console.WriteLine("Escape - выход");
        }
    }
}
