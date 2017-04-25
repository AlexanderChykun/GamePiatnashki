using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
            Coordinates defCoord = new Coordinates(0,0);
            bool newGame = true;
            bool cont = true;
            do{
                cont = true;
                int size = Field.defSize; 
                size = Viewer.GetSizeOfField(Field.defSize);          //Задание размерности игрового поля
                if ( size > 10 )
                {
                    size = Field.defSize;
                }
                Field num = new Field(size) ;
                
                num.Moving += num.Run;
                num.AddingCounter += num.AddCounter;
                num.AddingCounter += Viewer.Counter;

                Viewer.NewGame();

                Viewer.NameOfGame ( size, Field.defSize );                    //Название игры
                Viewer.MenuOfGame ( size, Field.defSize );                    //Меню игры
                Viewer.InitField ( size );                              //Инициализация игрового поля
           
                do
                {
                    newGame = false;
                    Viewer.ShowField ( num );                              //Отображение игрового поля
                

                    if (num.IsWinGame(size))                          //Проверка на собранность головоломки
                    {
                        Viewer.Winner();
                        Viewer.MenuAfterWin(num.GetCount);
                    }
                    UserController.GetUserAction (num,ref newGame, ref cont, ref defCoord );
                
                } while (cont);
            }while(newGame);
        }
    }
}
