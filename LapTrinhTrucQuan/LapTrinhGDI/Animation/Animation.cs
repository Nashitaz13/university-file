using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Animation
{
    public partial class Animation : Form
    {
        protected int x = 0;
        protected int y = 0;

        public Animation()
        {
            InitializeComponent();
            Timer timer1 = new Timer();
            timer1.Tick +=new EventHandler(timer1_Tick);
            timer1.Enabled = true;
            timer1.Interval = 60;
            timer1.Start();
        }

        private void Animation_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Red);
            g.DrawRectangle(pen, x, 10, 100, 50);
            g.DrawRectangle(pen, 10, y, 100, 50);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x = (x + 1) % 200; y = (y + 1) % 200;
            Refresh();
        }
    }
}
