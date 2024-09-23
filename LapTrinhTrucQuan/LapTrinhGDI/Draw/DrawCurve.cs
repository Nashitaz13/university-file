using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Draw
{
    public partial class DrawCurve : Form
    {
        private float tension = 0.5F;

        public DrawCurve()
        {
            InitializeComponent();
        }

        private void DrawCurve_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Point pt1 = new Point(10, 10);
            Point pt2 = new Point(24, 75);
            Point pt3 = new Point(189, 100);
            Point pt4 = new Point(100, 280);
            Point pt5 = new Point(120, 190);
            Point pt6 = new Point(140, 230);
            Point[] ptsArray = { pt1, pt2, pt3, pt4, pt5, pt6 };
            g.DrawCurve(Pens.Red, ptsArray, tension);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tension = (float)Convert.ToDouble(textBox1.Text);
            Invalidate();
        }
    }
}
