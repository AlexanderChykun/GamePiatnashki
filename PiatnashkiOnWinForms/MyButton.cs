using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;

namespace PiatnashkiOnWinForms
{
    class MyButton: Button
    {
       
        public MyButton (Cell cell,int posX, int posY)
        {
            _posX = posX;
            _posY = posY;
            _cell = cell;
            Text = string.Format ( "{0}", cell.num );
        }
        public Cell GetCell
        {
            get
            {
                return _cell;
            }
            set
            {
                _cell = value;
            }
        }
        public int PosX
        {
            get
            {
                return _posX;        //Показать номер фишки
            }
            set
            {
                _posX = value;       //Установить номер фишки
            }
        }
        public int PosY
        {
            get
            {
                return _posY;        //Показать номер фишки
            }
            set
            {
                _posY = value;       //Установить номер фишки
            }
        }
        private Cell _cell;
        private int _posX;
        private int _posY;
    }
}
