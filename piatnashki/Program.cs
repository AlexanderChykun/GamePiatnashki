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
                          

        static void Main(string[] args)
        {
            bool newGame = true;
            bool cont = true;
            do{
                cont = true;
                int size = Field.defSize; 
                size = UI.GetSizeOfField(Field.defSize);          //Задание размерности игрового поля
            
                Field num = new Field(size) ;
                num.MovingUp += num.MoveUp;
                num.MovingUp += num.AddCounter;
                num.MovingRight += num.MoveRight;
                num.MovingRight += num.AddCounter;
                num.MovingDown += num.MoveDown;
                num.MovingDown += num.AddCounter;
                num.MovingLeft += num.MoveLeft;
                num.MovingLeft += num.AddCounter;
                num.MovingUp += UI.Counter;
                num.MovingRight += UI.Counter;
                num.MovingLeft += UI.Counter;
                num.MovingDown += UI.Counter;

                UI.NewGame();

                UI.NameOfGame ( size, Field.defSize );                    //Название игры
                UI.MenuOfGame ( size, Field.defSize );                    //Меню игры
                UI.InitField ( size );                              //Инициализация игрового поля
           
                do
                {
                    newGame = false;
                    UI.ShowField ( num );                              //Отображение игрового поля
                

                    if (num.IsWinGame(size))                          //Проверка на собранность головоломки
                    {
                        UI.Winner();
                        UI.MenuAfterWin(num.GetCount);
                    }
                    UI.GetUserAction (num, ref newGame, ref cont);
                
                } while (cont);
            }while(newGame);
        }
    }
}
