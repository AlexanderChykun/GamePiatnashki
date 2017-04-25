using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace piatnashki
{
    class UserController
    {
        /// <summary>
        /// Получить действие пользователя
        /// </summary>
        /// <param name="f">игровое поле</param>
        /// <param name="newGame"></param>
        /// <param name="cont"></param>
        /// <param name="startCoord">стартовые координаты</param>
        public static void GetUserAction ( Field f, ref bool newGame, ref bool cont, ref Coordinates startCoord )
        {
            ConsoleKeyInfo key = Console.ReadKey ();
            switch ( key.Key )
            {
                case ConsoleKey.LeftArrow:
                    {
                        if ( startCoord.PosX - 1 < 0 ||
                            f.GetCellAt ( startCoord.PosX - 1, startCoord.PosY ).num == 0 )
                        {
                            break;
                        }
                        else
                        {
                            f.GetCellAt ( startCoord.PosX, startCoord.PosY ).isChoosed = false;
                            startCoord.PosX -= 1;
                            f.GetCellAt ( startCoord.PosX, startCoord.PosY ).isChoosed = true;
                            Viewer.ShowField ( f );
                        }
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {

                        if ( startCoord.PosX + 1 > f.GetCol () - 1 ||
                            f.GetCellAt ( startCoord.PosX + 1, startCoord.PosY ).num == 0 )
                        {
                            break;
                        }
                        else
                        {
                            f.GetCellAt ( startCoord.PosX, startCoord.PosY ).isChoosed = false;
                            startCoord.PosX += 1;
                            f.GetCellAt ( startCoord.PosX, startCoord.PosY ).isChoosed = true;
                            Viewer.ShowField ( f );
                        }
                        break;
                    }
                case ConsoleKey.UpArrow:
                    {

                        if ( startCoord.PosY - 1 < 0 ||
                            f.GetCellAt ( startCoord.PosX, startCoord.PosY - 1 ).num == 0 )
                        {
                            break;
                        }
                        else
                        {
                            f.GetCellAt ( startCoord.PosX, startCoord.PosY ).isChoosed = false;
                            startCoord.PosY -= 1;
                            f.GetCellAt ( startCoord.PosX, startCoord.PosY ).isChoosed = true;
                            Viewer.ShowField ( f );
                        }
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {

                        if ( startCoord.PosY + 1 > f.GetRow () - 1 ||
                            f.GetCellAt ( startCoord.PosX, startCoord.PosY + 1 ).num == 0 )
                        {
                            break;
                        }
                        else
                        {
                            f.GetCellAt ( startCoord.PosX, startCoord.PosY ).isChoosed = false;
                            startCoord.PosY += 1;
                            f.GetCellAt ( startCoord.PosX, startCoord.PosY ).isChoosed = true;
                            Viewer.ShowField ( f );
                        }
                        break;
                    }
                case ConsoleKey.Spacebar:
                    {
                        f.OnMoving ( f.GetCellAt ( startCoord.PosX, startCoord.PosY ) );
                        break;
                    }
                case ConsoleKey.Enter:
                    {
                        newGame = true;
                        cont = false;
                        break;
                    }
                case ConsoleKey.Escape:
                    {
                        cont = false;
                        break;
                    }
            }
        }
    }
}
