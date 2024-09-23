using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoubleBuffer
{
    public partial class Form1 : Form
    {
        private Bitmap backBuffer;
        float angle;
        bool doBuffer;
        private Timer timer1;        

        public Form1()
        {
            InitializeComponent();
            
            timer1 = new Timer();
            timer1.Enabled = true;
            timer1.Tick += new EventHandler(timer1_Tick);            

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            angle += 3;
            if (angle > 359)
                angle = 0;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (backBuffer == null)
            {
                backBuffer = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            }

            // Khởi tạo đối tượng Graphics
            Graphics g = null;
            if (doBuffer)
                // Lấy đối tượng Graphics để vẽ lên back buffer
                g = Graphics.FromImage(backBuffer);
            else
                g = e.Graphics;

            g.Clear(Color.White);

            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Chuyển động các đối tượng bằng cách xoay
            Matrix mx = new Matrix();
            mx.Rotate(angle, MatrixOrder.Append);
            mx.Translate(this.ClientSize.Width / 2, this.ClientSize.Height / 2, MatrixOrder.Append);
            g.Transform = mx;
            g.FillRectangle(Brushes.Red, -100, -100, 200, 200);

            mx = new Matrix();
            mx.Rotate(-angle, MatrixOrder.Append);
            mx.Translate(this.ClientSize.Width / 2, this.ClientSize.Height / 2, MatrixOrder.Append);
            g.Transform = mx;
            g.FillRectangle(Brushes.Green, -75, -75, 149, 149);

            mx = new Matrix();
            mx.Rotate(angle * 2, MatrixOrder.Append);
            mx.Translate(this.ClientSize.Width / 2, this.ClientSize.Height / 2, MatrixOrder.Append);
            g.Transform = mx;
            g.FillRectangle(Brushes.Blue, -50, -50, 100, 100);

            // Nếu checkbox được chọn vẽ lên màn hình
            if (doBuffer)
            {
                g.Dispose();                
                e.Graphics.DrawImageUnscaled(backBuffer, 0, 0);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Không vẽ gì cả  
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (backBuffer != null)
            {
                backBuffer.Dispose();
                backBuffer = null;
            }
            base.OnSizeChanged(e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            doBuffer = checkBox1.Checked;
        }
    }
}
