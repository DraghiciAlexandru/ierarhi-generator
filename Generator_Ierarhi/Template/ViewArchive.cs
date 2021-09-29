using Generator_Ierarhi.Controler;
using Generator_Ierarhi.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generator_Ierarhi.Template
{
    class ViewArchive : FlowLayoutPanel
    {
        private ControlIerarhie controlIerarhie;

        private List<BuiltIerarhie> ierarhies;

        public ViewArchive(int idAdmin)
        {
            controlIerarhie = new ControlIerarhie();

            ierarhies = controlIerarhie.GetBuilts(idAdmin);

            layout();
        }

        private void layout()
        {
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.Size = new Size(Screen.FromHandle(this.Handle).WorkingArea.Width - 200, Screen.FromHandle(this.Handle).WorkingArea.Height - 50);
            this.AutoScroll = true;
            this.WrapContents = true;
            this.Name = "viewArchive";

            load();
        }

        private void load()
        {
            foreach(BuiltIerarhie x in ierarhies)
            {
                CardArchive cardArchive = new CardArchive(x);
                cardArchive.Padding = new Padding(10, 10, 10, 10);
                cardArchive.Name = x.Id.ToString();

                cardArchive.DoubleClick += CardArchive_DoubleClick;

                foreach(Control c in cardArchive.Controls)
                {
                    c.DoubleClick += CardArchive_DoubleClick;
                }

                Controls.Add(cardArchive);
            }
        }

        private void CardArchive_DoubleClick(object sender, EventArgs e)
        {
            int idBuilt = 0;

            if(sender is Panel)
            {
                idBuilt = int.Parse(((Panel)sender).Name);
            }
            else if(sender is Label)
            {
                idBuilt = int.Parse(((Label)sender).Name);
            }

            ViewIerarhie viewIerarhie = new ViewIerarhie(idBuilt);

            viewIerarhie.Location = new Point(0, 0);

            this.Parent.Controls.Add(viewIerarhie);

            foreach (Control x in this.Parent.Controls)
            {
                if (x.Name == "viewArchive")
                {
                    Parent.Controls.Remove(x);
                }
            }
        }
    }
}
