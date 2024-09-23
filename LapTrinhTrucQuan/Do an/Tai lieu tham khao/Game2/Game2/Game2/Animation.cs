using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    public class Animation
    {
        Texture2D spriteSheet;
        int frameCount;
        public int currentFrame;
        int frameTime;
        int elapsedTime;
        public Rectangle frameRectangle = new Rectangle();
        public Rectangle drawRectangle = new Rectangle();
        Color color;
        Vector2 sheetPosition;
        float scale;
        
        public bool active;
        public bool looping;
        public bool facingRight = true;
        public bool facingLeft = false;
        public int frameWidth;
        public int frameHeight;
        public Vector2 position;

        public Animation(Vector2 sheetPosition, Texture2D spriteSheet, Vector2 position, int frameWidth,
                        int frameHeight, int frameCount, int frameTime, Color color, bool looping, float scale)
        {
            this.sheetPosition = sheetPosition;
            this.spriteSheet = spriteSheet;
            this.position = position;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.frameCount = frameCount;
            this.frameTime = frameTime;
            this.color = color;
            this.looping = looping;
            this.scale = scale;

            elapsedTime = 0;
            currentFrame = 0;
            active = true;
        }

        public void updateAnimation(GameTime gameTime, Vector2 updatePosition, bool facingRightIn, bool facingLeftIn)
        {
            position = updatePosition;
            facingRight = facingRightIn;
            facingLeft = facingLeftIn;

            if (!active)
            {
                currentFrame = 0;
                return;
            }

            elapsedTime += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsedTime > frameTime)
            {
                currentFrame++;

                if (currentFrame == frameCount)
                {
                    currentFrame = 0;
                    if (!looping)
                        active = false;
                }

                elapsedTime = 0;
            }

            frameRectangle = new Rectangle((int)sheetPosition.X + currentFrame * frameWidth, 
                                            (int)sheetPosition.Y + frameHeight, frameWidth, frameHeight);
            drawRectangle = new Rectangle((int)position.X, (int)position.Y, 
                                            (int)(frameWidth * scale), (int)(frameHeight* scale));
        }

        public void draw(SpriteBatch spriteBatch)
        {
            if (active)
            {
                if (facingRight)
                    spriteBatch.Draw(spriteSheet, drawRectangle, frameRectangle, Color.White);
                else
                    spriteBatch.Draw(spriteSheet, drawRectangle, frameRectangle, Color.White, 0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
            }
        }

    }
}
