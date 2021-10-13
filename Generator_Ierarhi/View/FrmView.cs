using Generator_Ierarhi.Controler;
using Generator_Ierarhi.Model;
using Generator_Ierarhi.Template;
using Restaurant.Servicii;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generator_Ierarhi.View
{
    class FrmView : Form
    {
        private Panel Header;
        private Label lblPage;
        private Panel Aside;
        private Panel Main;
        private Button currentBtn;
        private ControlIerarhie controlIerarhie;
        private ControlPerson controlPerson;

        String path = Application.StartupPath;

        public FrmView()
        {
            Header = new Panel();
            Aside = new Panel();
            Main = new Panel();

            controlIerarhie = new ControlIerarhie();
            controlPerson = new ControlPerson();

            setLogin();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParm, int lParam);

        private void SelectThemeColor()
        {
            Random random = new Random();
            int index = random.Next(ThemeColor.ColorList.Count);
            string color = ThemeColor.ColorList[index];
            ThemeColor.PrimaryColor = ColorTranslator.FromHtml(color);
            ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(ThemeColor.PrimaryColor, -0.3);
        }

        private void ActivateBtn(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentBtn != (Button)btnSender)
                {
                    DisableBtn();
                    currentBtn = (Button)btnSender;
                    currentBtn.BackColor = ThemeColor.SecondaryColor;
                }
            }
        }

        private void DisableBtn()
        {
            foreach (Control prevBtn in Aside.Controls)
            {
                if (prevBtn.GetType() == typeof(Button))
                {
                    prevBtn.BackColor = Color.FromArgb(40, 40, 40);
                }
            }
        }

        public void setLogin()
        {
            this.Text = "";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Location = new Point(300, 200);
            this.ControlBox = false;
            this.Size = new Size(500, 300);
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = new Icon(path + @"\resources\icons8_hierarchy.ico");

            SelectThemeColor();

            setHeader(Header);
            lblPage.Location = new Point(150, 5);

            ViewLogin viewLogin = new ViewLogin();
            Controls.Add(viewLogin);

            Button btnLogin = new Button();

            btnLogin = viewLogin.btnLogin;
            btnLogin.Click += BtnLogin_Click;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            ViewLogin viewLogin = new ViewLogin();

            foreach (Control x in Controls)
            {
                if (x.Name == "pnlLogin")
                    viewLogin = x as ViewLogin;
            }

            if (viewLogin.txtName.Text != "Name:" && viewLogin.txtPass.Text != "Password:")
            {
                if (controlPerson.getPerson(viewLogin.txtName.Text) != null)
                {
                    if (controlPerson.getPerson(viewLogin.txtName.Text).Password == viewLogin.txtPass.Text)
                    {
                        ControlPerson.loged = controlPerson.getPerson(viewLogin.txtName.Text);
                        Controls.Clear();

                        if (ControlPerson.loged.Tip == "Admin")
                            layoutStaff();
                        else
                            layoutPerson();
                    }
                }
            }

        }
        
        public void layoutStaff()
        {
            this.Text = "";
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(Screen.FromHandle(this.Handle).WorkingArea.Width, Screen.FromHandle(this.Handle).WorkingArea.Height);
            this.WindowState = FormWindowState.Maximized;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            
            setAside(Aside);
            Header.Controls.Clear();
            setHeader(Header);
            lblPage.Text = "Home";
            setBtnHome(Header);
            setMain(Main);
            ViewHome viewHome = new ViewHome();
            viewHome.Location = new Point(175, 75);

            Main.Controls.Add(viewHome);
        }

        public void layoutPerson()
        {
            this.Text = "";
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(Screen.FromHandle(this.Handle).WorkingArea.Width, Screen.FromHandle(this.Handle).WorkingArea.Height);
            this.WindowState = FormWindowState.Maximized;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            setAsideClient(Aside);
            Header.Controls.Clear();
            setHeader(Header);
            setMain(Main);
            ViewHome viewHome = new ViewHome();
            viewHome.Location = new Point(175, 75);

            Main.Controls.Add(viewHome);
        }

        private void setAside(Panel aside)
        {
            aside.Size = new Size(200, this.Height - 70);
            aside.Location = new Point(0, 70);
            aside.BackColor = Color.FromArgb(40, 40, 40);
            aside.BorderStyle = BorderStyle.FixedSingle;
            aside.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);
            aside.ForeColor = Color.FromArgb(32, 178, 170);

            aside.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            setBtnProfil(aside);
            setBtnArchihe(aside);
            setBtnCreate(aside);
            setBtnAddPerson(aside);

            Controls.Add(aside);
        }

        private void setAsideClient(Panel aside)
        {
            aside.Size = new Size(200, this.Height - 50);
            aside.Location = new Point(0, 50);
            aside.BackColor = Color.FromArgb(40, 40, 40);
            aside.BorderStyle = BorderStyle.FixedSingle;
            aside.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);
            aside.ForeColor = Color.FromArgb(32, 178, 170);

            aside.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            setBtnProfil(aside);
            setBtnViewIerarhie(aside);

            Controls.Add(aside);
        }

        private void setBtnViewIerarhie(Panel aside)
        {
            Button btnView = new Button();
            btnView.Size = new Size(275, 50);
            btnView.Location = new Point(275, 50);
            btnView.FlatStyle = FlatStyle.Flat;
            btnView.FlatAppearance.BorderSize = 0;
            btnView.Text = "  My hierarchy";
            btnView.Name = "btnView";
            btnView.TextAlign = ContentAlignment.MiddleCenter;
            btnView.ForeColor = Color.White;

            btnView.Dock = DockStyle.Top;

            btnView.Click += BtnView_Click;

            aside.Controls.Add(btnView);
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            ActivateBtn(sender);

            Main.Controls.Clear();

            lblPage.Text = "My hierarchy";

            if (controlIerarhie.idApartine(ControlPerson.loged.Id) != 0)
            {
                ViewIerarhie viewIerarhie = new ViewIerarhie(controlIerarhie.idApartine(ControlPerson.loged.Id));
                viewIerarhie.removeEvent();
                viewIerarhie.Location = new Point(0, 0);

                Main.Controls.Add(viewIerarhie);
            }
        }

        private void setBtnAddPerson(Panel aside)
        {
            Button btnAddPerson = new Button();
            btnAddPerson.Size = new Size(275, 50);
            btnAddPerson.Location = new Point(275, 60);
            btnAddPerson.FlatStyle = FlatStyle.Flat;
            btnAddPerson.FlatAppearance.BorderSize = 0;
            btnAddPerson.Text = "  Add person";
            btnAddPerson.Name = "btnAddPerson";
            btnAddPerson.ImageAlign = ContentAlignment.MiddleLeft;
            btnAddPerson.TextAlign = ContentAlignment.MiddleLeft;
            btnAddPerson.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnAddPerson.ForeColor = Color.White;

            btnAddPerson.Image = Image.FromFile(path + @"\resources\add_administrator_50px.png");

            btnAddPerson.Dock = DockStyle.Top;

            btnAddPerson.Click += BtnAddPerson_Click;

            aside.Controls.Add(btnAddPerson);
        }

        private void BtnAddPerson_Click(object sender, EventArgs e)
        {
            ActivateBtn(sender);

            Main.Controls.Clear();

            CardAddPerson cardAdd = new CardAddPerson();

            cardAdd.Location = new Point(0, 0);

            lblPage.Text = "Add person";

            Main.Controls.Add(cardAdd);
        }

        private void setBtnCreate(Panel aside)
        {
            Button btnCreate = new Button();
            btnCreate.Size = new Size(275, 60);
            btnCreate.Location = new Point(275, 50);
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.Text = "   Create      hierarchy";
            btnCreate.Name = "btnCreate";
            btnCreate.ForeColor = Color.White;

            btnCreate.Image = Image.FromFile(path + @"\resources\create_48px.png");

            btnCreate.ImageAlign = ContentAlignment.MiddleLeft;
            btnCreate.TextAlign = ContentAlignment.MiddleCenter;
            btnCreate.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnCreate.Dock = DockStyle.Top;

            btnCreate.Click += BtnCreate_Click;

            aside.Controls.Add(btnCreate);
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            ActivateBtn(sender);

            Main.Controls.Clear();

            ViewCreateIerarhie viewCreateIerarhie = new ViewCreateIerarhie();

            viewCreateIerarhie.Location = new Point(250, 150);

            lblPage.Text = "Create";

            Main.Controls.Add(viewCreateIerarhie);
        }

        private void setBtnArchihe(Panel aside)
        {
            Button btnArchive = new Button();
            btnArchive.Size = new Size(275, 60);
            btnArchive.Location = new Point(550, 50);
            btnArchive.FlatStyle = FlatStyle.Flat;
            btnArchive.FlatAppearance.BorderSize = 0;
            btnArchive.Text = "   Archive";
            btnArchive.Name = "btnArchive";
            btnArchive.ForeColor = Color.White;

            btnArchive.Image = Image.FromFile(path + @"\resources\archive_folder_50px.png");

            btnArchive.ImageAlign = ContentAlignment.MiddleLeft;
            btnArchive.TextAlign = ContentAlignment.MiddleCenter;
            btnArchive.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnArchive.Dock = DockStyle.Top;

            btnArchive.Click += BtnArchive_Click;

            aside.Controls.Add(btnArchive);
        }

        private void BtnArchive_Click(object sender, EventArgs e)
        {
            ActivateBtn(sender);

            Main.Controls.Clear();

            ViewArchive viewArchive = new ViewArchive(ControlPerson.loged.Id);
            viewArchive.Location = new Point(0, 0);

            lblPage.Text = "Archive";

            Main.Controls.Add(viewArchive);
        }

        private void setBtnProfil(Panel aside)
        {
            Button btnProfil = new Button();
            btnProfil.Size = new Size(275, 60);
            btnProfil.Location = new Point(825, 50);
            btnProfil.FlatStyle = FlatStyle.Flat;
            btnProfil.FlatAppearance.BorderSize = 0;
            btnProfil.Text = "   Profil";
            btnProfil.Name = "btnProfil";
            btnProfil.ForeColor = Color.White;

            btnProfil.Image = Image.FromFile(path + @"\resources\male_user_50px.png");

            btnProfil.ImageAlign = ContentAlignment.MiddleLeft;
            btnProfil.TextAlign = ContentAlignment.MiddleCenter;
            btnProfil.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnProfil.Dock = DockStyle.Top;

            btnProfil.Click += BtnProfil_Click;

            aside.Controls.Add(btnProfil);
        }

        private void BtnProfil_Click(object sender, EventArgs e)
        {
            ActivateBtn(sender);

            Main.Controls.Clear();

            CardProfil cardProfil = new CardProfil();

            cardProfil.Location = new Point(200, 200);

            cardProfil.picLogout.Click += PicLogout_Click;

            lblPage.Text = "Profil";

            Main.Controls.Add(cardProfil);
        }

        private void PicLogout_Click(object sender, EventArgs e)
        {
            ControlPerson.loged = null;

            Header.Controls.Clear();
            Main.Controls.Clear();
            Aside.Controls.Clear();

            this.Controls.Clear();

            this.Location = new Point(300, 200);
            this.ControlBox = false;
            this.Size = new Size(500, 300);

            setLogin();
        }

        private void setHeader(Panel header)
        {
            header.Size = new Size(1100, 70);
            header.Dock = DockStyle.Top;
            header.BackColor = ThemeColor.PrimaryColor;
            header.BorderStyle = BorderStyle.FixedSingle;
            
            header.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);

            setBtnClose(header);
            setBtnMin(header);

            Controls.Add(header);

            setLblPage(Header);
        }

        private void setBtnHome(Panel header)
        {
            Button btnHome = new Button();
            btnHome.Size = new Size(200, 60);
            btnHome.Location = new Point(0, 5);
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.Text = " Home";
            btnHome.Name = "btnHome";
            btnHome.ForeColor = Color.White;

            btnHome.Image = Image.FromFile(path + @"\resources\home_50px.png");

            btnHome.ImageAlign = ContentAlignment.MiddleLeft;
            btnHome.TextAlign = ContentAlignment.MiddleCenter;
            btnHome.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnHome.Click += BtnHome_Click;

            header.Controls.Add(btnHome);
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            DisableBtn();
            Main.Controls.Clear();

            ViewHome viewHome = new ViewHome();
            viewHome.Location = new Point(150, 75);

            lblPage.Text = "Home";

            Main.Controls.Add(viewHome);
        }

        private void setLblPage(Panel header)
        {
            lblPage = new Label();

            lblPage.AutoSize = false;
            lblPage.Size = new Size(200, 50);
            lblPage.TextAlign = ContentAlignment.MiddleCenter;

            lblPage.Text = "Login";

            lblPage.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            lblPage.ForeColor = Color.White;

            lblPage.Location = new Point(header.Width / 2, 10);

            header.Controls.Add(lblPage);
        }

        private void setMain(Panel main)
        {
            main.Size = new Size(this.Width - 200, this.Height - 70);
            main.Location = new Point(200, 70);
            main.BackColor = Color.FromArgb(40, 40, 40);
            main.BorderStyle = BorderStyle.FixedSingle;

            main.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            Controls.Add(main);
        }

        private void setBtnClose(Panel header)
        {
            Button btnClose = new Button();
            btnClose.Size = new Size(30, 30);
            btnClose.Location = new Point(1065, 5);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Name = "btnClose";
            btnClose.Image = Image.FromFile(path + @"\resources\close_window_26px.png");

            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            btnClose.Click += BtnClose_Click;

            header.Controls.Add(btnClose);
        }

        private void setBtnMin(Panel header)
        {
            Button btnMin = new Button();
            btnMin.Size = new Size(30, 30);
            btnMin.Location = new Point(1035, 5);
            btnMin.FlatStyle = FlatStyle.Flat;
            btnMin.FlatAppearance.BorderSize = 0;
            btnMin.Name = "btnMin";
            btnMin.Image = Image.FromFile(path + @"\resources\minimize_window_26px.png");

            btnMin.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            btnMin.Click += BtnMin_Click;

            header.Controls.Add(btnMin);
        }

        private void BtnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
