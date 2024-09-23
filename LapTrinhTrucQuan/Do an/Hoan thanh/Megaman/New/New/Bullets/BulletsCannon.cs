using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace New
{
    class BulletsCannon
    {
        public Texture2D texture;
        public Rectangle rectangle;
        public Vector2 position;
        public Vector2 velocity;
        public bool isVisible;

        public BulletsCannon(Texture2D newTexture)
        {
            texture = newTexture;
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            isVisible = true;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (rectangle.TouchLeftOf(newRectangle))
                isVisible = false;
            if (rectangle.TouchRightOf(newRectangle))
                isVisible = false;
        }
    }
}
