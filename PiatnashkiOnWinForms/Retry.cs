using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PiatnashkiOnWinForms
{
    public partial class Retry : Form
    {
        public Retry ()
        {
            InitializeComponent ();
        }

        private void button1_Click ( object sender, EventArgs e )
        {
            GameForm.IsRetry = true;
            this.Hide ();
        }

        private void button2_Click ( object sender, EventArgs e )
        {
            GameForm.IsRetry = false;
            Close ();
        }
    }
}
