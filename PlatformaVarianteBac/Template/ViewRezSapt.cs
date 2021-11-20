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
    class ViewRezSapt : FlowLayoutPanel
    {
        private String path;
        private List<CardSaptamani> teste;

        public ViewRezSapt(String path)
        {
            this.path = path;
            teste = new List<CardSaptamani>();

            layout();
        }

        public void layout()
        {
            this.AutoScroll = true;
            this.Size = new Size(1280, 580);
            this.Location = new Point(0, 40);
            this.Padding=new Padding(20);

            load();
        }

        public void load()
        {
            String[] sapt = Directory.GetDirectories(path);

            foreach (String x in sapt)
            {
                CardSaptamani card = new CardSaptamani(path,
                    x.Split((char) 92)[x.Split((char) 92).Length - 1]);

                card.Click += Card_Click;

                this.Controls.Add((card));
            }
        }

        private void Card_Click(object sender, EventArgs e)
        {
            CardSaptamani card = sender as CardSaptamani;
            ViewTest view = new ViewTest(card.FilePath + "\\" + card.Name);

            this.Parent.Controls.Add(view);
            this.Parent.Controls.Remove(this);
        }
    }
}
