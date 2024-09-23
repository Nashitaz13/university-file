using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender
{
    // Restores player's health
    class HealthKit : Sprite
    {
        public HealthKit(Texture2D textureImage, Vector2 position, Rectangle window)
            : base(textureImage, new Point(1, 6), position, Vector2.Zero, 70, window, null,null)            
        {
            Random rnd = new Random(window.Width - 100);
            Vector2 target = new Vector2(rnd.Next(window.Width - 100) + 100);

            float m = (position.Y - target.Y) / (position.X - target.X);
            double a = Math.Atan(m) - Math.PI / 2f;

            if (target.X < position.X) a += (float)Math.PI;

            // Constant speed
            speed = new Vector2(-(float)Math.Sin(a), (float)Math.Cos(a)) * 2;

        }

        public override void Update(GameTime gameTime)
        {
            position += speed;
            base.Update(gameTime);
        }

        // MidKit cannot be destroyed
        protected override void GetDamageFromExplosions()
        {
        }
        protected override void GetDamageFromExplosions(bool getFriendlyFire)
        {
        }
    }
}
