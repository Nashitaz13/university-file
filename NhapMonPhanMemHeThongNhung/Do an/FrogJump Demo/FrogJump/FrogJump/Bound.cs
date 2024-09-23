using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrogJump
{
    class Bound
    {
        public Vector2 position;
        public Rectangle rectangle;
        public bool isBound;

        public Bound(Texture2D newTexture, Vector2 newPosition)
        {
            isBound = true;
            Statics.PIXEL = newTexture;
            position = newPosition;
        }
        public void Update(GameTime gameTime)
        {
            if(isBound)
                rectangle = new Rectangle((int)(position.X - (27.5 * Statics.SCALE)), (int)(position.Y - (27.5 * Statics.SCALE)), (int)(55 * Statics.SCALE), (int)(55 * Statics.SCALE));
            else
                if(!isBound)
                    rectangle = new Rectangle((int)(-50 * Statics.SCALE), 0, 0, 0);
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Statics.PIXEL, rectangle, new Color(0f, 0f, 0f, 0f));
        }
    }
}
