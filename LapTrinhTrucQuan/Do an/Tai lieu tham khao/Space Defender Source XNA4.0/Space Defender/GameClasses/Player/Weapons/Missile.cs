using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Space_Defender
{
    // Secondary weapon, needs much longer time to reload
    class Missile : Sprite
    {
        // The missile will first be released, after a while it will be ignited and it will gain speed
        protected int millisecondsTillIgnition = 1000;
        protected bool ignited = false;
        protected int timeSinceLaunched = 0;

        public Missile(Texture2D textureImage, Point sheetSize,Vector2 position, Vector2 speed, float rotation, Rectangle window, ExplosionManager explosionManager, SoundBank soundBank)
            : base(textureImage, sheetSize,  position, speed, window, explosionManager, soundBank)
        {
            this.rotation = rotation;

            this.explosionDamage = 150f;
            this.explosionRadius = 300f;

            this.currentFrame = new Point(sheetSize.X - 1, 0);

            this.side = Side.Player;
        }

        public override void Update(GameTime gameTime)
        {
            // Can be damaged by other explosions
            GetDamageFromExplosions();

            // The kill method will create an explosion
            if (health <= 0) this.Kill();

            // Ignition issues
            if (!ignited)
            {
                if (timeSinceLaunched < millisecondsTillIgnition)
                    timeSinceLaunched += gameTime.ElapsedGameTime.Milliseconds;

                if (timeSinceLaunched >= millisecondsTillIgnition)
                {
                    ignited = true;
                    millisecondsPerFrame /= 2;
                    speed *= new Vector2(6, 6); // Gain speed

                    sheetSize = new Point(3, 1);

                    soundBank.PlayCue("MissileIgnition");
                }
            }

            // Update base
            base.Update(gameTime);

            // If not ignited yet the ignore base update and set currentFrame to the un ignited missile frame
            if (!ignited) currentFrame = new Point(sheetSize.X-1, 0);

            // Move the missile
            position += direction;
        }


        public Vector2 direction
        {
            get
            {
                return speed;
            }
        }

    }
}
