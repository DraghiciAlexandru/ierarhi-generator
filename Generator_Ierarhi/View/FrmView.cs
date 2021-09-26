using Generator_Ierarhi.Controler;
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
        private Panel Aside;
        private Panel Main;
        private Button currentBtn;
        private ControlIerarhie controlIerarhie;

        String path = Application.StartupPath;

        public FrmView()
        {
            Header = new Panel();
            Aside = new Panel();
            Main = new Panel();

            controlIerarhie = new ControlIerarhie();

            layoutStaff();
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

        public void layoutStaff()
        {
            this.Text = "";
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(1100, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Location = new Point(150, 75);
            this.MinimumSize = new Size(800, 400);
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            
            SelectThemeColor();

            setAside(Aside);
            setHeader(Header);
            setMain(Main);

        }

        private void setAside(Panel aside)
        {
            aside.Size = new Size(200, 450);
            aside.Location = new Point(0, 100);
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

        private void setBtnAddPerson(Panel aside)
        {
            Button btnAddPerson = new Button();
            btnAddPerson.Size = new Size(275, 50);
            btnAddPerson.Location = new Point(275, 50);
            btnAddPerson.FlatStyle = FlatStyle.Flat;
            btnAddPerson.FlatAppearance.BorderSize = 0;
            btnAddPerson.Text = "Add person";
            btnAddPerson.Name = "btnAddPerson";
            btnAddPerson.TextAlign = ContentAlignment.MiddleCenter;
            btnAddPerson.ForeColor = Color.White;

            btnAddPerson.Dock = DockStyle.Top;

            aside.Controls.Add(btnAddPerson);
        }

        private void setBtnCreate(Panel aside)
        {
            Button btnCreate = new Button();
            btnCreate.Size = new Size(275, 50);
            btnCreate.Location = new Point(275, 50);
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.Text = "Create hierarchy";
            btnCreate.Name = "btnCreate";
            btnCreate.TextAlign = ContentAlignment.MiddleCenter;
            btnCreate.ForeColor = Color.White;

            btnCreate.Dock = DockStyle.Top;
            
            aside.Controls.Add(btnCreate);
        }

        private void setBtnArchihe(Panel aside)
        {
            Button btnArchive = new Button();
            btnArchive.Size = new Size(275, 50);
            btnArchive.Location = new Point(550, 50);
            btnArchive.FlatStyle = FlatStyle.Flat;
            btnArchive.FlatAppearance.BorderSize = 0;
            btnArchive.Text = "Archive";
            btnArchive.Name = "btnArchive";
            btnArchive.TextAlign = ContentAlignment.MiddleCenter;
            btnArchive.ForeColor = Color.White;

            btnArchive.Dock = DockStyle.Top;

            aside.Controls.Add(btnArchive);
        }

        private void setBtnProfil(Panel aside)
        {
            Button btnProfil = new Button();
            btnProfil.Size = new Size(275, 50);
            btnProfil.Location = new Point(825, 50);
            btnProfil.FlatStyle = FlatStyle.Flat;
            btnProfil.FlatAppearance.BorderSize = 0;
            btnProfil.Text = "Profil";
            btnProfil.Name = "btnProfil";
            btnProfil.TextAlign = ContentAlignment.MiddleCenter;
            btnProfil.ForeColor = Color.White;

            btnProfil.Dock = DockStyle.Top;

            aside.Controls.Add(btnProfil);
        }

        private void setHeader(Panel header)
        {
            header.Size = new Size(1100, 100);
            header.Dock = DockStyle.Top;
            header.BackColor = ThemeColor.PrimaryColor;
            header.BorderStyle = BorderStyle.FixedSingle;
            header.MouseDown += Header_MouseDown;

            header.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);

            setBtnClose(header);
            setBtnMax(header);
            setBtnMin(header);

            Controls.Add(header);
        }

        private void setMain(Panel main)
        {
            main.Size = new Size(900, 450);
            main.Location = new Point(200, 100);
            main.BackColor = Color.FromArgb(40, 40, 40);
            main.BorderStyle = BorderStyle.FixedSingle;

            main.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            /*ViewIerarhie viewIerarhie = new ViewIerarhie(1);

            viewIerarhie.Location = new Point(0, 0);

            main.Controls.Add(viewIerarhie);*/

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

        private void setBtnMax(Panel header)
        {
            Button btnMax = new Button();
            btnMax.Size = new Size(30, 30);
            btnMax.Location = new Point(1035, 5);
            btnMax.FlatStyle = FlatStyle.Flat;
            btnMax.FlatAppearance.BorderSize = 0;
            btnMax.Name = "btnMax";
            btnMax.Image = Image.FromFile(path + @"\resources\maximize_window_26px.png");

            btnMax.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            btnMax.Click += BtnMax_Click;

            header.Controls.Add(btnMax);
        }

        private void setBtnMin(Panel header)
        {
            Button btnMin = new Button();
            btnMin.Size = new Size(30, 30);
            btnMin.Location = new Point(1005, 5);
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

        private void BtnMax_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
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
