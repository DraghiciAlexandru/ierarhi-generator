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
    class CardDetails : Panel
    {
        private ControlPerson controlPerson;
        private Person pers;
        private PictureBox pic;

        private Panel superior;
        private Panel inferior1;
        private Panel inferior2;

        public CardDetails(int idPerson)
        {
            controlPerson = new ControlPerson();

            pers = controlPerson.getPerson(idPerson);

            layout();
        }

        private void layout()
        {
            this.Size = new Size(1100, 550);
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);
            this.ForeColor = ThemeColor.PrimaryColor;

            addPic();
            picFile();
            setName();
            setPassword();
            setTelefon();
            setEmail();
            setFuntie();
            setSave();
            setLblSuperior();
            setLblInferior();
            setSuperior();
            setInferior1();
            setInferior2();

            setPersoane();

            loadInferior();
        }

        private void setPersoane()
        {
            CardPersoane cardPersoane = new CardPersoane();

            cardPersoane.Location = new Point(720, 390);

            Controls.Add(cardPersoane);
        }

        private void addPic()
        {
            pic = new PictureBox();
            pic.Size = new Size(200, 200);
            pic.Location = new Point(150, 175);
            pic.BorderStyle = BorderStyle.Fixed3D;
            pic.BackgroundImageLayout = ImageLayout.Stretch;
            pic.BackColor = ThemeColor.SecondaryColor;
            pic.Name = pers.PicFile;

            pic.BackgroundImage = Image.FromFile(@"D:\C#\UIdesign\Dinamic\Generator_Ierarhi\Generator_Ierarhi\bin\Debug\pic\" + pers.PicFile);

            Controls.Add(pic);
        }

        private void picFile()
        {
            Button btnChoose = new Button();
            btnChoose.Size = new Size(150, 50);
            btnChoose.Location = new Point(175, 380);
            btnChoose.FlatStyle = FlatStyle.Flat;
            btnChoose.FlatAppearance.BorderSize = 0;
            btnChoose.Text = "Choose file";
            btnChoose.Name = "btnChoose";
            btnChoose.TextAlign = ContentAlignment.MiddleCenter;
            btnChoose.ForeColor = Color.White;

            btnChoose.Click += BtnChoose_Click;

            Controls.Add(btnChoose);
        }

        private void BtnChoose_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = @"D:\C#\UIdesign\Dinamic\Generator_Ierarhi\Generator_Ierarhi\bin\Debug\pic";

            openFileDialog.ShowDialog();

            try
            {
                pic.BackgroundImage = Image.FromFile(openFileDialog.FileName);
            }
            catch
            {
                pic.BackgroundImage = Image.FromFile(@"D:\C#\UIdesign\Dinamic\Generator_Ierarhi\Generator_Ierarhi\bin\Debug\pic\user.png");
            }

            char t = (char)92;

            pic.Name = openFileDialog.FileName.Split(t)[openFileDialog.FileName.Split(t).Length - 1];
        }

        private void setName()
        {
            TextBox txtName = new TextBox();
            txtName.Name = "txtName";
            txtName.Text = pers.Nume;
            txtName.Location = new Point(415, 195);
            txtName.Size = new Size(150, 25);
            txtName.BorderStyle = BorderStyle.None;
            txtName.ForeColor = ThemeColor.PrimaryColor;
            txtName.BackColor = Color.FromArgb(40, 40, 40);

            txtName.TextChanged += TxtName_TextChanged;

            Controls.Add(txtName);
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;

            controlPerson.updatePersonNume(pers.Id, text.Text);
        }

        private void setPassword()
        {
            TextBox txtPassword = new TextBox();
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Text = pers.Password;
            txtPassword.Location = new Point(415, 255);
            txtPassword.Size = new Size(150, 25);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.ForeColor = ThemeColor.PrimaryColor;
            txtPassword.BackColor = Color.FromArgb(40, 40, 40);

            txtPassword.TextChanged += TxtPassword_TextChanged;

            Controls.Add(txtPassword);
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;

            controlPerson.updatePersonPassword(pers.Id, text.Text);
        }

        private void setTelefon()
        {
            TextBox txtTelefon = new TextBox();
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Text = pers.Telefon;
            txtTelefon.Location = new Point(415, 315);
            txtTelefon.Size = new Size(150, 25);
            txtTelefon.BorderStyle = BorderStyle.None;
            txtTelefon.ForeColor = ThemeColor.PrimaryColor;
            txtTelefon.BackColor = Color.FromArgb(40, 40, 40);

            txtTelefon.TextChanged += TxtTelefon_TextChanged;

            Controls.Add(txtTelefon);
        }

        private void TxtTelefon_TextChanged(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;

            controlPerson.updatePersonTelefon(pers.Id, text.Text);
        }

        private void setEmail()
        {
            TextBox txtEmail = new TextBox();
            txtEmail.Name = "txtEmail";
            txtEmail.Text = pers.Email;
            txtEmail.Location = new Point(415, 375);
            txtEmail.Size = new Size(300, 25);
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.ForeColor = ThemeColor.PrimaryColor;
            txtEmail.BackColor = Color.FromArgb(40, 40, 40);

            txtEmail.TextChanged += TxtEmail_TextChanged;

            Controls.Add(txtEmail);
        }

        private void TxtEmail_TextChanged(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;

            controlPerson.updatePersonEmail(pers.Id, text.Text);
        }

        private void setFuntie()
        {
            ComboBox cboFunctie = new ComboBox();

            cboFunctie.Size = new Size(150, 33);
            cboFunctie.Location = new Point(415, 435);

            cboFunctie.Items.Add("Admin");
            cboFunctie.Items.Add("Staff");
            cboFunctie.Items.Add("Person");

            if (pers.Tip == "Admin")
            {
                cboFunctie.SelectedItem = cboFunctie.Items[0];
            }
            else if (pers.Tip == "Staff")
            {
                cboFunctie.SelectedItem = cboFunctie.Items[1];
            }
            else
            {
                cboFunctie.SelectedItem = cboFunctie.Items[2];
            }

            cboFunctie.SelectedIndexChanged += CboFunctie_SelectedIndexChanged;

            Controls.Add(cboFunctie);
        }

        private void CboFunctie_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = sender as ComboBox;

            if (combo.SelectedIndex == 0) 
            {
                controlPerson.updatePersonTip(pers.Id, "Admin");
            }
            else if(combo.SelectedIndex==1)
            {
                controlPerson.updatePersonTip(pers.Id, "Staff");
            }
            else
            {
                controlPerson.updatePersonTip(pers.Id, "Person");
            }
        }

        private void setSave()
        {
            Button btnFinish = new Button();
            btnFinish.Size = new Size(150, 50);
            btnFinish.Location = new Point(425, 485);
            btnFinish.FlatStyle = FlatStyle.Flat;
            btnFinish.FlatAppearance.BorderSize = 0;
            btnFinish.Text = "Finish";
            btnFinish.Name = "btnFinish";
            btnFinish.TextAlign = ContentAlignment.MiddleCenter;
            btnFinish.ForeColor = Color.White;

            btnFinish.Click += BtnFinish_Click;

            Controls.Add(btnFinish);
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            controlPerson.save();

            Parent.Controls.Remove(this);
        }

        private void setLblSuperior()
        {
            Label lblSuperior = new Label();

            lblSuperior.Text = "Superior:";
            lblSuperior.Location = new Point(785, 25);
            lblSuperior.ForeColor = ThemeColor.PrimaryColor;

            this.Controls.Add(lblSuperior);
        }

        private void setLblInferior()
        {
            Label lblInferior = new Label();

            lblInferior.Text = "Inferior:";
            lblInferior.Location = new Point(795, 210);
            lblInferior.ForeColor = ThemeColor.PrimaryColor;

            this.Controls.Add(lblInferior);
        }

        private void setSuperior()
        {
            superior = new Panel();
            superior.Size = new Size(110, 110);
            superior.BorderStyle = BorderStyle.Fixed3D;
            superior.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);

            superior.Location = new Point(780, 55);

            superior.AllowDrop = true;

            if (pers.IdUpper != 0) 
            {
                CardItem cardItem = new CardItem(controlPerson.getPerson(pers.IdUpper));

                cardItem.Location = new Point(3, 3);

                superior.Controls.Add(cardItem);
            }

            superior.DragEnter += Superior_DragEnter;
            superior.DragDrop += Superior_DragDrop;

            Controls.Add(superior);
        }

        private void Superior_DragDrop(object sender, DragEventArgs e)
        {
            CardItem pnlDrag = (CardItem)e.Data.GetData(typeof(CardItem));

            controlPerson.updatePersonUpper(pers.Id, int.Parse(pnlDrag.Name));

            pnlDrag.Location = new Point(3, 3);

            superior.Controls.Add(pnlDrag);
        }

        private void Superior_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(CardItem)))
            {
                if (superior.Controls.Count == 0)
                    e.Effect = DragDropEffects.Copy;
            }
        }

        private void loadInferior()
        {
            foreach (Person x in controlPerson.People)
            { 
                if(x.IdUpper==pers.Id)
                {
                    if(inferior1.Controls.Count == 0)
                    {
                        CardItem cardItem = new CardItem(controlPerson.getPerson(x.Id));

                        cardItem.Location = new Point(3, 3);

                        inferior1.Controls.Add(cardItem);
                    }
                    else
                    {
                        CardItem cardItem = new CardItem(controlPerson.getPerson(x.Id));

                        cardItem.Location = new Point(3, 3);

                        inferior2.Controls.Add(cardItem);
                    }
                }
            }

        }

        private void setInferior1()
        {
            inferior1 = new Panel();
            inferior1.Size = new Size(110, 110);
            inferior1.BorderStyle = BorderStyle.Fixed3D;
            inferior1.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);

            inferior1.Location = new Point(720, 260);

            inferior1.AllowDrop = true;

            inferior1.DragEnter += Inferior1_DragEnter;
            inferior1.DragDrop += Inferior1_DragDrop;

            Controls.Add(inferior1);
        }

        private void Inferior1_DragDrop(object sender, DragEventArgs e)
        {
            CardItem pnlDrag = (CardItem)e.Data.GetData(typeof(CardItem));

            controlPerson.updatePersonUpper(int.Parse(pnlDrag.Name), pers.Id);

            pnlDrag.Location = new Point(3, 3);

            inferior1.Controls.Add(pnlDrag);
        }

        private void Inferior1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(CardItem)))
            {
                if (inferior1.Controls.Count == 0)
                    e.Effect = DragDropEffects.Copy;
            }
        }

        private void setInferior2()
        {
            inferior2 = new Panel();
            inferior2.Size = new Size(110, 110);
            inferior2.BorderStyle = BorderStyle.Fixed3D;
            inferior2.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);

            inferior2.Location = new Point(840, 260);

            inferior2.AllowDrop = true;

            inferior2.DragEnter += Inferior2_DragEnter;
            inferior2.DragDrop += Inferior2_DragDrop;

            Controls.Add(inferior2);
        }

        private void Inferior2_DragDrop(object sender, DragEventArgs e)
        {
            CardItem pnlDrag = (CardItem)e.Data.GetData(typeof(CardItem));

            controlPerson.updatePersonUpper(int.Parse(pnlDrag.Name), pers.Id);

            pnlDrag.Location = new Point(3, 3);

            inferior2.Controls.Add(pnlDrag);
        }

        private void Inferior2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(CardItem)))
            {
                if (inferior2.Controls.Count == 0)
                    e.Effect = DragDropEffects.Copy;
            }
        }
    }
}
