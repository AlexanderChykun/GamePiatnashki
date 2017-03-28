using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
     public abstract class Cell<T> where T: IComparable<T>
    {
        public readonly ICellable _c;
        public Cell (ICellable c, T num)
        {
            _c = c;
           
            _num = num;
        }
        /// <summary>
        /// Свойства номера фишки
        /// </summary>
        public T num
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
        public abstract void Move();
        private T _num;        //Номер фишки
       
    }
}
