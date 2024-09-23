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
    public partial class DrawEllipse : Form
    {
        public DrawEllipse()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {   
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(80, 80, 50, 50);  
            int x = 20, y = 30, width = 120, height = 230;
            g.DrawEllipse(Pens.DarkBlue, rect);
            g.DrawEllipse(Pens.Gray, x, y, width, height);  
        }
    }
}
