using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Game2
{
    public class BoundingSlope
    {
        Vector2 start;
        Vector2 end;
        Vector2 point3;
        Vector2 positiveSlope;
        Vector2 negativeSlope;

        public Vector2 PositiveSlope { get { return positiveSlope; } }
        public Vector2 NegativeSlope { get { return negativeSlope; } }
        
        int boxes;
        int width;
        int height;

        List<Rectangle> boundingBoxes = new List<Rectangle>();
        public List<Rectangle> BoundingBoxes { get {return boundingBoxes; } }

        Rectangle containerBox;
        public Rectangle ContainerBox { get { return containerBox; } }

        public BoundingSlope(Vector2 start, Vector2 end, int boxes)
        {
            this.start = start;
            this.end = end;
            this.boxes = boxes;
            width = (int)(end.X - start.X);
            positiveSlope = Vector2.Subtract(this.end, this.start);
            negativeSlope = Vector2.Subtract(this.start, this.end);
            positiveSlope.Normalize();
            negativeSlope.Normalize();

            if(start.Y < end.Y)
            {
                height = (int)(end.Y - start.Y);
                point3 = new Vector2(start.X, end.Y);
                for (int i = 1; i <= boxes; i++)
                {
                    boundingBoxes.Add(new Rectangle((int)start.X, (int)start.Y + (i-1)*height/boxes, 
                                        i*width/boxes, height/boxes));
                }
                containerBox = new Rectangle((int)start.X, (int)start.Y, width, height);
            }
            else
            {
                height = (int)(start.Y - end.Y);
                point3 = new Vector2(end.X, start.Y);
                for (int i = 0; i < boxes; i++)
                {
                    boundingBoxes.Add(new Rectangle((int)start.X + i*width/boxes, 
                                    (int)start.Y - i*height/boxes, 
                                    width - (i*width/boxes), height/boxes));
                }
                containerBox = new Rectangle((int)start.X, (int)end.Y, width, height);
            }
        }
    }
}
