using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrogJump
{
    class Leaf
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 origin;
        public float rotation;

        public Leaf(Texture2D newTexture, Vector2 newPosition)
        {
            texture = newTexture;
            position = newPosition;
            origin = new Vector2(texture.Width / 2 , texture.Height / 2);
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, rotation, origin, Statics.SCALE, SpriteEffects.None, 0f);
        }
    }
}
