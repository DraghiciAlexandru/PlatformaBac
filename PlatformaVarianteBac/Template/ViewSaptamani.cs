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
    class ViewSaptamani : FlowLayoutPanel
    {
        String path = Application.StartupPath;
        private List<CardSaptamani> saptamani;

        public ViewSaptamani()
        {
            saptamani = new List<CardSaptamani>();

            layout();
        }

        public void layout()
        {
            this.AutoScroll = true;
            this.Size=new Size(1280, 580);
            this.Location = new Point(0, 40);
            this.Padding=new Padding(20);

            load();
        }

        public void load()
        {
            String[] sapt = Directory.GetDirectories(path + @"\rezolvari");

            foreach (String x in sapt)
            {
                CardSaptamani card = new CardSaptamani(path + @"\rezolvari",
                    x.Split((char) 92)[x.Split((char) 92).Length - 1]);

                card.Click += Card_Click;

                saptamani.Add((card));
                this.Controls.Add((card));
            }
        }

        private void Card_Click(object sender, EventArgs e)
        {
            CardSaptamani card=sender as CardSaptamani;
            ViewRezSapt viewRez = new ViewRezSapt(card.FilePath + "\\" + card.Nume);

            this.Parent.Controls.Add(viewRez);
            this.Parent.Controls.Remove(this);
        }

        /*private void setBtnSub1(Panel aside)
        {
            Button btnSub1 = new Button();
            btnSub1.Size = new Size(200, 60);
            btnSub1.Location = new Point(0, 5);
            btnSub1.FlatStyle = FlatStyle.Flat;
            btnSub1.FlatAppearance.BorderSize = 0;
            btnSub1.Text = "Subiectul 1";
            btnSub1.Name = "btnSub1";
            btnSub1.ForeColor = Color.White;

            btnSub1.Dock = DockStyle.Top;

            btnSub1.Image = Image.FromFile(path + @"\resources\1_48px.png");

            btnSub1.ImageAlign = ContentAlignment.MiddleLeft;
            btnSub1.TextAlign = ContentAlignment.MiddleCenter;
            btnSub1.TextImageRelation = TextImageRelation.ImageBeforeText;

            aside.Controls.Add(btnSub1);
        }

        private void setBtnSub2(Panel aside)
        {
            Button btnSub2 = new Button();
            btnSub2.Size = new Size(200, 60);
            btnSub2.Location = new Point(0, 5);
            btnSub2.FlatStyle = FlatStyle.Flat;
            btnSub2.FlatAppearance.BorderSize = 0;
            btnSub2.Text = "Subiectul 2";
            btnSub2.Name = "btnSub2";
            btnSub2.ForeColor = Color.White;

            btnSub2.Dock = DockStyle.Top;

            btnSub2.Image = Image.FromFile(path + @"\resources\2_48px.png");

            btnSub2.ImageAlign = ContentAlignment.MiddleLeft;
            btnSub2.TextAlign = ContentAlignment.MiddleCenter;
            btnSub2.TextImageRelation = TextImageRelation.ImageBeforeText;

            aside.Controls.Add(btnSub2);
        }

        private void setBtnSub3(Panel aside)
        {
            Button btnSub3 = new Button();
            btnSub3.Size = new Size(200, 60);
            btnSub3.Location = new Point(0, 5);
            btnSub3.FlatStyle = FlatStyle.Flat;
            btnSub3.FlatAppearance.BorderSize = 0;
            btnSub3.Text = "Subiectul 3";
            btnSub3.Name = "btnSub3";
            btnSub3.ForeColor = Color.White;

            btnSub3.Dock = DockStyle.Top;

            btnSub3.Image = Image.FromFile(path + @"\resources\3_48px.png");

            btnSub3.ImageAlign = ContentAlignment.MiddleLeft;
            btnSub3.TextAlign = ContentAlignment.MiddleCenter;
            btnSub3.TextImageRelation = TextImageRelation.ImageBeforeText;

            aside.Controls.Add(btnSub3);
        }*/

    }
}
