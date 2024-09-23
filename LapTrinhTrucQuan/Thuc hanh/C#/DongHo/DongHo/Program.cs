using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DongHo
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock c = new Clock();
            Application.Run(c);
        }
    }
    class Clock : Form
    {
        private int x, y, z;
        public Clock()
        {
            Text = "Clock";
            Timer timer = new Timer();
            timer.Tick += new EventHandler(TimerOnTick);
            timer.Enabled = true;
            //timer.Interval = 1000;
        }
        public void TimerOnTick(object obj, EventArgs e)
        {
            Timer timer = (Timer)obj;
            Graphics g = CreateGraphics();
            /*Random r = new Random();
            if (DateTime.Now.Second % 2 == 0)
            {
                x = r.Next(0, 255);
                y = r.Next(0, 255);
                z = r.Next(0, 255);
            }
            Brush brush = new SolidBrush(Color.FromArgb(x, y, z));
            g.FillRectangle(brush, 0, 0, ClientSize.Width, ClientSize.Height);*/
            g.Clear(Color.White);
            g.DrawString(DateTime.Now.ToString(), DefaultFont, Brushes.Black, 100, 100); 
        }
    }
}
