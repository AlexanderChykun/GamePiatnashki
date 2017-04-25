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
        

        //TODO: сделать кнопки в виде пазлов???(на досуге)
        //TODO: подготовить презентацию экзаменнки

        enum DificultLevel
        {
            easy = 4,
            medium = 5,
            hard = 6,
            veryHard = 7
        }
       
        public GameForm ()
        {
            InitializeComponent ();
            Startsize = this.Size;
        }
        
        private void button1_Click ( object sender, EventArgs e )
        {
            tabControl1.DeselectTab ( 0 );
        }
        
        private void tabPage2_Enter ( object sender, EventArgs e )
        {
            int buttonSize = 50;
            panel1.Controls.Clear();
            _count = 0;
            lblCount.Text = Convert.ToString(_count);
            this.Size = new System.Drawing.Size ( size * buttonSize, size * buttonSize +3*buttonSize);
            field = new Field(size);
            _gameField = new MyButton[size, size];
            
            for ( int i = 0; i < _gameField.GetLength ( 0 ); i++ )
            {
                for ( int j = 0; j < _gameField.GetLength ( 1 ); j++ )
                {
                    MyButton newButton = new MyButton ( field[i, j],i,j);
                    newButton.BackgroundImage = ((System.Drawing.Image) (resources.GetObject ( "buttonImage" )));
                    newButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    newButton.ForeColor = System.Drawing.Color.Gold;
                    newButton.Font = new System.Drawing.Font ( "Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)) );
                    newButton.Location = new System.Drawing.Point ( (j ) * buttonSize, (i) * buttonSize+1 );
                    newButton.Size = new System.Drawing.Size ( buttonSize, buttonSize );
                    newButton.Tag = field[i, j].num;
                    newButton.UseVisualStyleBackColor = false;
                    panel1.Controls.Add ( newButton );
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

            Coordinates coord = new Coordinates (btnCurrent.PosX,btnCurrent.PosY);
            if (btnCurrent.GetCell._c.GetEmptyNeighborCell(coord))
            {
                _count++;
                _gameField[btnCurrent.GetCell._c.ColPosEmpty, btnCurrent.GetCell._c.RowPosEmpty].GetCell.num
                    = btnCurrent.GetCell.num;
                _gameField[btnCurrent.GetCell._c.ColPosEmpty, btnCurrent.GetCell._c.RowPosEmpty].Text
                    = btnCurrent.Text;
                btnCurrent.GetCell.num = 0;
                btnCurrent.Text = "0";
                _gameField[btnCurrent.GetCell._c.ColPosEmpty, btnCurrent.GetCell._c.RowPosEmpty].Show ();
                btnCurrent.Hide();
                lblCount.Text = Convert.ToString ( _count );

            }
            if ( (sender as MyButton).GetCell._c.IsWinGame ( size ) )
            {
                StringBuilder sb = new StringBuilder ();
                sb.Append ( "ВЫ ПОБЕДИЛИ!!!\n" );
                sb.AppendFormat ( "Сделано ходов: {0}", _count );
                MessageBox.Show (sb.ToString());
            } 
        }
        private void tabPage2_Leave ( object sender, EventArgs e )
        {
            this.Size = Startsize;
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

        private void rbEasy_CheckedChanged ( object sender, EventArgs e )
        {
            size = (int)DificultLevel.easy;
        }

        private void rbMedium_CheckedChanged ( object sender, EventArgs e )
        {
            size = (int) DificultLevel.medium;
        }

        private void rbHard_CheckedChanged ( object sender, EventArgs e )
        {
            size = (int) DificultLevel.hard;
        }

        private void radioButton1_CheckedChanged ( object sender, EventArgs e )
        {
            size = (int) DificultLevel.veryHard;
        }

        private void новаяИграToolStripMenuItem1_Click ( object sender, EventArgs e )
        {
            Retry rt = new Retry ();
            rt.ShowDialog ();
            if ( IsRetry )
            {
                tabControl1.DeselectTab ( 1 );
            }
        }

        private void выходToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            button3_Click ( sender, e );
        }

        private void оПрограммеToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            Ruls ruls = new Ruls ();
            ruls.ShowDialog ();
        }
        public static bool IsRetry = false;
        int size;
        Field field;
        MyButton[,] _gameField;
        Size Startsize;
        int _count = 0;
    }
}
