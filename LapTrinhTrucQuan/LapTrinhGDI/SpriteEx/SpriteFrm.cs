using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpriteEx
{
    public partial class SpriteFrm : Form
    {
        private Bitmap sprite;
        private Bitmap backBuffer;
        private Timer timer;
        public Graphics graphics;

        private int index;
        private int curFrameColumn;
        private int curFrameRow;

        public SpriteFrm()
        {
            InitializeComponent();

            graphics = this.CreateGraphics();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            backBuffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            sprite = new Bitmap("Sprite.png");
            index = 0;

            timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 60;
            timer.Tick += new EventHandler(timer_Tick);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Render();
            graphics.DrawImageUnscaled(backBuffer, 0, 0);
        }

        private void Render()
        {
            Graphics g = Graphics.FromImage(backBuffer);

            g.Clear(Color.White);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            curFrameColumn = index % 5;
            curFrameRow = index / 5;

            g.DrawImage(sprite, 120, 120, new Rectangle(curFrameColumn * 64, curFrameRow * 64, 64, 64), GraphicsUnit.Pixel);
            g.Dispose();

            index++;

            if (index > 25)
                index = 0;
            else
                index++;
        }
        
    }
}
