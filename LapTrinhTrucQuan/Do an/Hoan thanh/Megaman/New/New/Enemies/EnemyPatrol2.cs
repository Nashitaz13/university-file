using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace New
{
    class EnemyPatrol2
    {
        public Texture2D texture;
        public Rectangle rectangle;
        public Vector2 position = new Vector2(2200, 315);
        Vector2 origin;
        Vector2 velocity;
        float rotation = 0f;
        public bool isVisible;
        public int health = 5;

        public EnemyPatrol2(Texture2D newTexture)
        {
            texture = newTexture;
            isVisible = true;
        }

        public void Update()
        {
            if (isVisible)
            {
                position += velocity;
                rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
                if (position.X >= 2300)
                    velocity.X = -1f;
                else
                    if (position.X <= 2200)
                        velocity.X = 1f;
            }
            else
                rectangle = new Rectangle(-200, -200, texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (velocity.X < 0)
                spriteBatch.Draw(texture, position, null, Color.White, rotation, origin, 1f, SpriteEffects.FlipHorizontally, 0f);
            else
                spriteBatch.Draw(texture, position, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0f);
        }
    }
}