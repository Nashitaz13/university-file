using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace New
{
    class Platform
    {
        public Texture2D texture;
        public Rectangle rectangle;
        public Vector2 position = new Vector2(2480,404);
        Vector2 origin;
        Vector2 velocity;
        float rotation = 0f;

        public Platform(Texture2D newTexture)
        {
            texture = newTexture;
        }

        public void Update()
        {
            position += velocity;
            rectangle = new Rectangle((int)position.X + texture.Width/4, (int)position.Y + texture.Height/4, texture.Width/2, texture.Height / 10);
            if (position.Y >= 404)
                velocity.Y = -1f;
            else
                if (position.Y <= 180)
                    velocity.Y = 1f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
        }
    }
}