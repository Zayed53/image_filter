using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace imageform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string path;
        private void load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Uri uri = new Uri(openFileDialog.FileName);
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                path = openFileDialog.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(path);

            for(int i=0; i<bmp.Width; i++)
            {
                for(int y=0; y<bmp.Height; y++)
                {
                    Color p= bmp.GetPixel(i, y);
                    p = Color.FromArgb(255 - p.R, 255 - p.G, 255 - p.B);
                    bmp.SetPixel(i, y, p);
                    pictureBox1.Image = bmp;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(path);

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color p = bmp.GetPixel(i, y);
                    int av = (int)(((p.R) + (p.G) + (p.B)) / 3);
                    p = Color.FromArgb(av, av, av);
                    bmp.SetPixel(i, y, p);
                    pictureBox1.Image = bmp;
                }
            }

        }
    }
}
