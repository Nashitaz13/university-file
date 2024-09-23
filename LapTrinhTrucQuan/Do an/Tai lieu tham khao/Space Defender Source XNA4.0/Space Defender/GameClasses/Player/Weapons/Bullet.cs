using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Space_Defender
{
    // Player's main weapon
    class Bullet : Sprite
    {
        public Bullet(Texture2D textureImage, Vector2 position, Vector2 speed, Rectangle window, ExplosionManager explosionManager, SoundBank soundBank)
            : base(textureImage, new Point(1, 1),  position, speed, window, explosionManager, soundBank)
        {
            this.explosionDamage = 20f;
            this.explosionRadius = 5f;
            this.scoreOnDeath = 0;
            this.health = 20;

            this.side = Side.Player;
        }

        public override void Update(GameTime gameTime)
        {
            position += speed;

            // In this game even bullets must be damaged by nearby explosions
            GetDamageFromExplosions(true);

            base.Update(gameTime);
        }

        public override void Kill()
        {
            soundBank.PlayCue("BulletColl");
            explosionManager.CreateExplosion(position, explosionDamage, explosionRadius, side);
            health = 0;
        }

        public override void Kill(Side side)
        {
            soundBank.PlayCue("BulletColl");
            explosionManager.CreateExplosion(position, explosionDamage, explosionRadius, side);
            health = 0;
        }
    }
}
