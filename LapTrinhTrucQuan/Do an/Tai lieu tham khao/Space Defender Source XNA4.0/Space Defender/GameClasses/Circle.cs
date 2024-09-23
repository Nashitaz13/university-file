using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Space_Defender
{
    // A Circle!!!!
    class  Circle 
    {
        protected Vector2 center;
        protected float radius;

        public Circle(Vector2 center, float radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public virtual bool Intersects(Circle circle)
        {
            return (Vector2.Distance(center, circle.Center) <= (radius + circle.Radius));
        }

        public float X
        {
            get
            {
                return center.X;
            }
        }

        public float Y
        {
            get
            {
                return center.Y;
            }
        }

        public Vector2 Center
        {
            get
            {
                return center;
            }
        }

        public float Radius
        {
            get
            {
                return radius;
            }
        }
    }
}
