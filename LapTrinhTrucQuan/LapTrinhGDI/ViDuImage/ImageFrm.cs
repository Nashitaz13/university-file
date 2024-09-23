using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ViDuImage
{
    public partial class ImageFrm : Form
    {
        private string curFileName = null;
        private Image curImage = null;        
        private Rectangle curRect;
        
        public ImageFrm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnDlg = new OpenFileDialog();            
            opnDlg.Filter =
                "All Image files|*.bmp;*.gif;*.jpg;*.ico;" +
                "*.emf;,*.wmf|Bitmap Files(*.bmp;*.gif;*.jpg;" +
                "*.ico)|*.bmp;*.gif;*.jpg;*.ico|" +
                "Meta Files(*.emf;*.wmf;*.png)|*.emf;*.wmf;*.png";
            opnDlg.Title = "ImageViewer: Open Image File";
            opnDlg.ShowHelp = true;
            
            if (opnDlg.ShowDialog() == DialogResult.OK)
            {            
                curFileName = opnDlg.FileName;             
                try
                {
                    curImage = Image.FromFile(curFileName);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }                
                this.AutoScroll = true;
                this.AutoScrollMinSize = new Size((int)(curImage.Width), (int)(curImage.Height));                    this.Invalidate();
            }            
            curRect = new Rectangle(0, 0, curImage.Width, curImage.Height);                        
        }

        private void properToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curImage != null)
            {   
                string imageProperties = "Size:" + curImage.Size;
                imageProperties += ",\n RawFormat:" + curImage.RawFormat.ToString();
                imageProperties += ",\n Vertical Resolution:" + curImage.VerticalResolution.ToString();
                imageProperties += ",\n Horizontal Resolution:" + curImage.HorizontalResolution.ToString();
                imageProperties += ",\n PixelFormat:" + curImage.PixelFormat.ToString();
                MessageBox.Show(imageProperties);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (curImage == null)
                return;
            
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Title = "Save Image As";
            saveDlg.OverwritePrompt = true;
            saveDlg.CheckPathExists = true;
            saveDlg.Filter =
                "Bitmap File(*.bmp)|*.bmp|" +
                "Gif File(*.gif)|*.gif|" +
                "JPEG File(*.jpg)|*.jpg|" +
                "PNG File(*.png)|*.png";
            saveDlg.ShowHelp = true;
            
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {            
                string fileName = saveDlg.FileName;             
                string strFilExtn = fileName.Remove(0, fileName.Length - 3);                
                switch (strFilExtn)
                {
                    case "bmp":
                        curImage.Save(fileName, ImageFormat.Bmp);
                        break;
                    case "jpg":
                        curImage.Save(fileName, ImageFormat.Jpeg);
                        break;
                    case "gif":
                        curImage.Save(fileName, ImageFormat.Gif);
                        break;
                    case "tif":
                        curImage.Save(fileName, ImageFormat.Tiff);
                        break;
                    case "png":
                        curImage.Save(fileName, ImageFormat.Png);
                        break;
                    default:
                        break;
                }
            } 
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (curImage != null)
            {
                curImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
                Invalidate();
            }   
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (curImage != null)
            {
                curImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                Invalidate();
            }   
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (curImage != null)
            {
                curImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
                Invalidate();
            }
        }

        private void flipXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curImage != null)
            {
                curImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                Invalidate();
            }   
        }

        private void flipYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curImage != null)
            {
                curImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                Invalidate();
            }  	
        }

        private void flipXYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (curImage != null)
            {
                curImage.RotateFlip(RotateFlipType.Rotate270FlipXY);
                Invalidate();
            }   
        }

        private void ImageFrm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (curImage != null)
            {
                // Draw Image using the DrawImage method 
                g.DrawImage(curImage, new Rectangle
                    (this.AutoScrollPosition.X,
                    this.AutoScrollPosition.Y+20,
                    curRect.Width,
                    curRect.Height));

            }
        }

        
    }
}
