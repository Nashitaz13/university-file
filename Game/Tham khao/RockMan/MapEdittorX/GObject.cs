using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEdittorX
{
    public class GObject
    {
        public Rectangle CollideRect;

        public bool IsSelected;

        public int ID;

        public Point Point;

        public Size Size;

        public int TypeID;

        public Image Image;

        public GObject(int id)
        {
            ID = id;
            this.IsSelected = false;
            this.Point = Point.Empty;
            this.Size = Size.Empty;
            this.TypeID = 0;
            this.Image = null;
            this.CollideRect = new Rectangle(0, 0, 0, 0);
        }

        /// <summary>
        /// Việc lấy bounding mặc định đối tượng tại tâm đối tượng
        /// </summary>
        private Rectangle GetBoundingRectangle()
        {
            return new Rectangle(Point.X - Size.Width / 2, Point.Y + Size.Height / 2, Size.Width, Size.Height);
        }
        public void Select()
        {
            IsSelected = IsSelected == true ? false : true;
        }
        public Rectangle GetCollideRegion()
        {
            if (CollideRect != new Rectangle(0, 0, 0, 0))
                return CollideRect;
            else
                return GetBoundingRectangle();
        }
    }
}