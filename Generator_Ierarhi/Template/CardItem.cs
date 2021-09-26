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
    class CardItem : Panel
    {
        private Person person;

        public Person Person
        {
            get { return person; }
            set { person = value; }
        }

        public CardItem(Person person)
        {
            this.person = person;

            layout();
        }

        public void layout()
        {
            this.BackColor = ThemeColor.PrimaryColor;
            this.Size = new Size(150, 150);
            this.BorderStyle = BorderStyle.Fixed3D;
            this.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);

            setPic();
            setNume();
        }

        private void setPic()
        {
            PictureBox pic = new PictureBox();
            pic.Size = new Size(100, 100);
            pic.Location = new Point(25, 10);
            pic.BackgroundImage = person.Picture;
            pic.BackgroundImageLayout = ImageLayout.Stretch;

            this.Controls.Add(pic);
        }

        private void setNume()
        {
            TextBox txtName = new TextBox();
            txtName.AutoSize = false;
            txtName.Size = new Size(135, 20);
            txtName.Location = new Point(5, 120);
            txtName.Name = "txtName";
            txtName.Text = person.Nume;
            txtName.BorderStyle = BorderStyle.None;
            txtName.BackColor = Color.FromArgb(40, 40, 40);
            txtName.ForeColor = ThemeColor.PrimaryColor;
            txtName.TextAlign = HorizontalAlignment.Center;

            txtName.ReadOnly = true;

            this.Controls.Add(txtName);
        }
    }
}
