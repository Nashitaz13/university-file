using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender
{
    class Invader : Sprite
    {
        // Some invaders chase player,while others move in a straight line
        protected bool chasePlayer = false;

        protected Player player; // player to chase

        public Invader(Texture2D textureImage, Vector2 position, Player player, bool chasePlayer, Rectangle window, ExplosionManager explosionManager,SoundBank soundBank)
            : base(textureImage, new Point(1, 1), position, Vector2.Zero, window, explosionManager, soundBank)
        {
            this.player = player;
            this.chasePlayer = chasePlayer;

            this.side = Side.Aliens;

            // The more distant from the player the more speed the invader has at creation time
            speed = new Vector2(Math.Sign(player.GetPosition.X - this.position.X) * Math.Abs(player.GetPosition.X - this.position.X) / 200f,
                           Math.Sign(player.GetPosition.Y - this.position.Y) * Math.Abs(player.GetPosition.Y - this.position.Y) / 200f);

            // Calculating the suitable rotation for the invader's direction of moving
            double m = (position.Y - player.GetPosition.Y) / (position.X - player.GetPosition.X);
            rotation = (float)(Math.Atan(m) - Math.PI / 2f);
            if (player.GetPosition.X > position.X) rotation -= (float)Math.PI;

            this.explosionDamage = 20f;
            this.explosionRadius = 25f;
            this.scoreOnDeath = 20;
            this.health = 100;
            this.materialDensity = 10f;

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
            GetDamageFromExplosions(); // Get damage from explosions nearby

            if (!chasePlayer)
            {
                position += direction;
            }
            else // chasing player
            {
                if (Vector2.Distance(position, player.GetPosition) > 10)
                {
                    if (Math.Abs(position.X - player.GetPosition.X) > 2d) position.X -= 2.5f * Math.Sign(position.X - player.GetPosition.X);
                    if (Math.Abs(position.Y - player.GetPosition.Y) > 2d) position.Y -= 2.5f * Math.Sign(position.Y - player.GetPosition.Y);

                    // Adjusting rotation
                    double m = (position.Y - player.GetPosition.Y) / (position.X - player.GetPosition.X);
                    rotation = (float)(Math.PI / 2f + Math.Atan(m));

                    if (player.GetPosition.X < position.X) rotation -= (float)Math.PI;
                }
            }
            base.Update(gameTime);
        }
    }
}
