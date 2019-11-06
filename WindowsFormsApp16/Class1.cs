using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp16
{
    class Class1
    {
        public Class1()
        {
           
        }
        public void Exit()
        {
            MessageBox.Show("We hope you enjoyed our game!Byee! :)");
        }

        public void Restart()
        {
            MessageBox.Show("Application is restarting!Any minute now! ;)");
        }
        public void restapp()
        {
            Application.Restart() ;
           
        }
        public void exitapp()
        {
            Application.Exit();
        }
    }
}
