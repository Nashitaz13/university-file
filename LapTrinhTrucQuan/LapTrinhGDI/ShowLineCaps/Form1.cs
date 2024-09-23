using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShowLineCaps
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void DisplayLineCaps(Graphics g)
        {   
            Pen pen = new Pen(Color.Black);
            Brush brush = new SolidBrush(Color.Black);

            float y = 15.0F;
            float x = 30.0F;

            foreach (LineCap lc in Enum.GetValues(typeof(LineCap)))
            {
                pen.StartCap = lc;
                pen.EndCap = lc;
                pen.Width = 10;

                g.DrawLine(pen, x, y, x + 200, y);
                g.DrawString(lc.ToString(), this.Font, brush, x + 220, y);               

                y += 50.0F;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DisplayLineCaps(g);
        }        
    }
}
