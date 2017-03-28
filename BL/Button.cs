using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class Button: Cell<int>
    {
        public Button (ICellable c, int num): base(c,num)
        {
                
        }


        public override void Move ()
        {
            throw new NotImplementedException ();
        }
    }
}
