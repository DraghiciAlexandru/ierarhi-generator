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
    class CardAddPerson : Panel
    {
        private ControlPerson controlPerson;
        private PictureBox pic;

        String path = Application.StartupPath;

        public CardAddPerson()
        {
            controlPerson = new ControlPerson();

            layout();
        }

        private void layout()
        {
            this.Size = new Size(900, 550);
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
            setFinish();
        }

        private void addPic()
        {
            pic = new PictureBox();
            pic.Size = new Size(200, 200);
            pic.Location = new Point(150, 175);
            pic.BorderStyle = BorderStyle.Fixed3D;
            pic.BackgroundImageLayout = ImageLayout.Stretch;
            pic.BackColor = ThemeColor.SecondaryColor;
            pic.Name = "pic";

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
                char t = (char)92;
                pic.Name = openFileDialog.FileName.Split(t)[openFileDialog.FileName.Split(t).Length - 1];
            }
            catch
            {
                pic.BackgroundImage = Image.FromFile(@"D:\C#\UIdesign\Dinamic\Generator_Ierarhi\Generator_Ierarhi\bin\Debug\pic\user.png");
                pic.Name = "user.png";
            }

        }

        private void setName()
        {
            TextBox txtName = new TextBox();
            txtName.Name = "txtName";
            txtName.Text = "Name:";
            txtName.Location = new Point(420, 175);
            txtName.Size = new Size(150, 25);
            txtName.BorderStyle = BorderStyle.None;
            txtName.ForeColor = ThemeColor.PrimaryColor;
            txtName.BackColor = Color.FromArgb(40, 40, 40);

            txtName.Enter += Txt_Enter;
            txtName.Leave += Txt_Leave;

            Controls.Add(txtName);
        }

        private void setPassword()
        {
            TextBox txtPassword = new TextBox();
            txtPassword.Name = "txtPassword";
            txtPassword.Text = "Password:";
            txtPassword.Location = new Point(420, 235);
            txtPassword.Size = new Size(150, 25);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.ForeColor = ThemeColor.PrimaryColor;
            txtPassword.BackColor = Color.FromArgb(40, 40, 40);

            txtPassword.Enter += Txt_Enter;
            txtPassword.Leave += Txt_Leave;

            Controls.Add(txtPassword);
        }

        private void setTelefon()
        {
            TextBox txtTelefon = new TextBox();
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Text = "Phone:";
            txtTelefon.Location = new Point(420, 295);
            txtTelefon.Size = new Size(150, 25);
            txtTelefon.BorderStyle = BorderStyle.None;
            txtTelefon.ForeColor = ThemeColor.PrimaryColor;
            txtTelefon.BackColor = Color.FromArgb(40, 40, 40);

            txtTelefon.Enter += Txt_Enter;
            txtTelefon.Leave += Txt_Leave;

            Controls.Add(txtTelefon);
        }

        private void setEmail()
        {
            TextBox txtEmail = new TextBox();
            txtEmail.Name = "txtEmail";
            txtEmail.Text = "Email:";
            txtEmail.Location = new Point(420, 355);
            txtEmail.Size = new Size(300, 25);
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.ForeColor = ThemeColor.PrimaryColor;
            txtEmail.BackColor = Color.FromArgb(40, 40, 40);

            txtEmail.Enter += Txt_Enter;
            txtEmail.Leave += Txt_Leave;

            Controls.Add(txtEmail);
        }

        private void setFuntie()
        {
            ComboBox cboFunctie = new ComboBox();

            cboFunctie.Size = new Size(150, 33);
            cboFunctie.Location = new Point(650, 250);
            cboFunctie.Name = "cboFunctie";

            cboFunctie.Items.Add("Admin");
            cboFunctie.Items.Add("Staff");
            cboFunctie.Items.Add("Person");

            cboFunctie.BackColor = Color.FromArgb(40, 40, 40);
            cboFunctie.ForeColor = ThemeColor.PrimaryColor;
            cboFunctie.DropDownStyle = ComboBoxStyle.DropDownList;

            cboFunctie.FlatStyle = FlatStyle.Flat;

            Controls.Add(cboFunctie);
        }

        private void Txt_Leave(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;

            if (text.Text.Trim(' ') == "")
            {
                if (text.Name == "txtName")
                    text.Text = "Name:";
                else if (text.Name == "txtPassword")
                {
                    text.Text = "Password:";
                    text.PasswordChar = default;
                }
                else if (text.Name == "txtEmail")
                {
                    text.Text = "Email:";
                }
                else if (text.Name == "txtTelefon")
                {
                    text.Text = "Phone:";
                }
            }
        }

        private void Txt_Enter(object sender, EventArgs e)
        {
            TextBox text = sender as TextBox;

            if (text.Text == "Name:" || text.Text == "Password:" || text.Text == "Confirm password:" || text.Text == "Email:" || text.Text == "Phone:")
            {
                if (text.Text == "Password:" || text.Text == "Confirm password:")
                {
                    text.PasswordChar = '●';
                }
                text.Text = "";
            }
        }

        private void setFinish()
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

            btnFinish.Image = Image.FromFile(path + @"\resources\checkmark_48px.png");

            btnFinish.ImageAlign = ContentAlignment.MiddleLeft;
            btnFinish.TextAlign = ContentAlignment.MiddleCenter;
            btnFinish.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnFinish.Click += BtnFinish_Click;

            Controls.Add(btnFinish);
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            TextBox txtName = new TextBox();
            TextBox txtPassword = new TextBox();
            TextBox txtPhone = new TextBox();
            TextBox txtEmail = new TextBox();
            ComboBox cboFunctie = new ComboBox();

            foreach(Control x in this.Controls)
            {
                if (x.Name == "txtName")
                    txtName = x as TextBox;
                else if (x.Name == "txtPassword")
                {
                    txtPassword = x as TextBox;
                }
                else if (x.Name == "txtEmail")
                {
                    txtEmail = x as TextBox;
                }
                else if (x.Name == "txtTelefon")
                {
                    txtPhone = x as TextBox;
                }
                else if (x.Name == "cboFunctie")
                    cboFunctie = x as ComboBox;
            }

            if (cboFunctie.SelectedItem.ToString() == "Admin")
            {
                Admin person = new Admin(0, 0, txtName.Text, txtPassword.Text, txtEmail.Text, txtPhone.Text, pic.Name, 0);

                controlPerson.add(person);

                controlPerson.save();
            }
            else if(cboFunctie.SelectedItem.ToString()=="Staff")
            {
                Staff person = new Staff(0, 0, txtName.Text, txtPassword.Text, txtEmail.Text, txtPhone.Text, pic.Name, 0);

                controlPerson.add(person);

                controlPerson.save();
            }
            else
            {
                Person person = new Person(0, 0, txtName.Text, txtPassword.Text, txtEmail.Text, txtPhone.Text, "Person", pic.Name, 0);

                controlPerson.add(person);

                controlPerson.save();
            }
        }
    }
}
