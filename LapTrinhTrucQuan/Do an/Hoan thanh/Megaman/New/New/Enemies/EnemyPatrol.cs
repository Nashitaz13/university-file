using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace New
{
    class EnemyPatrol
    {
        public Texture2D texture;
        public Rectangle rectangle;
        public Vector2 position = new Vector2(720, 330);
        Vector2 origin;
        Vector2 velocity;
        float rotation = 0f;
        public bool isVisible;
        public int health = 3;

        public EnemyPatrol(Texture2D newTexture)
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
                if (position.X >= 820)
                    velocity.X = -1f;
                else
                    if (position.X <= 720)
                        velocity.X = 1f;
            }
            else
                rectangle = new Rectangle(-200, -200, texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (velocity.X > 0)
                spriteBatch.Draw(texture, position, null, Color.White, rotation, origin, 1.5f, SpriteEffects.FlipHorizontally, 0f);
            else
                spriteBatch.Draw(texture, position, null, Color.White, rotation, origin, 1.5f, SpriteEffects.None, 0f);
        }
    }
}
