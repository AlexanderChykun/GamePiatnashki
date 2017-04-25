using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Coordinates
    {
        /// <summary>
        /// Конструктор координат ячейки
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        public Coordinates (int posX, int posY)
        {
            _posX = posX;
            _posY = posY;
        }
        /// <summary>
        /// Свойства координаты Х
        /// </summary>
        public int PosX
        {
            get
            {
                return _posX;
            }
            set
            {
                _posX = value;
            }
        }
        /// <summary>
        /// Свойства координаты У
        /// </summary>
        public int PosY
        {
            get
            {
                return _posY;
            }
            set
            {
                _posY = value;
            }
        }
        /// <summary>
        /// Координата Х
        /// </summary>
        private int _posX;
        /// <summary>
        /// Координата У
        /// </summary>
        private int _posY;
    }
}
