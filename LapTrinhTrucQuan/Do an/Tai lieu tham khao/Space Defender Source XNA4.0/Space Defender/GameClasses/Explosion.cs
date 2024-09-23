using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Space_Defender
{
    class Explosion : Sprite
    {
        bool visible = true;

        public Explosion(Texture2D textureImage, Point sheetSize, Vector2 position, float explosionDamage, float explosionRadius, int millisecondsPerFrame, Side side)
            : base(textureImage, sheetSize,  position, Vector2.Zero, millisecondsPerFrame, Rectangle.Empty, null, null)
        {
            this.explosionDamage = explosionDamage;
            this.explosionRadius = explosionRadius;
            this.side = side;
        }

        public Explosion(Texture2D textureImage, Point sheetSize, Vector2 position, float explosionDamage, float explosionRadius, Side side)
            : this(textureImage, sheetSize,  position, explosionDamage, explosionRadius, 20, side)
        {
        }

        public Explosion(Texture2D textureImage, Point sheetSize,Vector2 position, float explosionDamage, float explosionRadius, Side side, bool visible)
            : this(textureImage, sheetSize,  position, explosionDamage, explosionRadius, 20, side)
        {
            this.visible = visible;
        }

        public override void Update(GameTime gameTime)
        {
            // The explosion will remain active until currentFrame reaches the last fram in the sprite sheet
            if (currentFrame == new Point(sheetSize.X - 1, sheetSize.Y - 1))
            {
                active = false;
                return;
            }
            if (active) base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (active && visible) base.Draw(gameTime, spriteBatch);
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch, float scale)
        {
            if (active && visible) base.Draw(gameTime, spriteBatch, scale);
        }

        public override bool IsActive
        {
            get
            {
                return active;
            }
        }
    }
}
