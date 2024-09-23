using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contra_Map_Editor
{
    class Node
    {
        int Mario_Height = 16, Mario_Width = 16;

        string id;
        Node LeftTop, RightTop, LeftBot, RightBot;
        Rectangle rec;
        List<Object> listObj;

        public Node(string _id,Rectangle _rec)
        {
            id = _id;
            rec = _rec;
            LeftBot = null;
            LeftTop = null;
            RightBot = null;
            RightTop = null;
            listObj = new List<Object>();
        }

        public void CreateSubNode()
        {
            if (rec.Width < Mario_Width * 2 || rec.Height < Mario_Height * 2)
                return;

            int halfWidth = rec.Width / 2;
            int halfHeight = rec.Height / 2;

            LeftTop = new Node(this.id + "0", new Rectangle(rec.Location, new Size(halfWidth, halfHeight)));
            RightTop = new Node(this.id + "1", new Rectangle(new Point(rec.Left + halfWidth, rec.Top), new Size(halfWidth, halfHeight)));
            LeftBot = new Node(this.id + "2", new Rectangle(new Point(rec.Left, rec.Top + halfHeight), new Size(halfWidth, halfHeight)));
            RightBot  = new Node(this.id + "3", new Rectangle(new Point(rec.Left + halfWidth, rec.Top + halfHeight), new Size(halfWidth, halfHeight)));
        }

        public void Insert(Object obj)
        {
            Rectangle r = new Rectangle(obj._pos_x,obj._pos_y, obj._width,obj._height);

            if (LeftBot == null)
                CreateSubNode();

            if (LeftTop != null && LeftTop.rec.Contains(r))
            {
                LeftTop.Insert(obj);
                return;
            }
            if (RightTop != null && RightTop.rec.Contains(r))
            {
                RightTop.Insert(obj);
                return;
            }
            if (LeftBot != null && LeftBot.rec.Contains(r))
            {
                LeftBot.Insert(obj);
                return;
            }
            if (RightBot != null && RightBot.rec.Contains(r))
            {
                RightBot.Insert(obj);
                return;
            }

            this.listObj.Add(obj);
        }

        public void Save(StreamWriter sw)
        {
            int subnode = 0;
            if (LeftTop != null)
                subnode = 4;
            sw.Write(rec.X.ToString() + "\t\t" + rec.Y.ToString() + "\t\t" + rec.Width.ToString() + "\t\t" + rec.Height.ToString() + "\t\t" + subnode + "\t\t" + listObj.Count + "\t\t");
            if (listObj.Count > 0)
                foreach (Object o in listObj)
                    sw.Write(o._id + "\t");
            sw.WriteLine();
            if (LeftTop != null)
            {
                LeftTop.Save(sw);
                RightTop.Save(sw);
                LeftBot.Save(sw);
                RightBot.Save(sw);
            }
        }
    }
}
