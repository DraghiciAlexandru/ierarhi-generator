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
    class CardArchive : Panel
    {
        private BuiltIerarhie builtIerarhie;

        public CardArchive(BuiltIerarhie builtIerarhie)
        {
            this.builtIerarhie = builtIerarhie;

            layout();
        }

        private void layout()
        {
            this.Size = new Size(250, 50);
            this.BackColor = ThemeColor.SecondaryColor;
            this.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);
            this.Name = builtIerarhie.Id.ToString();

            setId();
            setTitlu();
            setPersoane();
        }

        private void setId()
        {
            Label lblId = new Label();
            lblId.Text = builtIerarhie.Id.ToString();
            lblId.Location = new Point(10, 13);
            lblId.AutoSize = false;
            lblId.Size = new Size(30, 25);
            lblId.Name = builtIerarhie.Id.ToString();

            Controls.Add(lblId);
        }

        private void setTitlu()
        {
            Label lblTitlu = new Label();
            lblTitlu.Text = builtIerarhie.Title.ToString();
            lblTitlu.Location = new Point(50, 13);
            lblTitlu.AutoSize = false;
            lblTitlu.Size = new Size(150, 25);
            lblTitlu.Name = builtIerarhie.Id.ToString();

            Controls.Add(lblTitlu);
        }

        private void setPersoane()
        {
            Label lblNrPersoane = new Label();
            lblNrPersoane.Text = "Nr:" + (builtIerarhie.Ierarhie.ToString().Split(',').Length - 1).ToString();
            lblNrPersoane.Location = new Point(200, 13);
            lblNrPersoane.AutoSize = false;
            lblNrPersoane.Size = new Size(60, 25);
            lblNrPersoane.Name = builtIerarhie.Id.ToString();

            Controls.Add(lblNrPersoane);
        }
    }
}
