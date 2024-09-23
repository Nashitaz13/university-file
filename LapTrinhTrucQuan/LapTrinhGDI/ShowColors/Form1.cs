using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;


namespace ShowColors
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        private void DisplayColors(PaintEventArgs e)
        {
            this.Size = new Size(650, 550);
            
            List<string> allColors = new List<string>();

            Type type = typeof(Color);
            PropertyInfo[] infos = type.GetProperties(BindingFlags.Static | BindingFlags.Public);
            foreach (PropertyInfo c in infos)
            {

                allColors.Add(c.Name);
            }        


            float y = 0;
            float x = 10.0F;

            SolidBrush bBrush = new SolidBrush(Color.Black);
            Pen p1 = new Pen(Color.Black);

            for (int i = 0; i < allColors.Count; i++)
            {

                if (i > 0 && i % 30 == 0)
                {
                    x += 105.0F;
                    y = 15.0F;
                }
                else
                {  
                    y += 15.0F;
                }
                
                SolidBrush aBrush =
                    new SolidBrush(Color.FromName(allColors[i].ToString()));
                e.Graphics.DrawRectangle(p1, x, y, 13.0F, 13.0F);
                e.Graphics.FillRectangle(aBrush, x + 1.0F, y + 1.0F, 12.0F, 12.0F);
                e.Graphics.DrawString(allColors[i].ToString(), this.Font, bBrush, x + 14.0F, y);
                aBrush.Dispose();
            }

            bBrush.Dispose();
            p1.Dispose();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DisplayColors(e);
        }
    }
}
