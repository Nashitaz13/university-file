using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyBoardAndMouse
{
    class Program
    {
        static void Main(string[] args)
        {
            KeyBoard k = new KeyBoard();
            Application.Run(k);
        }
    }
    class KeyBoard : Form
    {
        public KeyBoard()
        {
            Text = "KeyBoardAndMouse";
            this.KeyDown += new KeyEventHandler(myKeyDown);
            this.Size = new Size(1366, 768);
        }
        void myKeyDown(object obj, KeyEventArgs kea)
        {
            Graphics g = CreateGraphics();
            g.Clear(Color.White);
            g.DrawString(kea.KeyCode.ToString() + " " + kea.KeyValue.ToString(), DefaultFont, Brushes.Black, 100, 100);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Graphics g = CreateGraphics();
            g.Clear(Color.White);
            g.DrawString("You just click " + e.Button.ToString() + " button on location: " + e.Location.ToString(), DefaultFont, Brushes.Black, e.Location.X, e.Location.Y);
        }
    }
}
