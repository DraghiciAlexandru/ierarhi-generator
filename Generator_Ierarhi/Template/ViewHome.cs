using Generator_Ierarhi.Controler;
using Restaurant.Servicii;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generator_Ierarhi.Template
{
    class ViewHome : Panel
    {
        ControlIerarhie controlIerarhie;

        public ViewHome()
        {
            controlIerarhie = new ControlIerarhie();

            layout();
        }

        public void layout()
        {
            this.Size = new Size(800, 450);
            this.ForeColor = ThemeColor.PrimaryColor;

            setWelcome();
            setNumar();
        }

        public void setWelcome()
        {
            Label lblTitlu = new Label();
            lblTitlu.AutoSize = false;
            lblTitlu.Size = new Size(430, 150);
            lblTitlu.Location = new Point(170, 30);
            lblTitlu.TextAlign = ContentAlignment.MiddleCenter;
            lblTitlu.Text = "Thanks for using the app " + ControlPerson.loged.Nume + "!";

            lblTitlu.Font = new Font("Microsoft Sans Serif", 26, FontStyle.Bold);

            this.Controls.Add(lblTitlu);
        }

        public void setNumar()
        {
            Label lblNumar = new Label();
            lblNumar.AutoSize = false;
            lblNumar.Size = new Size(440, 100);
            lblNumar.Location = new Point(170, 200);
            lblNumar.TextAlign = ContentAlignment.MiddleCenter;
            lblNumar.Text = "Hierarchies made using this app:" + Environment.NewLine + controlIerarhie.ListIerarhie.Count;

            lblNumar.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);

            this.Controls.Add(lblNumar);
        }
    }
}
