using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.CPlusPlus;
using OpenCvSharp.Extensions;
using Emgu.CV;
using Emgu.CV.Structure;
using System.IO;

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

        private void button3_Click(object sender, EventArgs e)
        {
            Image<Bgr, byte> img = new Image<Bgr, byte>(path);


            Image<Gray, byte> grayImage = img.Convert<Gray, byte>();


            CascadeClassifier faceClassifier = new CascadeClassifier("C:/Users/User/Documents/haarcascade_frontalface_default.xml");


            var faces = faceClassifier.DetectMultiScale(grayImage, 1.3, 5);

            foreach (var face in faces)
            {
                img.Draw(face, new Bgr(Color.Red), 2);
            }


            pictureBox1.Image = img.ToBitmap();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(path);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color p = bmp.GetPixel(i, y);
                    int tr = (int)(0.393 * p.R + 0.769 * p.G + 0.189 * p.B);
                    int tg = (int)(0.349 * p.R + 0.686 * p.G + 0.168 * p.B);
                    int tb = (int)(0.272 * p.R + 0.534 * p.G + 0.131 * p.B);
                    tr = Math.Min(tr, 255);
                    tg = Math.Min(tg, 255);
                    tb = Math.Min(tb, 255);
                    bmp.SetPixel(i, y, Color.FromArgb(tr, tg, tb));
                    pictureBox1.Image = bmp;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(path);
            bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Image = bmp;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(path);
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pictureBox1.Image = bmp;
        }

        int brigntess = 0;
        private void button7_Click(object sender, EventArgs e)
        {
            brigntess=brigntess+40;
            Bitmap bmp = new Bitmap(path);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color p = bmp.GetPixel(i, y);
                    int tr = (int)( p.R + brigntess);
                    int tg = (int)( p.G + brigntess);
                    int tb = (int)( p.B + brigntess);
                    tr = Math.Min(tr, 255);
                    tg = Math.Min(tg, 255);
                    tb = Math.Min(tb, 255);
                    bmp.SetPixel(i, y, Color.FromArgb(tr, tg, tb));
                    pictureBox1.Image = bmp;
                }
            }
        }

        int contrast = 0;
        private void button8_Click(object sender, EventArgs e)
        {
            contrast = contrast + 40;
            Bitmap bmp = new Bitmap(path);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color p = bmp.GetPixel(i, y);
                    int tr = (int)((p.R * contrast)/255.0);
                    int tg = (int)((p.G * contrast)/255.0);
                    int tb = (int)((p.B * contrast)/255.0);
                    tr = Math.Min(tr, 255);
                    tg = Math.Min(tg, 255);
                    tb = Math.Min(tb, 255);
                    bmp.SetPixel(i, y, Color.FromArgb(tr, tg, tb));
                    pictureBox1.Image = bmp;
                }
            }
        }
        
        int levels = 4;
        private void button9_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(path);
            int stepSize = 255 / (levels - 1); // Calculate the step size
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color p = bmp.GetPixel(i, y);
                    int r = (p.R / stepSize) * stepSize; // Round to the nearest step
                    int g = (p.G / stepSize) * stepSize;
                    int b = (p.B / stepSize) * stepSize;
                    bmp.SetPixel(i, y, Color.FromArgb(r, g, b));
                    pictureBox1.Image = bmp;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(path);
            Random rand = new Random();
            int intensity = 50;
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color p = bmp.GetPixel(i, y);
                    int r = p.R + rand.Next(-intensity, intensity + 1); 
                    int g = p.G + rand.Next(-intensity, intensity + 1);
                    int b = p.B + rand.Next(-intensity, intensity + 1);

                    r = Math.Max(0, Math.Min(r, 255));
                    g = Math.Max(0, Math.Min(g, 255));
                    b = Math.Max(0, Math.Min(b, 255));

                    bmp.SetPixel(i, y, Color.FromArgb(r, g, b));
                    pictureBox1.Image = bmp;
                }
            }
        }
    }
}
