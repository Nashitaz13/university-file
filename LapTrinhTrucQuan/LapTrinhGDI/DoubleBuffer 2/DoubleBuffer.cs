using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DoubleBuffer_2
{
    public partial class Form1 : Form
    {
        private BufferedGraphicsContext currentContext;
        private BufferedGraphics myBuffer;        
        private Timer timer;
        private float angle;
        private bool doBuffer;

        public Form1()
        {
            InitializeComponent();
                       
            currentContext = BufferedGraphicsManager.Current;            
            myBuffer = currentContext.Allocate(this.CreateGraphics(),
               this.DisplayRectangle);

            timer = new Timer();
            timer.Enabled = true;
            timer.Tick += new EventHandler(timer_Tick);
        }

        private void timer_Tick(object sender, System.EventArgs e)
        {
            angle += 3;
            if (angle > 359)
                angle = 0;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Khởi tạo đối tượng Graphics
            Graphics g = null;
            if (doBuffer)
                // Lấy đối tượng Graphics để vẽ lên back buffer
                g = myBuffer.Graphics;
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
                //myBuffer.Render()
                myBuffer.Render(this.CreateGraphics());
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Không vẽ gì cả  
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (myBuffer != null)
            {
                myBuffer.Dispose();
                myBuffer = currentContext.Allocate(this.CreateGraphics(),
                        this.DisplayRectangle);
            }
            this.Refresh();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            doBuffer = checkBox1.Checked;
        }
    }
}
