using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameHungTrung
{
    class HungTrung : Form
    {
        Image Ro, Trung;
        Timer timer = new Timer();
        int x = 200, diem = 0, velocity = 15, heart = 3;
        int[] trung = new int[5];
        int[] y = new int[3];
        Random r = new Random();
        Graphics graphics;
        public HungTrung()
        {
            Height = 500;
            Width = 400;
            Text = "Hung Trung";
            Trung = Image.FromFile("C:/Users/Bien/Documents/Visual Studio 2013/Projects/GameHungTrung/trung.png");
            Ro = Image.FromFile("C:/Users/Bien/Documents/Visual Studio 2013/Projects/GameHungTrung/ro.png");

            y[0] = 0;
            y[1] = y[0] - 150;
            y[2] = y[1] - 150;

            timer.Enabled = true;
            timer.Tick += TimerOnTick;
            timer.Interval = 100;
            Invalidate();
        }
        public void TimerOnTick(object obj, EventArgs ea)
        {
            if (heart == 0)
                velocity = 0;
            for (int j = 0; j < 3; j++)
            {
                y[j] += velocity;
                if (y[j] > 365)
                {
                    trung[j] = r.Next(40, 350);
                    y[j] = 0;
                }
                Invalidate();
                if (y[j] == 360 && trung[j] >= x && trung[j] + Trung.Width <= x + Ro.Width)
                    diem++;
                if (y[j] == 360 && (trung[j] < x || trung[j] + Trung.Width > x + Ro.Width) && heart >= 1)
                    heart--;
            }
        }
        protected override void OnKeyDown(KeyEventArgs kea)
        {
            if (kea.KeyCode == Keys.Left)
                x -= 30;
            if (kea.KeyCode == Keys.Right)
                x += 30;
            if (x + Ro.Width - 30 < 0)
                x = -Ro.Width + 30;
            if (x + 50 > 400)
                x = 400 - 50;
            Invalidate();
            base.OnKeyDown(kea);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            graphics = this.CreateGraphics();
            graphics.DrawImage(Ro, x, 400);
            for (int j = 0; j < 3; j++)
            {
                graphics.DrawImage(Trung, trung[j], y[j]);
            }
            graphics.DrawString("Mang: " + heart.ToString(), DefaultFont, new SolidBrush(Color.Black), new Point(300, 20));
            graphics.DrawString("Diem: " + diem.ToString(), DefaultFont, new SolidBrush(Color.Black), new Point(20, 20));
            if (heart <= 0)
            {
                graphics.DrawString("GAME OVER", DefaultFont, new SolidBrush(Color.Blue), new Point(150, 200));
                graphics.DrawString("Diem cua ban: " + diem.ToString(), DefaultFont, new SolidBrush(Color.Blue), new Point(140, 300));
            }
            base.OnPaint(e);
        }
    }
}
