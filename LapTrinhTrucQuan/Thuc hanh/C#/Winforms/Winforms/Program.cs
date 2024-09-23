using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Winforms
{
    class Program
    {
        static void Main(string[] args)
        {
            Time t = new Time();
            Application.Run(t);
        }
    }
            //Form f = new Form();
            //Application.Run(f);
            //f.Text ="Hello World!";
            //f.Show();
            //MessageBox.Show("Hello World!");
            //Form form = new Form();
            //form.Text = "Form Properties";
            //form.BackColor = System.Drawing.Color.BlanchedAlmond;
            //form.Width *= 2;
            //form.Height /= 2;
            //form.FormBorderStyle = FormBorderStyle.FixedSingle;
            //form.MaximizeBox = false;
            //form.Cursor = Cursors.Hand;
            //form.StartPosition = FormStartPosition.CenterScreen;
            //Application.Run(form);

            //int x,y,z;
            //Random r = new Random();
            //x = r.Next(0, 255);
            //y = r.Next(0, 255);
            //z = r.Next(0, 255);
            //Form f = new Form();
            //f.BackColor = System.Drawing.Color.FromArgb(x,y,z);
            //Application.Run(f)

            //Form f = new Form();
            //f.Click+=new EventHandler(f_Click);
            //Application.Run(f);
            //}
            //static void f_Click(Object sender, EventArgs e) {
            //Form f = (Form)sender;
            //Graphics gx = f.CreateGraphics();
            //gx.DrawString("Form 1 \n Form 1\n", f.Font, Brushes.Black, 30, 30); 
            //}
    class Time : Form
    {
        public Time()
        {
            Text = "Timer";
            Timer timer = new Timer();
            timer.Interval = 2 * 1000;
            timer.Tick += new EventHandler(TimerOnTick);
            timer.Enabled = true;
            //Form f = new Form();
            //Button b = new Button();
            //b.Click += new EventHandler(b_Click);
            //Location = new Point(10, 10);
            //f.Controls.Add(b);
            //f.Text = "1";
            //f.BackColor = Color.White;
            //f.AcceptButton = b;
            //Application.Run(f);
        }
        public void TimerOnTick(Object obj, EventArgs e)
        {
            Timer timer = (Timer)obj;
            Graphics g = CreateGraphics();
            int x, y, z;
            Random r = new Random();
            x = r.Next(0, 255);
            y = r.Next(0, 255);
            z = r.Next(0, 255);
            Brush brush = new SolidBrush(Color.FromArgb(x, y, z));
            g.FillRectangle(brush, 0, 0, ClientSize.Width, ClientSize.Height);
        }
            //static void b_Click(Object sender, EventArgs e)
            //{
            //    //Form f = (Form)sender;
            //    Button f1 = (Button)sender;
            //    int x, y, z;
            //    Random r = new Random();
            //    x = r.Next(0, 255);
            //    y = r.Next(0, 255);
            //    z = r.Next(0, 255);
            //    //f1.BackColor = Color.LightSeaGreen;
            //    Form f = (Form)f1.Parent;
            //    f.BackColor = Color.FromArgb(x, y, z);
            //}
    }
}