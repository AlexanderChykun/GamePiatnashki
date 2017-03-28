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
    public partial class GameForm : Form
    {
        public GameForm ()
        {
            InitializeComponent ();
        }
        
        private void button1_Click ( object sender, EventArgs e )
        {
            tabControl1.DeselectTab ( 0 );
        }

        private void tabPage2_Enter ( object sender, EventArgs e )
        {
            size = (int) numericSize.Value;
            int buttonSize = 40;
            switch ( size )
            {
                case 4:
                    {
                        buttonSize = 40;
                        break;
                    }
                case 5:
                    {
                        
                        buttonSize = 35;
                        break;
                        
                    }
                case 6:
                    {
                        buttonSize = 30;
                        break;
                    }
                case 7:
                    {
                        buttonSize = 28;
                        break;
                    }
            }
            field = new Field(size);
            _gameField = new MyButton[size, size];
            
            for ( int i = 0; i < _gameField.GetLength ( 0 ); i++ )
            {
                for ( int j = 0; j < _gameField.GetLength ( 1 ); j++ )
                {
                    MyButton newButton = new MyButton ( field[i, j],i,j);
                    newButton.Location = new System.Drawing.Point ( (int) ((j + 1) * buttonSize), (int) ((i + 1) * buttonSize ));
                    newButton.Size = new System.Drawing.Size ( buttonSize, buttonSize );
                    newButton.UseVisualStyleBackColor = true;
                    grBoxGameField.Controls.Add(newButton);
                    _gameField[i, j] = newButton;
                    _gameField[i, j].Click += buttonNum_Click;
                    if ( int.Parse(newButton.Text) == 0 )
                    {
                        newButton.Hide ();
                    }
                }
            }
        }
     
        private void buttonNum_Click ( object sender, EventArgs e )
        {
            MyButton btnCurrent = sender as MyButton;

            if (btnCurrent == null)
            {
                return;
            }

            if (btnCurrent.GetCell._c.GetEmptyNeighborCell(btnCurrent.PosX, btnCurrent.PosY))
            {
                _gameField[(sender as MyButton).GetCell._c.ColPosEmpty, (sender as MyButton).GetCell._c.RowPosEmpty].GetCell.num 
                    = (sender as MyButton).GetCell.num;
                _gameField[(sender as MyButton).GetCell._c.ColPosEmpty, (sender as MyButton).GetCell._c.RowPosEmpty].Text 
                    = (sender as MyButton).Text;
                (sender as MyButton).GetCell.num = 0;
                (sender as MyButton).Text = "0";

                foreach ( MyButton item in _gameField )
                {
                    item.Show ();
                    if ( item.GetCell.num == 0 )
                    {
                        item.Hide ();// нулевую закрыть
                    }
                }
            }
            if ( (sender as MyButton).GetCell._c.IsWinGame ( size ) )
            {
                MessageBox.Show ( "ВЫ ПОБЕДИЛИ!!!" );
                if (  numericSize.Value != 7 )
                {
                     numericSize.Value += 1;
                     tabPage2_Leave( this, e );
                     tabPage2_Enter( this, e );
                }
                else
                {
                    MessageBox.Show ( "Игра закончена." );
                }
            } 
        }

        private void tabControl1_Enter ( object sender, EventArgs e )
        {
        }

        private void tabControl1_Leave ( object sender, EventArgs e )
        {
            
        }

        private void tabPage2_Leave ( object sender, EventArgs e )
        {
            for ( int i = 0; i < _gameField.GetLength ( 0 ); i++ )
            {
                for ( int j = 0; j < _gameField.GetLength ( 1 ); j++ )
                {
                    grBoxGameField.Controls.Remove ( _gameField[i, j] );
                }
            }
        }

        private void новаяИграToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            Retry rt = new Retry ();
            rt.ShowDialog ();
            if ( IsRetry )
            {
                tabControl1.DeselectTab ( 1 );
            }
        }

        private void tabBegin_Enter ( object sender, EventArgs e )
        {
            GameForm.IsRetry = false;
        }
       

        private void button3_Click ( object sender, EventArgs e )
        {
            tabControl1.DeselectTab ( 1 );
        }

        private void button2_Click ( object sender, EventArgs e )
        {
            Close ();
        }

        public static bool IsRetry = false;
        int size;
        Field field;
        MyButton[,] _gameField;

        private void tabBegin_Resize(object sender, EventArgs e)
        {
            foreach (var item in Controls)
            {
                if (item is MyButton)
                {
                    
                }
            }
        }
    }
}
