using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    struct Cell
    {
        private int _num;        //Номер фишки
        /// <summary>
        /// Конструктор номера фишки
        /// </summary>
        public int num
        {
            get
            {
                return _num;        //Показать номер фишки
            }
            set
            {
                _num = value;       //Установить номер фишки
            }
        }
    }
}
