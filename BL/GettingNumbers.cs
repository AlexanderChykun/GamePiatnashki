using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    struct GettingNumbers
    {
        public static Random rnd = new Random();
        /// <summary>
        /// присвоение рандомного числа от 1 до size*size
        /// </summary>
        /// <param name="size">размер игрового поля</param>
        /// <returns></returns>
        public static int GetNumber(int size)
        {
            int _num = rnd.Next(1, size * size); //присвоение рандомного числа от 1 до size*size

            return _num;
        }
    }
}
