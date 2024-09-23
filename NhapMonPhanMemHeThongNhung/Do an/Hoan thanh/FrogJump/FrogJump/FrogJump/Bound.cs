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

        public Bound(Vector2 newPosition)
        {
            isBound = true;
            position = newPosition;
        }
        public void Update(GameTime gameTime)
        {
            if(isBound)
                rectangle = new Rectangle((int)(position.X - 27.5), (int)(position.Y - 27.5), 55, 55);
            else
                if(!isBound)
                    rectangle = new Rectangle(-50, 0, 0, 0);
        }
    }
}
