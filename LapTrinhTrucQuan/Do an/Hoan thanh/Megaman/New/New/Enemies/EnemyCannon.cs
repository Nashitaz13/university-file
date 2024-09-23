using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace New
{
    class EnemyCannon
    {
        public Rectangle rectangle;
        public Texture2D texture;
        public Vector2 position = new Vector2(5560, 303);
        public int health = 50;
        public int bulletDelay = 20;
        public bool isVisible;

        public EnemyCannon(Texture2D newTexture)
        {
            texture = newTexture;
            isVisible = true;
        }

        public void Update()
        {
            if(isVisible)
                rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            else
                rectangle = new Rectangle(-200, -200, texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
