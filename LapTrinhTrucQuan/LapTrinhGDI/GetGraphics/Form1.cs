using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GetGraphics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            //Pen pen = new Pen(Color.Red);
            //g.DrawLine(pen, 0, 0, 200, 200);         
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            //Pen pen = new Pen(Color.Red);
            //g.DrawLine(pen, 0, 0, 200, 200);

            //Bitmap bmp = new Bitmap(200, 200);
            //Graphics g = Graphics.FromImage(bmp);
            //g.FillRectangle(Brushes.Green, 0, 0, 200, 200);
            //g.DrawLine(Pens.Black, new Point(0, 150), new Point(100, 50));
            //e.Graphics.DrawImageUnscaled(bmp, 0, 0);            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(Color.Red, 15);
            g.DrawLine(pen, 0, 0, 200, 200);
            g.Dispose();

        }
    }
}
