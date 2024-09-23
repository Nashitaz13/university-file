using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrogJump
{
    class Frog
    {
        public Texture2D frogTexture;
        public Texture2D jumpTexture;
        public Vector2 position;
        public Vector2 frogOrigin;
        public Vector2 jumpOrigin;
        public Vector2 velocity;
        public float rotation;

        int randX;
        public double xJump, yJump;
        public bool jumped;
        public bool touch;

        public Frog()
        {
            jumped = false;
            touch = false;
            randX = Statics.RANDOM.Next(80, 400);
            position = new Vector2(randX * Statics.SCALE, 760 * Statics.SCALE);
        }
        public Rectangle Bound
        {
            get
            {
                return new Rectangle((int)(this.position.X - (20 * Statics.SCALE)), (int)(this.position.Y - (20 * Statics.SCALE)), (int)(40 * Statics.SCALE), (int)(40 * Statics.SCALE));
            }
            set
            {
            }
        }
        public void Load(ContentManager Content)
        {
            frogTexture = Content.Load<Texture2D>("Object/Frog");
            jumpTexture = Content.Load<Texture2D>("Object/Jump");
            Statics.PIXEL = Content.Load<Texture2D>("Other/pixel");
        }   
        public void Update(GameTime gameTime)
        {
            position += velocity;
            frogOrigin = new Vector2(frogTexture.Width / 2, frogTexture.Height / 2);
            jumpOrigin = new Vector2(jumpTexture.Width / 2, jumpTexture.Height / 2);
            xJump = Math.Sin(rotation);
            yJump = -Math.Cos(rotation);

            if (jumped)
            {
                velocity.X = (float)(9 * Statics.SCALE * xJump);
                velocity.Y = (float)(9 * Statics.SCALE * yJump);
            }
            if (!jumped)
            {
                velocity.X = 0f;
                velocity.Y = 0f;
            }
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if(jumped)
                spriteBatch.Draw(jumpTexture, position,null, Color.White, rotation, jumpOrigin, Statics.SCALE, SpriteEffects.None, 0f);
            else
                spriteBatch.Draw(frogTexture, position, null, Color.White, rotation, frogOrigin, Statics.SCALE, SpriteEffects.None, 0f);
            spriteBatch.Draw(Statics.PIXEL, Bound, new Color(0f, 0f, 0f, 0f));
        }
    }
}
