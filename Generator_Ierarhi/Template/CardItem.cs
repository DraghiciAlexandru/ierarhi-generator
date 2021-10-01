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
            this.Size = new Size(100, 100);
            this.BorderStyle = BorderStyle.Fixed3D;
            this.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
            this.Name = person.Id.ToString();

            this.AllowDrop = true;

            //this.MouseDown += CardItem_MouseDown;

            setPic();
            setNume();
        }

        private void setPic()
        {
            PictureBox pic = new PictureBox();
            pic.Size = new Size(50, 50);
            pic.Location = new Point(25, 10);
            pic.BackgroundImage = person.Picture;
            pic.BackgroundImageLayout = ImageLayout.Stretch;
            pic.Name = person.Id.ToString();

            this.Controls.Add(pic);
        }
        
        private void setNume()
        {
            TextBox txtName = new TextBox();
            txtName.AutoSize = false;
            txtName.Size = new Size(85, 20);
            txtName.Location = new Point(5, 70);
            txtName.Name = person.Id.ToString();
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
