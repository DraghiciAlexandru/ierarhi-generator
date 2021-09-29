using Generator_Ierarhi.Controler;
using Generator_Ierarhi.Model;
using Generator_Ierarhi.Servicii;
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

        private void layout()
        {
            this.Size = new Size(Screen.FromHandle(this.Handle).WorkingArea.Width - 200, Screen.FromHandle(this.Handle).WorkingArea.Height - 100);
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.AutoScroll = true;
            this.Name = "pnlIerarhie";
            this.Location = new Point(0, 0);

            txtTitlu();
            load();
        }

        private void txtTitlu()
        {
            TextBox txtTitlu = new TextBox();
            txtTitlu.Name = "txtTitlu";
            txtTitlu.Text = builtIerarhie.Title;
            txtTitlu.Location = new Point((this.Width / 2) - 100, 40);
            txtTitlu.Size = new Size(200, 25);
            txtTitlu.BorderStyle = BorderStyle.None;
            txtTitlu.ForeColor = ThemeColor.PrimaryColor;
            txtTitlu.BackColor = Color.FromArgb(40, 40, 40);
            txtTitlu.TextAlign = HorizontalAlignment.Center;

            txtTitlu.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);

            txtTitlu.TextChanged += TxtTitlu_TextChanged;

            Controls.Add(txtTitlu);
        }

        private void TxtTitlu_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox=sender as TextBox;

            controlIerarhie.updateTitlu(builtIerarhie.Id, textBox.Text);

            controlIerarhie.save();
        }

        private void load()
        {
            Queue<TreeNode<Person>> queue = new Queue<TreeNode<Person>>();

            queue.Enqueue(builtIerarhie.Ierarhie.root);

            CardItem cardItem = new CardItem(builtIerarhie.Ierarhie.root.Data);

            cardItem.Location = new Point(500, 100);
            
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
                            y = z.Location.Y + 160;
                            
                            x = (z.Location.X - 250) + (y / 160) * 60;
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
                            y = z.Location.Y + 160;
                            x = (z.Location.X + 250) - (y / 160) * 60;
                        }
                    }

                    cardItem.Location = new Point(x, y);

                    cardItems.Add(cardItem);
                    this.Controls.Add(cardItem);
                }

                queue.Dequeue();
            }

            foreach(CardItem i in cardItems)
            {
                i.DoubleClick += CardItem_DoubleClick;
                foreach (Control x in i.Controls)
                {
                    x.DoubleClick += CardItem_DoubleClick;
                }
            }
        }

        private void CardItem_DoubleClick(object sender, EventArgs e)
        {
            String idPers = "";

            if(sender is CardItem)
            {
                idPers = ((CardItem)sender).Name;
            }
            else if(sender is PictureBox)
            {
                idPers = ((PictureBox)sender).Name;
            }
            else if (sender is TextBox)
            {
                idPers = ((TextBox)sender).Name;
            }

            CardDetails cardDetails = new CardDetails(int.Parse(idPers));

            cardDetails.Location = new Point(0, 0);

            this.Parent.Controls.Add(cardDetails);

            foreach (Control x in this.Parent.Controls)
            {
                if (x.Name == "pnlIerarhie")
                {
                    Parent.Controls.Remove(x);
                }
            }

        }
    }
}
