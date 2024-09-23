using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ViDuBitmap
{
    public partial class BitmapFrm : Form
    {
        public BitmapFrm()
        {
            InitializeComponent();
        }

        private void BitmapFrm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Bitmap curBitmap = new Bitmap("Image.jpg");
            g.DrawImage(curBitmap, 0, 0, curBitmap.Width, curBitmap.Height);
            for (int i = 100; i < 300; i++)
            {
                for (int j = 100; j < 300; j++)
                {
                    Color curColor = curBitmap.GetPixel(i, j);
                    int ret = (curColor.R + curColor.G + curColor.B) / 3;
                    curBitmap.SetPixel(i, j, Color.FromArgb(ret, ret, ret));
                }
            }
            g.DrawImage(curBitmap, 0, 0, curBitmap.Width, curBitmap.Height);            
        }
    }
}
