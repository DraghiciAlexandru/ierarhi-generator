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
    class CardSalary : Panel
    {
        String path = Application.StartupPath;
        private ControlIerarhie controlIerarhie;
        private ControlPerson controlPerson;

        public List<CardItem> cardItems;
        public BuiltIerarhie builtIerarhie;

        public CardSalary(int id)
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
            this.Name = "pnlSalary";
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

            Controls.Add(txtTitlu);
        }

        private void load()
        {
            Queue<TreeNode<Person>> queue = new Queue<TreeNode<Person>>();

            BST<Person> bst = new BST<Person>();

            bst.insert(builtIerarhie.Ierarhie.root.Data);

            queue.Enqueue(builtIerarhie.Ierarhie.root);

            while (queue.Count != 0)
            {
                if (queue.Peek().Left != null)
                {
                    bst.insert(queue.Peek().Left.Data);
                    queue.Enqueue(queue.Peek().Left);
                }
                if (queue.Peek().Right != null)
                {
                    bst.insert(queue.Peek().Right.Data);
                    queue.Enqueue(queue.Peek().Right);
                }

                queue.Dequeue();

            }

            bst.preorder(bst.Root);

            queue.Enqueue(bst.Root);

            CardItem cardItem = new CardItem(builtIerarhie.Ierarhie.root.Data);

            cardItem.Location = new Point(500, 100);

            cardItems.Add(cardItem);
            this.Controls.Add(cardItem);

            while (queue.Count != 0)
            {
                TreeNode<Person> curent = queue.Peek();

                if (queue.Peek().Left != null)
                {
                    queue.Enqueue(queue.Peek().Left);

                    cardItem = new CardItem(queue.Peek().Left.Data);

                    int x = 0, y = 0;
                    foreach (CardItem z in cardItems)
                    {
                        if (z.Person.Id == curent.Data.Id)
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
                        if (z.Person.Id == curent.Data.Id)
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
        }
    }
}
