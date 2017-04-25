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
        /// <summary>
        /// Конструктор ячейки
        /// </summary>
        /// <param name="c">интерфейсная ссылка</param>
        /// <param name="num">номер ячейки</param>
        /// <param name="coord">координаты ячейки</param>
        public Cell (ICellable c,  T num, Coordinates coord)
        {
            _c = c;
            _coord = coord;
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
        /// <summary>
        /// Свойства координат фишки
        /// </summary>
        public Coordinates Coord
        {
            get
            {
                return _coord;
            }
            set
            {
                _coord = value;
            }
        }
        /// <summary>
        /// Абстрактный метод передвижения фишки
        /// </summary>
        public abstract void Move (  );

        private Coordinates _coord;
        private T _num;        //Номер фишки
    }
}
