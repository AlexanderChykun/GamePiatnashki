using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FillingGameField
    {

        public static Random rnd = new Random();
        /// <summary>
        /// присвоение рандомного числа от 1 до size*size
        /// </summary>
        /// <param name="size">размер игрового поля</param>
        /// <returns></returns>
        public static int GetNumber(int size)
        {
            int _num = 0;
            _num = (rnd.Next ( 1, size * size )); //присвоение рандомного числа от 1 до size*size
            return _num;
        }
        /// <summary>
        /// Заполнение отсортированного массива
        /// </summary>
        /// <param name="size">размер игрового поля</param>
        /// <param name="sortArr">размер игрового поля по-умолчанию</param>
        /// <returns></returns>
        public static void FillingSortArr ( ref int [,] sortArr )
        {
            int count = 0;
            for ( int i = 0; i < sortArr.GetLength ( 0 ); i++ )
            {
                for ( int j = 0; j < sortArr.GetLength ( 1 ); j++ )
                {
                    if ( (i == (sortArr.GetLength ( 0 ) - 1)) && (j == (sortArr.GetLength ( 1 ) - 1)) )
                    {
                        sortArr[i, j] = 0;                              // последняя ячейка с пустым символом 
                        break;
                    }
                    count++;
                    sortArr[i, j] = count;
                }
            }
        }
    }
}
