using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender
{
    class Bolt : Sprite
    {
        protected bool leftToRight = false; // Final boss can fire bolts left and right

        protected float energyToLose = 0; // The bolt will lose health gradually until it becomes uneffective

        public Bolt(Texture2D textureImage, Point sheetSize, Vector2 position, int millisecondsPerFrame, bool leftToRight, Rectangle window, ExplosionManager explosionManager)
            : base(textureImage, sheetSize,  position, Vector2.Zero, millisecondsPerFrame, window, explosionManager,null)
        {
            this.health = 100f;
            this.leftToRight = leftToRight;
            this.energyToLose = health / (sheetSize.Y * sheetSize.X);
        }

        public override void Update(GameTime gameTime)
        {
            health -= energyToLose;
            if (IsActive) base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (leftToRight) spriteEffects = SpriteEffects.FlipHorizontally;

            if (IsActive)
            {
                spriteBatch.Draw(
                textureImage,
                position,
                new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y),
                Color.White, rotation, new Vector2(frameSize.X / 2f, frameSize.Y / 2f), 1f, spriteEffects, 0);
            }
        }

        public virtual void Activate(Vector2 position)
        {
            this.position = position; // We need to change position to match final boss movements
            active = true;
            health = 100;
            currentFrame = new Point(0, 0);
        }
    }
}
