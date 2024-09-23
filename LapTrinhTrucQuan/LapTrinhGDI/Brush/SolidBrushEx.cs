using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Brush
{
    public partial class SolidBrushEx : Form
    {
        public SolidBrushEx()
        {
            InitializeComponent();
        }

        private void SolidBrush_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;            
            SolidBrush redBrush = new SolidBrush(Color.Red);            
            SolidBrush blueBrush = new SolidBrush(Color.Blue);            
            g.FillEllipse(redBrush, 20, 40, 100, 110);
            Rectangle rect = new Rectangle(150, 100, 200, 180);
            g.FillRectangle(blueBrush, rect);                        
        }
    }
}
