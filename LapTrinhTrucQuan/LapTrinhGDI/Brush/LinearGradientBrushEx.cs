using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Brush
{
    public partial class LinearGradientBrushEx : Form
    {
        public LinearGradientBrushEx()
        {
            InitializeComponent();
        }

        private void LinearGradientBrushEx_Paint(object sender, PaintEventArgs e)
        {
            Point pt1 = new Point(0,10);
            Point pt2 = new Point(200, 10);
            LinearGradientBrush brush = new LinearGradientBrush(pt1, pt2, Color.Yellow, Color.Blue);
            e.Graphics.FillEllipse(brush, 0, 20, 200, 100);
            e.Graphics.FillRectangle(brush, 0, 160, 300, 200);
        }
    }
}
