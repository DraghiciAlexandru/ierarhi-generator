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
    class CardPersoane : FlowLayoutPanel
    {
        private ControlPerson controlPerson;

        public CardPersoane()
        {
            controlPerson = new ControlPerson();

            layout();
        }

        private void layout()
        {
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.Size = new Size(250, 350);
            this.AutoScroll = true;
            this.WrapContents = true;
            this.Name = "cardPersoane";

            load();
        }

        private void load()
        {
            foreach(Person x in controlPerson.GetPeopleAva())
            {
                CardItem cardItem = new CardItem(x);

                cardItem.Name = x.Id.ToString();

                this.Controls.Add(cardItem);
            }

        }

        
    }
}
