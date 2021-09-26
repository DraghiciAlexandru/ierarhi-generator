using Generator_Ierarhi.Controler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generator_Ierarhi.View
{
    class FrmTest : Form
    {
        ControlPerson controlPerson;

        public FrmTest()
        {
            controlPerson = new ControlPerson();

            MessageBox.Show(controlPerson.People[3].ToString());

        }

    }
}
