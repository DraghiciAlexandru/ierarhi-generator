using Generator_Ierarhi.Controler;
using Generator_Ierarhi.Model;
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
    class ViewCreateIerarhie : Panel
    {
        private ControlPerson controlPerson;
        private ControlIerarhie controlIerarhie;

        public ViewCreateIerarhie()
        {
            controlPerson = new ControlPerson();
            controlIerarhie = new ControlIerarhie();

            layout();
        }

        private void layout()
        {
            this.Size = new Size(600, 350);
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);
            this.ForeColor = ThemeColor.PrimaryColor;
            this.Name = "viewCreate";

            setLblSelect();
            setPersoane();
        }

        private void setLblSelect()
        {
            Label lblSelect = new Label();
            lblSelect.Text = "Select admin:";
            lblSelect.AutoSize = false;
            lblSelect.Size = new Size(150, 30);
            lblSelect.Location = new Point(225, 55);

            Controls.Add(lblSelect);
        }

        private void setPersoane()
        {
            
            CardPersoane cardPersoane = new CardPersoane(controlPerson.getAdmins());

            cardPersoane.AutoScroll = true;

            cardPersoane.Size = new Size(600, 250);

            cardPersoane.Location = new Point(0, 100);
            cardPersoane.BorderStyle = BorderStyle.Fixed3D;

            for(int x=0; x<cardPersoane.Controls.Count; x++)
            {
                if (cardPersoane.Controls[x] is CardItem) 
                {
                    cardPersoane.Controls[x].DoubleClick += X_DoubleClick;
                }
            }

            Controls.Add(cardPersoane);
        }

        private void X_DoubleClick(object sender, EventArgs e)
        {
            Console.WriteLine("Apelat");

            CardItem card = sender as CardItem;

            BuiltIerarhie builtIerarhie = new BuiltIerarhie(0, "New", ControlPerson.loged.Id, new Servicii.Ierarhie<Person>(controlPerson.getPerson(card.Person.Id)));

            controlIerarhie.add(builtIerarhie);

            controlIerarhie.save();

            ViewIerarhie viewIerarhie = new ViewIerarhie(controlIerarhie.GetBuilt(controlIerarhie.getLast()).Id);

            Parent.Controls.Add(viewIerarhie);

            Parent.Controls.Remove(this);
        }
    }
}
