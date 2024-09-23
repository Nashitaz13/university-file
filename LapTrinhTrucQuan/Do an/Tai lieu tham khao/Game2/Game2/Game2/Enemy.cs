using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    public class Enemy
    {
        Texture2D texture;
        Vector2 startingPoint;
        Vector2 position;
        Vector2 velocity;
        public int health;
        bool active;

        Rectangle boundingBox;
        public Rectangle BoundingBox { get { return boundingBox; } }

        public Enemy(Texture2D texture, Vector2 position, Vector2 velocity, int health, bool active)
        {
            this.texture = texture;
            startingPoint = position;
            this.position = position;
            this.velocity = velocity;
            this.health = health;
            this.active = active;

            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public void update()
        {
            if (active)
            {
                position += velocity;
                if (Math.Abs(position.X - startingPoint.X) > 200)
                    velocity.X = -velocity.X;
                if (Math.Abs(position.Y - startingPoint.Y) > 160)
                    velocity.Y = -velocity.Y;
            }

            if (health <= 0)
                active = false;

            if (!active)
            {
                boundingBox = new Rectangle(-100, -100, 1, 1);
                position = new Vector2(-100, -100);
            }
        }

        public void draw(SpriteBatch spriteBatch)
        {
            if(active)
                spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
