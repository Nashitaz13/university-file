using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Override
{
    abstract class Shape
    {
        protected float Area, Perimeter;
        public abstract void CalculateArea();
        public abstract void CalculatePerimeter();
    }
    class Rectangle: Shape
    {
        private float Height, Width;
        public override void CalculateArea()
        {
            Console.Write("Dien tich: {0}", Height * Width);
        }
        public override void CalculatePerimeter()
        {
            Console.Write("Chu vi: {0}", 2 * (Height + Width));
        }
        public Rectangle(float h, float w)
        {
            this.Height = h;
            this.Width = w;
        }
    }
}
