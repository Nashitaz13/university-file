using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEdittorX
{
    /// <summary>
    /// Cấu trúc cây tứ phân dùng trong việc xét va chạm
    /// </summary>
    class QuadNode
    {
        public int ID;              // ID của mỗi mode
        public List<GObject> Objects;   // Danh sách các đối tượng trong mỗi node
        public Point Position;      // Tọa độ góc trên trái mỗi node
        public Size Size;           // Kích thước của mỗi node

        public QuadNode LT;         // Node con trên trái
        public QuadNode RT;         // Node con trên phải
        public QuadNode LB;         // Node con dưới trái
        public QuadNode RB;         // Node con dưới phải

        public QuadNode(int id, Point position, Size size)
        {
            ID = id;
            Position = position;
            Size = size;

            Objects = new List<GObject>();
            LT = null;
            RT = null;
            LB = null;
            RB = null;
        }

        /// <summary>
        /// Kiểm tra 1 obj có thể nằm trong node hay không
        /// </summary>
        public bool IsContain(GObject obj)
        {
            Rectangle rect = obj.GetCollideRegion();

            return !(rect.X + rect.Width < Position.X
                || rect.X > Position.X + Size.Width
                || rect.Y - rect.Height > Position.Y
                || rect.Y < Position.Y - Size.Height);
        }
        /// <summary>
        /// Kiểm tra 1 điêm có thể nằm trong node hay không
        /// </summary>
        public List<GObject> GetObjectsWith(Point point)
        {
            List<GObject> objs = new List<GObject>();
            if (LT == null && RT == null && LB == null && RB == null)
            {
                foreach (var obj in Objects)
                    if (point.X >= obj.Point.X - obj.Size.Width / 2
                        && point.X <= obj.Point.X + obj.Size.Width / 2
                        && point.Y <= obj.Point.Y + obj.Size.Height / 2
                        && point.Y >= obj.Point.Y - obj.Size.Height / 2)
                        objs.Add(obj);
                return objs;
            }
            
            objs.AddRange(LT.GetObjectsWith(point));
            objs.AddRange(RT.GetObjectsWith(point));
            objs.AddRange(LB.GetObjectsWith(point));
            objs.AddRange(RB.GetObjectsWith(point));
            return objs;
        }

        /// <summary>
        /// Lấy ra khung chữ nhật bao node
        /// </summary>
        public Rectangle GetBoundingRectangle()
        {
            return new Rectangle(Position, Size);
        }

        /// <summary>
        /// Lấy ra số lượng node con
        /// </summary>
        public int CountChildNode()
        {
            if (LT == null)
                return 1;
            else
                return 1 + LT.CountChildNode() + RT.CountChildNode() + LB.CountChildNode() + RB.CountChildNode();
        }

        /// <summary>
        /// Thêm vào một đối tượng
        /// </summary>
        public void Insert(GObject obj)
        {
            Rectangle objRect = obj.GetCollideRegion();
            Objects.Add(obj);
            if (LT == null)
                Split();

            // Kiểm tra nếu như phần tử này nằm trong node LT thì add nó vào và xóa nó khởi danh sách của node cha
            if (LT != null && LT.IsContain(obj))
            {
                LT.Insert(obj);
                if (Objects.Contains(obj))
                    Objects.Remove(obj);
            }

            // Kiểm tra nếu như phần tử này nằm trong node RT thì add nó vào và xóa nó khởi danh sách của node cha
            if (RT != null && RT.IsContain(obj))
            {
                RT.Insert(obj);
                if (Objects.Contains(obj))
                    Objects.Remove(obj);
            }

            // Kiểm tra nếu như phần tử này nằm trong node LB thì add nó vào và xóa nó khởi danh sách của node cha
            if (LB != null && LB.IsContain(obj))
            {
                LB.Insert(obj);
                if (Objects.Contains(obj))
                    Objects.Remove(obj);
            }

            // Kiểm tra nếu như phần tử này nằm trong node RB thì add nó vào và xóa nó khởi danh sách của node cha
            if (RB != null && RB.IsContain(obj))
            {
                RB.Insert(obj);
                if (Objects.Contains(obj))
                    Objects.Remove(obj);
            }
        }

        /// <summary>
        /// Chia node cha thành 4 node con
        /// </summary>
        public void Split()
        {
            if (Size.Width < Global.NODE_SIZE && Size.Height < Global.NODE_SIZE)
                return;
            int hafWidth = Size.Width / 2;
            int hafHeight = Size.Height / 2;
            Size size = new Size(hafWidth, hafHeight);

            LT = new QuadNode(ID * 4 + 1, new Point(Position.X, Position.Y), size);
            RT = new QuadNode(ID * 4 + 2, new Point(Position.X + hafWidth, Position.Y), new Size(size.Width + (Size.Width - hafWidth * 2), size.Height));
            LB = new QuadNode(ID * 4 + 3, new Point(Position.X, Position.Y - hafHeight), new Size(size.Width, size.Height + (Size.Height - hafHeight * 2)));
            RB = new QuadNode(ID * 4 + 4, new Point(Position.X + hafWidth, Position.Y - hafHeight), new Size(size.Width + (Size.Width - hafWidth * 2), size.Height + (Size.Height - hafHeight * 2)));
        }

        public void Paint(int asisY, Graphics g, Pen p, bool isShowIDNumber = true)
        {
            g.DrawRectangle(p, new Rectangle(new Point(Position.X, asisY - Position.Y), Size));
            Font font = new Font("Arial", 10);
            SolidBrush drawBrush = new SolidBrush(Color.Red);
            PointF drawPoint = new PointF(Position.X + Size.Width / 2 - g.MeasureString(ID.ToString(), font).Width / 2, asisY - (Position.Y - Size.Height / 2 + g.MeasureString(ID.ToString(), font).Height / 2));
            g.DrawString(ID.ToString(), font, drawBrush, drawPoint);

            font = new Font("Arial", 8, FontStyle.Bold);
            Brush stringBrush = new SolidBrush(Color.Black);
            Brush collideRectBrush = new SolidBrush(Color.FromArgb(64, 255, 0, 0));
            SolidBrush borderBrush = new SolidBrush(Color.White);

            foreach (var o in Objects)
            {
                if (o.IsSelected)
                {
                    g.FillRectangle(drawBrush, new Rectangle(new Point(o.Point.X - o.Size.Width / 2, asisY - (o.Point.Y + o.Size.Height / 2)), o.Size));
                    if (o.CollideRect != new Rectangle(0, 0, 0, 0))
                        g.FillRectangle(collideRectBrush, new Rectangle(o.CollideRect.X, asisY - o.CollideRect.Y, o.CollideRect.Width, o.CollideRect.Height));
                }
                if (isShowIDNumber)
                {
                    drawPoint = new PointF(o.Point.X - g.MeasureString(o.ID.ToString(), font).Width / 2, asisY - (o.Point.Y + g.MeasureString(o.ID.ToString(), font).Height / 2));
                    Size s = g.MeasureString(o.ID.ToString(), font).ToSize();
                    g.FillRectangle(borderBrush, new Rectangle(new Point((int)drawPoint.X + 1, (int)drawPoint.Y + 1), s - new Size(2, 1)));
                    g.DrawString(o.ID.ToString(), font, stringBrush, drawPoint);
                }
            }
            if (LT != null)
            {
                LT.Paint(asisY, g, p, isShowIDNumber);
                RT.Paint(asisY, g, p, isShowIDNumber);
                LB.Paint(asisY, g, p, isShowIDNumber);
                RB.Paint(asisY, g, p, isShowIDNumber);
            }
        }


        /// <summary>
        /// Lưu quadtree xuống file .txt
        /// </summary>
        public void Save(StreamWriter sw)
        {
            sw.Write(ID + "\t" + Position.X.ToString() + "\t" + Position.Y.ToString() + "\t" + Size.Width.ToString() + "\t" + Size.Height.ToString() + "\t" + Objects.Count);
            if (Objects.Count > 0)
                foreach (var item in Objects)
                    sw.Write("\t" + item.ID);
            sw.WriteLine();

            if (LT != null)
            {
                LT.Save(sw);
                RT.Save(sw);
                LB.Save(sw);
                RB.Save(sw);
            }
        }
    }
}