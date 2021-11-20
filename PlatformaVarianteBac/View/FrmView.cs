using PlatformaVarianteBac.Servicii;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PlatformaVarianteBac.Template;

namespace PlatformaVarianteBac.View
{
    class FrmView : Form
    {
        private Panel Header;
        private Label lblPage;
        private Panel Aside;
        private Panel Main;
        private Button currentBtn;

        String path = Application.StartupPath;

        public FrmView()
        {
            Header = new Panel();
            Aside = new Panel();
            Main = new Panel();

            layout();
        }

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

        public void layout()
        {
            this.Text = "";
            this.Size = new Size(Screen.FromHandle(this.Handle).WorkingArea.Width, Screen.FromHandle(this.Handle).WorkingArea.Height);
            this.WindowState = FormWindowState.Maximized;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.ControlBox = false;
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Icon = new Icon(path + @"\resources\icons8_test.ico");

            SelectThemeColor();

            setMain(Main);
            setHeader(Header);

            ViewSaptamani view = new ViewSaptamani();

            Main.Controls.Add(view);
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            Main.Controls.Clear();

            ViewSaptamani view=new ViewSaptamani();
            Main.Controls.Add(view);
        }

        private void setHeader(Panel header)
        {
            header.Size = new Size(this.Width, 60);
            header.Location=new Point(200, 0);
            header.BackColor = ThemeColor.PrimaryColor;
            header.BorderStyle = BorderStyle.None;

            header.Dock = DockStyle.Top;

            header.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Regular);

            setBtnClose(header);
            setBtnMin(header);
            setBtnHome(header);

            Controls.Add(header);

            setLblPage(Header);
        }

        private void setBtnHome(Panel header)
        {
            Button btnHome = new Button();
            btnHome.Size = new Size(200, 60);
            btnHome.Location = new Point(0, 0);
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.Text = " Home";
            btnHome.Name = "btnHome";
            btnHome.ForeColor = Color.White;
            btnHome.BackColor = ThemeColor.PrimaryColor;
            btnHome.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);

            btnHome.Image = Image.FromFile(path + @"\resources\home_50px.png");

            btnHome.ImageAlign = ContentAlignment.MiddleLeft;
            btnHome.TextAlign = ContentAlignment.MiddleCenter;
            btnHome.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnHome.Click += BtnHome_Click;

            header.Controls.Add(btnHome);
        }

        private void setLblPage(Panel header)
        {
            lblPage = new Label();

            lblPage.AutoSize = false;
            lblPage.Size = new Size(200, 50);
            lblPage.TextAlign = ContentAlignment.MiddleCenter;

            lblPage.Text = "Varante bac";

            lblPage.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);

            lblPage.ForeColor = Color.White;

            lblPage.Location = new Point(header.Width / 2 - 100, 5);

            header.Controls.Add(lblPage);
        }

        private void setMain(Panel main)
        {
            main.Size = new Size(this.Width, this.Height - 60);
            main.Location = new Point(0, 60);
            main.BackColor = Color.FromArgb(40, 40, 40);
            main.BorderStyle = BorderStyle.None;

            main.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            Controls.Add(main);
        }

        private void setBtnClose(Panel header)
        {
            Button btnClose = new Button();
            btnClose.Size = new Size(30, 30);
            btnClose.Location = new Point(1240, 5);
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
            btnMin.Location = new Point(1210, 5);
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

    }
}
