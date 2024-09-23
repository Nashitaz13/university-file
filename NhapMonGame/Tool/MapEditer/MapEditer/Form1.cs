
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditer
{
    public partial class Form1 : Form
    {
        bool active;
        Timer time;                                             //update lại form sau 10ms
        StreamWriter saveobject_filestream, savequadtree_filestream;                              //nhập xuất file
        Pen g_Pen = new Pen(Brushes.Gray);                     //bút vẽ
        Bitmap map, backBuffer, objDrawingSurface;                //kỹ thuật double buffer
        bool is_ClickLoadBG = false;                           //trạng thái của nút load
        int hScrollBar_Value = 0, vScrollBar_Value = 0;                               //giá trị của thanh cuộn
        int numOfCells_y = 0;                                   //số hàng của map
        int numOfCells_x = 0;                                   //số cột của map
        int cellSize = 16;                                      //kích thước mỗi ô trong map_matrix
        int g_itemchoice = 0;
        int level;

        int land = 0;
        bool isClickItem = false;
        Point startPoint=new Point(-1,-1), endPoint;
        Point mouse;
        Size sizechange = new Size(0, 0);
        List<Contra_Map_Editor.Object> objects = new List<Contra_Map_Editor.Object>();

        Contra_Map_Editor.Node root_node; // quad tree

        bool is_DrawGrid = false;

        Graphics g; //graphics for panel

        //Pen pen;

        public Form1()
        {
            InitializeComponent();
            time = new Timer();
            time.Interval = 100;
            time.Start();
            time.Tick += time_Tick;
            backBuffer = new Bitmap(panel1.Width, panel1.Height);
            addResources();
            //pen = new Pen(Brushes.Red, 5);
        }

        private void time_Tick(object sender, EventArgs e)
        {
            if (!active) return;
            panel1_Paint(sender, new PaintEventArgs(panel1.CreateGraphics(), new Rectangle(panel1.Location.X, panel1.Location.Y, panel1.Width, panel1.Height)));
        }

        private void panel1_Paint(object sender, PaintEventArgs paintEventArgs)
        {
            if (is_ClickLoadBG)
            {
                g = Graphics.FromImage(objDrawingSurface);
                g.Clear(Color.White);
                if (level == 0 || level == 2)
                    g.DrawImage(map, -hScrollBar_Value, -vScrollBar_Value, map.Width, map.Height);
                if (level == 1 )
                    g.DrawImage(map, 0, 240, map.Width, map.Height);
                if (level == 4)
                    g.DrawImage(map, 0, 0, map.Width, map.Height);

            }

            if (is_DrawGrid)
            {
                //ngang
                for (int y = 0; y < 27; ++y)
                {
                    g.DrawLine(g_Pen, -hScrollBar_Value, y * cellSize, 78 * cellSize, y * cellSize);
                }
                //doc
                for (int x = 0; x < 78; ++x)
                {
                    g.DrawLine(g_Pen, x * cellSize, 0, x * cellSize, 27 * cellSize);
                }

            }

            if (isClickItem && g_itemchoice!=0&&g_itemchoice!=12)
            {
                Image image = Contra_Map_Editor.Object.getImageByType(g_itemchoice);
                Rectangle rec = new Rectangle(0, 0, Contra_Map_Editor.Object.getImageByType(g_itemchoice).Width, Contra_Map_Editor.Object.getImageByType(g_itemchoice).Height);
                rec.X = mouse.X;
                rec.Y = mouse.Y;

                g.DrawImage(image, mouse.X, mouse.Y - Contra_Map_Editor.Object.getImageByType(g_itemchoice).Height);
            }
            if (land==2&&startPoint.X!=-1)
            {
                if (g_itemchoice == 0)
                    g.DrawRectangle(new Pen(Brushes.Red, 2.5f), startPoint.X - hScrollBar_Value, panel1.Height - (startPoint.Y - vScrollBar_Value) - Math.Abs(Int16.Parse(txt_Y.Text) - startPoint.Y), Math.Abs(startPoint.X - Int16.Parse(txt_X.Text)), Math.Abs(Int16.Parse(txt_Y.Text) - startPoint.Y));
                if(g_itemchoice == 12)
                    g.DrawRectangle(new Pen(Brushes.Yellow, 2.5f), startPoint.X - hScrollBar_Value, panel1.Height - (startPoint.Y - vScrollBar_Value) - Math.Abs(Int16.Parse(txt_Y.Text) - startPoint.Y), Math.Abs(startPoint.X - Int16.Parse(txt_X.Text)), Math.Abs(Int16.Parse(txt_Y.Text) - startPoint.Y));
            }
            if (objects.Count != 0)
            {
                for (int i = 0; i < objects.Count; i++)
                {
                    if (objects.ElementAt(i)._type != 0 && objects.ElementAt(i)._type != 12)
                        g.DrawImage(objects.ElementAt(i).getImageByType(), objects.ElementAt(i)._pos_x - hScrollBar_Value, panel1.Height - (objects.ElementAt(i)._pos_y - vScrollBar_Value) - objects.ElementAt(i)._height);
                    if (objects.ElementAt(i)._type == 0)
                        g.DrawRectangle(new Pen(Brushes.Red, 2.5f), objects.ElementAt(i)._pos_x - hScrollBar_Value, panel1.Height - (objects.ElementAt(i)._pos_y - vScrollBar_Value) - objects.ElementAt(i)._height, objects.ElementAt(i)._width, objects.ElementAt(i)._height);
                    if (objects.ElementAt(i)._type == 12)
                        g.DrawRectangle(new Pen(Brushes.Yellow, 2.5f), objects.ElementAt(i)._pos_x - hScrollBar_Value, panel1.Height - (objects.ElementAt(i)._pos_y - vScrollBar_Value) - objects.ElementAt(i)._height, objects.ElementAt(i)._width, objects.ElementAt(i)._height);
                      
                }
            }

            Graphics graphics = panel1.CreateGraphics();
            objDrawingSurface = backBuffer;
            graphics.DrawImageUnscaled(backBuffer, 0, 0);
        }


        private void addResources()
        {
            imageList.Images.Add(MapEditer.Resource._0);
            imageList.Images.Add(MapEditer.Resource._1);
            imageList.Images.Add(MapEditer.Resource._2);
            imageList.Images.Add(MapEditer.Resource._3);
            imageList.Images.Add(MapEditer.Resource._4);
            imageList.Images.Add(MapEditer.Resource._5);
            imageList.Images.Add(MapEditer.Resource._6);
            imageList.Images.Add(MapEditer.Resource._7);
            imageList.Images.Add(MapEditer.Resource._8);
            imageList.Images.Add(MapEditer.Resource._9);
            imageList.Images.Add(MapEditer.Resource._10);
            imageList.Images.Add(MapEditer.Resource._11);
            imageList.Images.Add(MapEditer.Resource._12);
            imageList.Images.Add(MapEditer.Resource._13);
            imageList.Images.Add(MapEditer.Resource._14);
            imageList.Images.Add(MapEditer.Resource._15);
            imageList.Images.Add(MapEditer.Resource._16);
            imageList.Images.Add(MapEditer.Resource._17);
            imageList.Images.Add(MapEditer.Resource._18);
            imageList.Images.Add(MapEditer.Resource._19);
            imageList.Images.Add(MapEditer.Resource._20);

            for (int i = 0; i < imageList.Images.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = i;
                item.Text = "Type_" + (i).ToString();
                listView.Items.Add(item);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmb_level.SelectedIndex = 0;
            level = cmb_level.SelectedIndex;
        }

        private void btn_loadBG_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                map = (Bitmap)Bitmap.FromFile(open.FileName);
                is_ClickLoadBG = true;
                numOfCells_x = map.Width / cellSize;
                numOfCells_y = map.Height / cellSize;
                objDrawingSurface = new Bitmap(numOfCells_x * cellSize, numOfCells_y * cellSize, PixelFormat.Format24bppRgb);
                if(level==0||level==2)
                {
                    hScrollBar.Maximum = numOfCells_x - 69;
                    vScrollBar.Maximum = numOfCells_y - 18;
                }
                //if (level == 1)
                //{
                //    hScrollBar.Maximum = 78;
                //    vScrollBar.Maximum = 27;
                //}
            }
        }

        private void hScrollBar_ValueChanged(object sender, EventArgs e)
        {
            hScrollBar_Value = hScrollBar.Value * cellSize;
            Invalidate();
        }

        private void vScrollBar_ValueChanged(object sender, EventArgs e)
        {
            vScrollBar_Value = vScrollBar.Value * cellSize;
            Invalidate();
        }

        private void btn_grid_Click(object sender, EventArgs e)
        {
            is_DrawGrid = !is_DrawGrid;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            mouse.X = e.X;
            mouse.Y = e.Y;
            int mX = mouse.X % 16;
            int mY = mouse.Y % 16;

            if (mX < 8)
                mouse.X = mouse.X - mX;
            if (mX > 8)
                mouse.X = mouse.X + (16 - mX);

            if (mY < 8)
                mouse.Y = mouse.Y - mY;
            if (mY > 8)
                mouse.Y = mouse.Y + (16 - mY);

            txt_X.Text = hScrollBar_Value + mouse.X + "";
            txt_Y.Text = (panel1.Height - (vScrollBar_Value + mouse.Y)) + "";
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
                return;
            g_itemchoice = listView.SelectedItems[0].ImageIndex;
            if (g_itemchoice == 0||g_itemchoice==12) 
                land = 1;
            else {
                land = 0;
                isClickItem = true;
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (isClickItem && land == 0)
                {
                    int width = 0, height = 0;

                    width = Contra_Map_Editor.Object.getImageByType(g_itemchoice).Width;
                    height = Contra_Map_Editor.Object.getImageByType(g_itemchoice).Height;

                    Contra_Map_Editor.Object obj1 = new Contra_Map_Editor.Object(g_itemchoice, Int16.Parse(txt_X.Text), Int16.Parse(txt_Y.Text), width, height);
                    objects.Add(obj1);
                }

            }

            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < objects.Count; i++)
                {
                    if (txt_X.Text.Equals(objects.ElementAt(i)._pos_x.ToString()) && txt_Y.Text.Equals(objects.ElementAt(i)._pos_y.ToString()))
                        objects.RemoveAt(i);
                }
            }

            if (e.Button != MouseButtons.Right && e.Button != MouseButtons.Left)
            {
                isClickItem = false;
                land = 0;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog saved = new SaveFileDialog();
            saved.FileName = "Stage"+(level+1)+"_";
            if (saved.ShowDialog() == DialogResult.OK)
            {
                saveobject_filestream = new StreamWriter(saved.FileName + "Objects.txt");
                saveobject_filestream.WriteLine("ID" + "\t" + "Type" + "\t" + "Pos_X" + "\t" + "Pos_Y" + "\t" + "Width" + "\t" + "Height\t");
                int temp = 0;
                foreach (Contra_Map_Editor.Object o in this.objects)
                {
                    o._id = temp;

                    saveobject_filestream.WriteLine(temp + "\t" + o._type + "\t" + o._pos_x + "\t" + o._pos_y + "\t" + o._width + "\t" + o._height+"\t");

                    temp++;
                }
                saveobject_filestream.Close();

                savequadtree_filestream = new StreamWriter(saved.FileName + "QuadTree.txt");
                savequadtree_filestream.WriteLine("Pos_X" + "\t\t" + "Pos_Y" + "\t\t" + "Width" + "\t\t" + "Height" + "\t\t" + "Node_Num" + "\t" + "Objs_Num" + "\t" + "List_Obj");

                root_node = new Contra_Map_Editor.Node("0", new Rectangle(0, 0, map.Width, map.Height));
                foreach (Contra_Map_Editor.Object o in objects)
                {
                    root_node.Insert(o);
                }
                root_node.Save(savequadtree_filestream);

                savequadtree_filestream.Close();


                MessageBox.Show("Done!!!");
            }
        }

        private void btn_loadOb_Click(object sender, EventArgs e)
        {
            String temp = "";
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader g_reader = new StreamReader(open.FileName);
                g_reader.ReadLine();
                objects.RemoveRange(0, objects.Count);
                while (!g_reader.EndOfStream)
                {
                    temp = g_reader.ReadLine();
                    if (temp != null)
                    {
                        Contra_Map_Editor.Object obj = new Contra_Map_Editor.Object(SplitString(temp, 2), SplitString(temp, 3), SplitString(temp, 4), SplitString(temp, 5), SplitString(temp, 6));
                        objects.Add(obj);
                    }
                }
                g_reader.Close();
            }
        }
        private int SplitString(String source, int numOfElement)
        {
            int kq = 0;
            String temp = "";
            int temp_count = 0;

            for (int i = 0; i < source.Length; i++)
            {
                if (source.ElementAt(i) != '\t')
                    temp += source.ElementAt(i);
                else
                {
                    kq = Int16.Parse(temp);
                    temp = "";
                    temp_count++;
                    if (temp_count == numOfElement)
                        return kq;
                }
            }
            return kq;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            active = true;
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            active = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if(land==1)
            {
                startPoint.X = Int16.Parse(txt_X.Text);
                startPoint.Y = Int16.Parse(txt_Y.Text);
                land = 2;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (land==2)
            {
                endPoint.X = Int16.Parse(txt_X.Text);
                endPoint.Y = Int16.Parse(txt_Y.Text);
                if (Math.Abs(startPoint.X - endPoint.X) == 0) return;
                if (Math.Abs(startPoint.Y - endPoint.Y) == 0) return;

                Contra_Map_Editor.Object obj1 = new Contra_Map_Editor.Object(g_itemchoice, startPoint.X, startPoint.Y, Math.Abs(startPoint.X - endPoint.X), Math.Abs(startPoint.Y - endPoint.Y));
                objects.Add(obj1);
                land = 1;
            }
        }

        private void cmb_level_SelectedIndexChanged(object sender, EventArgs e)
        {
            level=cmb_level.SelectedIndex;
        }

    }
}
