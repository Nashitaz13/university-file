using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    public class Bullet
    {
        Texture2D texture;
        Vector2 position;
        Vector2 velocity;
        public int damage;
        public int Damage { get { return damage; } }
        public bool active = true;

        public Rectangle boundingBox
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            }
        }

        public int Width { get { return texture.Width;} } 
        public int Height { get { return texture.Height;} }

        public Bullet(Texture2D texture, Vector2 position, Vector2 velocity)
        {
            this.texture = texture;
            this.position = position;
            this.velocity = velocity;
            damage = 3;
        }

        public Vector2 Position { get { return position; } }
        public Vector2 Velocity { get { return velocity; } }

        public void setPosition(Vector2 position)
        {
            this.position = position;
        }

        public void setVelocity(Vector2 velocity)
        {
            this.velocity = velocity;
        }


        public void draw(SpriteBatch spriteBatch)
        {
            if(active)
                spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
