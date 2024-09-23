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
    public partial class TextureBrushEx : Form
    {
        private TextureBrush brush = null;

        public TextureBrushEx()
        {
            InitializeComponent();
        }

        private void TextureBrushEx_Load(object sender, EventArgs e)
        {
            Image img = new Bitmap(Brush.Properties.Resources.Img);
            brush = new TextureBrush(img);
        }

        private void TextureBrushEx_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(10, 10, 400, 300);
            g.FillRectangle(brush, rect);
        }
    }
}
