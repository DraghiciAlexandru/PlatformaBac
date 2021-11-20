using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlatformaVarianteBac.Template
{
    class CardSaptamani : Button
    {
        String path = Application.StartupPath;
        private String filePath;
        private String nume;

        public String FilePath
        {
            get { return filePath; }
        }

        public String Nume
        {
            get { return nume; }
        }

        public CardSaptamani(String filePath, String nume)
        {
            this.filePath = filePath;
            this.nume = nume;

            layout();
        }

        public void layout()
        {
            this.AutoSize = false;
            this.Size = new Size(100, 100);
            this.BackColor = Color.FromArgb(40, 40, 40);
            this.ForeColor = Color.White;
            this.Image = Image.FromFile(path + @"\resources\folder_48px.png");

            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;

            this.Name = nume;
            this.Text = nume;
            this.TextAlign = ContentAlignment.BottomCenter;
            this.TextImageRelation = TextImageRelation.ImageAboveText;
            this.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
        }
    }
}
