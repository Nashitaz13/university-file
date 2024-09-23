using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace DoAnThucHanh
{
    public partial class Form1 : Form
    {
        int x, y;

        int kchcnX, kchcnY;
        int kcelipX, kcelipY;
        int kcdtX1, kcdtY1, kcdtX2, kcdtY2;

        int hcnX, hcnY, hcnW, hcnH;
        int elipX, elipY, elipW, elipH;
        int dtX1, dtY1, dtX2, dtY2;

        bool hcnClick;
        bool elipClick;
        bool dtClick;
        bool chonClick;
        bool pasteClick;
        bool fillClick;
        bool borderClick;

        bool hcnDachon = false;
        bool elipDachon = false;
        bool dtDachon = false;

        bool hcnIscopy = false;
        bool elipIscopy = false;
        bool dtIscopy = false;

        bool hcnIscut = false;
        bool elipIscut = false;
        bool dtIscut = false;

        bool hcnDave = false;
        bool elipDave = false;
        bool dtDave = false;

        bool hcnMove;
        bool elipMove;
        bool dtMove;

        bool isMousedown = false;

        Rectangle hcnRectangle;
        Rectangle elipRectangle;
        Point a, b;

        Pen pen = new Pen(Color.Black);
        Pen p = new Pen(Color.Red);
        Pen clrPen = new Pen(DefaultBackColor);

        Color hcnColor ;
        Color elipColor;
        Brush hcnBrush;
        Brush elipBrush;

        Color hcnBorder;
        Color elipBorder;
        Color dtBorder;
        Pen hcnPen;
        Pen elipPen;
        Pen dtPen;
        
        private Bitmap objDrawingSurface;
        private Rectangle rectBounds1;

        public Form1()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.DoubleBuffered = true;
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (fillClick && hcnDachon)
                g.FillRectangle(hcnBrush, hcnX, hcnY, hcnW, hcnH);
            if (fillClick && elipDachon)
                g.FillEllipse(elipBrush, elipX, elipY, elipW, elipH);

            if (borderClick && hcnDachon)
                g.DrawRectangle(hcnPen, hcnX, hcnY, hcnW, hcnH);
            else
                g.DrawRectangle(pen, hcnX, hcnY, hcnW, hcnH);

            if (borderClick && elipDachon)
                g.DrawEllipse(elipPen, elipX, elipY, elipW, elipH);
            else
                g.DrawEllipse(pen, elipX, elipY, elipW, elipH);

            if (borderClick && dtDachon)
                g.DrawLine(dtPen, dtX1, dtY1, dtX2, dtY2);
            else
                g.DrawLine(pen, dtX1, dtY1, dtX2, dtY2);

            if (hcnMove && !borderClick)
            {
                g.DrawRectangle(p, hcnX, hcnY, hcnW, hcnH);
                g.DrawEllipse(pen, elipX, elipY, elipW, elipH);
                g.DrawLine(pen, dtX1, dtY1, dtX2, dtY2);
            }
            if (elipMove && !borderClick)
            {
                g.DrawEllipse(p, elipX, elipY, elipW, elipH);
                g.DrawRectangle(pen, hcnX, hcnY, hcnW, hcnH);
                g.DrawLine(pen, dtX1, dtY1, dtX2, dtY2);
            }
            if (dtMove && !borderClick)
            {
                g.DrawLine(p, dtX1, dtY1, dtX2, dtY2);
                g.DrawRectangle(pen, hcnX, hcnY, hcnW, hcnH);
                g.DrawEllipse(pen, elipX, elipY, elipW, elipH);
            }

        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            isMousedown = true;
            x = e.X;
            y = e.Y;
            if (hcnDave && chonClick)
            {
                kchcnX = e.X - hcnX;
                kchcnY = e.Y - hcnY;
                hcnRectangle = new Rectangle(hcnX, hcnY, hcnW, hcnH);
                if (e.X >= hcnX && e.X <= hcnX + hcnW && e.Y >= hcnY && e.Y <= hcnY + hcnH)
                {
                    hcnX = e.X - kchcnX;
                    hcnY = e.Y - kchcnY;
                    g.DrawRectangle(p, hcnRectangle);
                    hcnDachon = true;
                    elipDachon = false;
                    dtDachon = false;
                    hcnMove = true;
                }
                else
                    hcnMove = false;
                if (!hcnMove )
                    g.DrawRectangle(pen, hcnX, hcnY, hcnW, hcnH);
            }
            if (elipDave && chonClick)
            {
                kcelipX = e.X - elipX;
                kcelipY = e.Y - elipY;
                elipRectangle = new Rectangle(elipX, elipY, elipW, elipH);
                if (e.X >= elipX && e.X <= elipX + elipW && e.Y >= elipY && e.Y <= elipY + elipH)
                {
                    elipX = e.X - kcelipX;
                    elipY = e.Y - kcelipY;
                    g.DrawEllipse(p, elipRectangle);
                    elipDachon = true;
                    hcnDachon = false;
                    dtDachon = false;
                    elipMove = true;
                }
                else
                    elipMove = false;
                if (!elipMove)
                    g.DrawEllipse(pen, elipX, elipY, elipW, elipH);
            }
            if (dtDave && chonClick)
            {
                kcdtX1 = e.X - dtX1;
                kcdtX2 = e.X - dtX2;
                kcdtY1 = e.Y - dtY1;
                kcdtY2 = e.Y - dtY2;
                a = new Point(dtX1, dtY1);
                b = new Point(dtX2, dtY2);
                if (e.X == ((e.Y - dtY1)*(dtX2-dtX1)/(dtY2-dtY1)) + dtX1)
                {
                    dtX1 = e.X - kcdtX1;
                    dtX2 = e.X - kcdtX2;
                    dtY1 = e.Y - kcdtY1;
                    dtY2 = e.Y - kcdtY2;
                    g.DrawLine(p, a, b);
                    dtDachon = true;
                    hcnDachon = false;
                    elipDachon = false;
                    dtMove = true;
                }
                else
                    dtMove = false;
                if(!dtMove)
                    g.DrawLine(pen, dtX1, dtY1, dtX2, dtY2);
            }
            if (pasteClick)
            {
                if (hcnDave && hcnDachon && hcnIscopy && !elipIscopy && !dtIscopy)
                {
                    g.DrawRectangle(pen, e.X, e.Y, hcnW, hcnH);
                }
                if (elipDave && elipDachon && elipIscopy && !hcnIscopy && !dtIscopy)
                {
                    g.DrawEllipse(pen, e.X, e.Y, elipW, elipH);
                }
                if (dtDave && dtDachon && dtIscopy && !hcnIscopy && !elipIscopy)
                {
                    g.DrawLine(pen, e.X,e.Y , dtX2 + e.X - dtX1, dtY2 + e.Y - dtY1);
                }
                //Cut - Paste
                if (hcnDave && hcnDachon && hcnIscut && !elipIscut && !dtIscut)
                {
                    hcnDachon = false;
                    g.DrawRectangle(pen, e.X, e.Y, hcnW, hcnH);
                    hcnX = e.X;
                    hcnY = e.Y;    
                }
                if (elipDave && elipDachon && elipIscut && !hcnIscut && !dtIscut)
                {
                    elipDachon = false;
                    g.DrawEllipse(pen, e.X, e.Y, elipW, elipH);
                    elipX = e.X;
                    elipY = e.Y;
                }
                if (dtDave && dtDachon && dtIscut && !hcnIscut && !elipIscut)
                {
                    dtDachon = false;
                    g.DrawLine(pen, e.X, e.Y, dtX2 + e.X - dtX1, dtY2 + e.Y - dtY1);
                    dtX1 = e.X;
                    dtY1 = e.Y;
                    dtX2 = dtX2 + e.X - dtX1;
                    dtY2 = dtY2 + e.Y - dtY1;
                }
            }
            base.OnMouseDown(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            if (isMousedown)
            {
                if (hcnClick)
                {
                    if (e.X - x <= 0 && e.Y - y >= 0)
                    {
                        hcnW = x - e.X;
                        hcnH = e.Y - y;
                        hcnX = e.X;
                        hcnY = y;
                    }
                    if (e.X - x >= 0 && e.Y - y <= 0)
                    {
                        hcnW = e.X - x;
                        hcnH = y - e.Y;
                        hcnX = x;
                        hcnY = e.Y;
                    }
                    if (e.X - x <= 0 && e.Y - y <= 0)
                    {
                        hcnW = x - e.X;
                        hcnH = y - e.Y;
                        hcnX = e.X;
                        hcnY = e.Y;
                    }
                    if (e.X - x >= 0 && e.Y - y >= 0)
                    {
                        hcnW = e.X - x;
                        hcnH = e.Y - y;
                        hcnX = x;
                        hcnY = y;
                    }
                    hcnDave = true;
                }
                if (elipClick)
                {
                    if (e.X - x <= 0 && e.Y - y >= 0)
                    {
                        elipW = x - e.X;
                        elipH = e.Y - y;
                        elipX = e.X;
                        elipY = y;
                    }
                    if (e.X - x >= 0 && e.Y - y <= 0)
                    {
                        elipW = e.X - x;
                        elipH = y - e.Y;
                        elipX = x;
                        elipY = e.Y;
                    }
                    if (e.X - x <= 0 && e.Y - y <= 0)
                    {
                        elipW = x - e.X;
                        elipH = y - e.Y;
                        elipX = e.X;
                        elipY = e.Y;
                    }
                    if (e.X - x >= 0 && e.Y - y >= 0)
                    {
                        elipW = e.X - x;
                        elipH = e.Y - y;
                        elipX = x;
                        elipY = y;
                    }
                    elipDave = true;
                }
                if (dtClick)
                {
                    dtX1 = x;
                    dtY1 = y;
                    dtX2 = e.X;
                    dtY2 = e.Y;
                    dtDave = true;
                }
                Invalidate();
            }
            if (hcnMove)
            {
                hcnX = e.X - kchcnX;
                hcnY = e.Y - kchcnY;
                Invalidate();
            }
            if (elipMove)
            {
                elipX = e.X - kcelipX;
                elipY = e.Y - kcelipY;
                Invalidate();
            }
            if (dtMove)
            {
                dtX1 = e.X - kcdtX1;
                dtX2 = e.X - kcdtX2;
                dtY1 = e.Y - kcdtY1;
                dtY2 = e.Y - kcdtY2;
                Invalidate();
            }
            base.OnMouseMove(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            if (isMousedown)
                isMousedown = false;
            if (hcnMove)
            {
                hcnX = e.X - kchcnX;
                hcnY = e.Y - kchcnY;
                hcnMove = true;
            }
            hcnMove = false;
            if (elipMove)
            {
                elipX = e.X - kcelipX;
                elipY = e.Y - kcelipY;
                elipMove = true;
            }
            elipMove = false;
            if (dtMove)
            {
                dtX1 = e.X - kcdtX1;
                dtX2 = e.X - kcdtX2;
                dtY1 = e.Y - kcdtY1;
                dtY2 = e.Y - kcdtY2;
                dtMove = true;
            }
            dtMove = false;
            base.OnMouseUp(e);
        }
        private void HinhChuNhat_Click(object sender, EventArgs e)
        {
            hcnClick = true;
            elipClick = false;
            dtClick = false;
            chonClick = false;
            fillClick = false;
            borderClick = false;
            pasteClick = false;
        }
        private void Elip_Click(object sender, EventArgs e)
        {
            elipClick = true;
            hcnClick = false;
            dtClick = false;
            chonClick = false;
            fillClick = false;
            borderClick = false;
            pasteClick = false;
        }
        private void DuongThang_Click(object sender, EventArgs e)
        {
            dtClick = true;
            hcnClick = false;
            elipClick = false;
            chonClick = false;
            fillClick = false;
            borderClick = false;
            pasteClick = false;
        }
        private void ChonHinh_Click(object sender, EventArgs e)
        {
            chonClick = true;
            hcnClick = false;
            elipClick = false;
            dtClick = false;
            fillClick = false;
            borderClick = false;
            pasteClick = false;
        }
        private void Del_Click(object sender, EventArgs e)
        {
            hcnClick = false;
            elipClick = false;
            dtClick = false;
            fillClick = false;
            borderClick = false;
            pasteClick = false;
            Graphics g = CreateGraphics();
            if (hcnDave && hcnDachon)
            {
                g.DrawRectangle(clrPen, hcnX, hcnY, hcnW, hcnH);
                hcnDave = false;
                hcnDachon = false;
            }
            if (elipDave && elipDachon)
            {
                g.DrawEllipse(clrPen, elipX, elipY, elipW, elipH);
                elipDave = false;
                elipDachon = false;
            }
            if (dtDave && dtDachon)
            {
                g.DrawLine(clrPen, dtX1, dtY1, dtX2, dtY2);
                dtDave = false;
                dtDachon = false;
            }
        }
        private void Copy_Click(object sender, EventArgs e)
        {
            hcnClick = false;
            elipClick = false;
            dtClick = false;
            chonClick = false;
            fillClick = false;
            borderClick = false;
            pasteClick = false;
            if (hcnDave && hcnDachon)
            {
                hcnIscopy = true;
                elipIscopy = false;
                dtIscopy = false;
            }
            if (elipDave && elipDachon)
            {
                elipIscopy = true;
                hcnIscopy = false;
                dtIscopy = false;
            }
            if (dtDave && dtDachon)
            {
                dtIscopy = true;
                hcnIscopy = false;
                elipIscopy = false;
            }
        }
        private void Paste_Click(object sender, EventArgs e)
        {
            pasteClick = true;
            hcnClick = false;
            elipClick = false;
            dtClick = false;
            chonClick = false;
            fillClick = false;
            borderClick = false;
            Graphics g = CreateGraphics();
        }
        private void Cut_Click(object sender, EventArgs e)
        {
            hcnClick = false;
            elipClick = false;
            dtClick = false;
            chonClick = false;
            fillClick = false;
            borderClick = false;
            pasteClick = false;
            Graphics g = CreateGraphics();
            if (hcnDave && hcnDachon)
            {
                hcnIscut = true;
                elipIscut = false;
                dtIscut = false;
                g.DrawRectangle(clrPen, hcnX, hcnY, hcnW, hcnH);
            }
            if (elipDave && elipDachon)
            {
                elipIscut = true;
                hcnIscut = false;
                dtIscut = false;
                g.DrawEllipse(clrPen, elipX, elipY, elipW, elipH);     
            }
            if (dtDave && dtDachon)
            {
                dtIscut = true;
                hcnIscut = false;
                dtIscut = false;
                g.DrawLine(clrPen, dtX1, dtY1, dtX2, dtY2);
            }
        }
        private void Background_Click(object sender, EventArgs e)
        {
            pasteClick = false;
            ColorDialog dlg = new ColorDialog();
            dlg.Color = BackColor;
            if (dlg.ShowDialog() == DialogResult.OK)
                BackColor = dlg.Color;
        }
        private void Fill_Click(object sender, EventArgs e)
        {
            pasteClick = false;
            hcnClick = false;
            elipClick = false;
            dtClick = false;
            borderClick = false;
            Graphics g = CreateGraphics();
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fillClick = true;
                hcnColor = dlg.Color;
                hcnBrush = new SolidBrush(hcnColor);
                elipColor = dlg.Color;
                elipBrush = new SolidBrush(elipColor);
            }
            if (hcnDachon)
                g.FillRectangle(hcnBrush, hcnX, hcnY, hcnW, hcnH);
            if (elipDachon)
                g.FillEllipse(elipBrush, elipX, elipY, elipW, elipH);

        }
        private void Border_Click(object sender, EventArgs e)
        {
            hcnClick = false;
            elipClick = false;
            dtClick = false;
            fillClick = false;
            pasteClick = false;
            Graphics g = CreateGraphics();
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                borderClick = true;
                hcnBorder = dlg.Color;
                hcnPen = new Pen(hcnBorder, 1);
                elipBorder = dlg.Color;
                elipPen = new Pen(elipBorder, 1);
                dtBorder = dlg.Color;
                dtPen = new Pen(dtBorder, 1);
            }
            if (hcnDachon)
                g.DrawRectangle(hcnPen, hcnX, hcnY, hcnW, hcnH);
            if (elipDachon)
                g.DrawEllipse(elipPen, elipX, elipY, elipW, elipH);
            if (dtDachon)
                g.DrawLine(dtPen, dtX1, dtY1, dtX2, dtY2);
        }
        private void Save_Click(object sender, EventArgs e)
        {
            objDrawingSurface = new Bitmap(this.Width, this.Height,PixelFormat.Format24bppRgb);
            rectBounds1 = new Rectangle(0, 0, this.Width, this.Height);
            this.DrawToBitmap(objDrawingSurface, rectBounds1);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPG Files (*.JPG) |*.JPG";
            if ((sfd.ShowDialog() == DialogResult.OK))
                objDrawingSurface.Save(sfd.FileName, ImageFormat.Jpeg);
        }
    }
}
