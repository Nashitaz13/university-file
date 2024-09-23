using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender
{
    class Pulse : Sprite
    {
        public Pulse(Texture2D textureImage, Vector2 position, Vector2 target, Rectangle window, ExplosionManager explosionManager)
            : base(textureImage, new Point(1, 1),position, Vector2.Zero, window, explosionManager,null)
        {
            float m = (position.Y - target.Y) / (position.X - target.X);
            double a = Math.Atan(m) - Math.PI / 2f;

            if (target.X < position.X) a += (float)Math.PI;

            // Pulse speed must be constant, it has nothing to do with how far the player is
            speed = new Vector2(-(float)Math.Sin(a), (float)Math.Cos(a)) * 8;

            this.side = Side.Aliens;
        }

        public Vector2 direction
        {
            get
            {
                return speed;
            }
        }

        public override void Update(GameTime gameTime)
        {
            position += direction;

            // The pulse is like a moving hidden explosion
            explosionManager.CreateExplosion(position, 35f, 5f, Side.Aliens, false);

            base.Update(gameTime);
        }

        protected override void GetDamageFromExplosions()
        {
            // A pulse cannot be damaged or destroyed
        }

        protected override void GetDamageFromExplosions(bool getFriendlyFire)
        {
            // A pulse cannot be damaged or destroyed
        }
    }
}
