using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    public class Level1
    {
        Texture2D texture;
        Vector2 position;
        
        List<Rectangle> boundingBoxes = new List<Rectangle>();
        public List<Rectangle> BoundingBoxes { get { return boundingBoxes; } }

        List<BoundingSlope> boundingSlopes = new List<BoundingSlope>();
        public List<BoundingSlope> BoundingSlopes { get { return boundingSlopes; } }

        public Level1(Texture2D texture)
        {
            this.texture = texture;
            position = new Vector2(0, 0);
            boundingBoxes.Add(new Rectangle(0, 1000, 1808, 500)); //Floor1
            boundingBoxes.Add(new Rectangle(2121, 1000, 1879, 500)); //Floor2
            boundingBoxes.Add(new Rectangle(0, 0, 100, 1000)); //LeftWall
            boundingBoxes.Add(new Rectangle(3900, 0, 100, 1000));//RightWall
            boundingBoxes.Add(new Rectangle(3201, 410, 397, 90)); //Platform

            boundingSlopes.Add(new BoundingSlope(new Vector2(2444, 1000), new Vector2(3129, 449), 20));
            boundingSlopes.Add(new BoundingSlope(new Vector2(3129, 449), new Vector2(3295, 1000), 10));

            for(int i = 0; i < boundingSlopes.Count; i++)
                for(int j = 0; j < boundingSlopes[i].BoundingBoxes.Count; j++)
                    boundingBoxes.Add(boundingSlopes[i].BoundingBoxes[j]);
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0);
        }

        
    }
}
