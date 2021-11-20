using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlatformaVarianteBac.Template
{
    class ViewTest : FlowLayoutPanel
    {
        private String path;

        public ViewTest(String path)
        {
            this.path = path;

            layout();
        }

        public void layout()
        {
            this.AutoScroll = true;
            this.VerticalScroll.Visible = false;
            this.Size = new Size(1280, 620);
            this.Location = new Point(0, 0);
            this.Padding = new Padding(203, 20, 0, 10);

            loadPoze();
            loadText();

            this.VerticalScroll.Value = 0;
        }

        public void loadPoze()
        {
            String[] sapt = Directory.GetFiles(path, "*.jpeg");

            foreach (String x in sapt)
            {
                PictureBox pic = new PictureBox();
                pic.Size = new Size(874, 1240);
                pic.BackgroundImage = Image.FromFile(x);
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                Controls.Add(pic);
            }
        }

        public void loadText()
        {
            String[] sapt = Directory.GetFiles(path, "*.txt");

            foreach (String x in sapt)
            {
                TextBox txt = new TextBox();
                txt.Size = new Size(874, 300);
                txt.Multiline = true;
                txt.BackColor = Color.FromArgb(40, 40, 40);
                txt.ForeColor=Color.White;
                txt.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);

                StreamReader reader=new StreamReader(x);
                txt.Text = reader.ReadToEnd();

                Controls.Add(txt);
            }
        }
    }
}
