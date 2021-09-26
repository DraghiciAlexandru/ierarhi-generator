using Generator_Ierarhi.Controler;
using Generator_Ierarhi.Model;
using Generator_Ierarhi.Servicii;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generator_Ierarhi.Template
{
    class ViewIerarhie : Panel
    {
        private ControlIerarhie controlIerarhie;
        private ControlPerson controlPerson;

        public List<CardItem> cardItems;
        public BuiltIerarhie builtIerarhie;

        public ViewIerarhie(int id)
        {
            controlIerarhie = new ControlIerarhie();
            controlPerson = new ControlPerson();

            cardItems = new List<CardItem>();
            builtIerarhie = controlIerarhie.GetBuilt(id);

            layout();
        }

        public void layout()
        {
            this.Size = new Size(900, 450);
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.AutoScroll = true;
            this.Name = "pnlIerarhie";
            this.Location = new Point(0, 0);

            load();
        }

        public void load()
        {
            Queue<TreeNode<Person>> queue = new Queue<TreeNode<Person>>();

            queue.Enqueue(builtIerarhie.Ierarhie.root);

            CardItem cardItem = new CardItem(builtIerarhie.Ierarhie.root.Data);

            cardItem.Location = new Point(375, 30);

            cardItems.Add(cardItem);
            this.Controls.Add(cardItem);

            while (queue.Count != 0)
            {
                if (queue.Peek().Left != null)
                {
                    queue.Enqueue(queue.Peek().Left);

                    cardItem = new CardItem(queue.Peek().Left.Data);

                    int x = 0, y = 0;
                    foreach(CardItem z in cardItems)
                    {
                        if (z.Person.Id == queue.Peek().Left.Data.IdUpper)
                        {
                            x = z.Location.X - 250;
                            y = z.Location.Y + 160;
                        }
                    }

                    cardItem.Location = new Point(x, y);

                    cardItems.Add(cardItem);
                    this.Controls.Add(cardItem);
                }
                if (queue.Peek().Right != null)
                {
                    queue.Enqueue(queue.Peek().Right);

                    cardItem = new CardItem(queue.Peek().Right.Data);

                    int x = 0, y = 0;
                    foreach (CardItem z in cardItems)
                    {
                        if (z.Person.Id == queue.Peek().Right.Data.IdUpper)
                        {
                            x = z.Location.X + 250;
                            y = z.Location.Y + 160;
                        }
                    }

                    cardItem.Location = new Point(x, y);

                    cardItems.Add(cardItem);
                    this.Controls.Add(cardItem);
                }

                queue.Dequeue();
            }


        }
    }
}
