using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Space_Defender
{
    class MotherShip : Sprite
    {
        // Mother ships do three things
        //1.Chasing the player
        //2.Spawning drones ( chasing invaders )
        //3.Firing pulses
        protected int timeTillNextDrone = 0;
        protected int timeTillNextPulse = 7000;

        protected List<Invader> drones = new List<Invader>();
        protected List<Pulse> pulses = new List<Pulse>();

        protected Player player;
        protected Texture2D droneTex;
        protected Texture2D pulseTex;

        public MotherShip(Texture2D textureImage, Texture2D droneTex, Texture2D pulseTex, Vector2 position, Player player, Rectangle window, ExplosionManager explosionManager, SoundBank soundBank)
            : base(textureImage, new Point(1, 1), position, Vector2.Zero, window, explosionManager, soundBank)
        {
            this.droneTex = droneTex;
            this.pulseTex = pulseTex;

            this.side = Side.Aliens;

            this.player = player;

            speed = new Vector2(Math.Sign(player.GetPosition.X - this.position.X) * Math.Abs(player.GetPosition.X - this.position.X) / 200f,
                            Math.Sign(player.GetPosition.Y - this.position.Y) * Math.Abs(player.GetPosition.Y - this.position.Y) / 200f);

            // Calculating rotation
            double m = (position.Y - player.GetPosition.Y) / (position.X - player.GetPosition.X);
            rotation = (float)(Math.Atan(m) - Math.PI / 2f);
            if (player.GetPosition.X > position.X) rotation -= (float)Math.PI;

            this.explosionDamage = 200f;
            this.explosionRadius = 40f;
            this.scoreOnDeath = 400;
            this.health = 200;
            this.materialDensity = 40f;
        }

        public List<Invader> Drones()
        {
            return drones;
        }
        public List<Pulse> Pulses()
        {
            return pulses;
        }
        protected void SpawnDrone()
        {
            soundBank.PlayCue("DroneLaunch");
            drones.Add(new Invader(droneTex, position, player, true, window, explosionManager, soundBank));
        }

        protected void FirePulse()
        {
            pulses.Add(new Pulse(pulseTex, position, player.GetPosition, window, explosionManager));
            soundBank.PlayCue("PulseFire");
        }

        public override void Update(GameTime gameTime)
        {
            // Update pulses
            for (int i = 0; i <= pulses.Count - 1; i++)
            {
                pulses[i].Update(gameTime);
                if (!pulses[i].IsActive)
                {
                    pulses.RemoveAt(i);
                    --i;
                }
            }

            // Update drones
            for (int i = 0; i <= drones.Count - 1; i++)
            {
                drones[i].Update(gameTime);
                if (drones[i].GetHealth <= 0)
                {
                    player.AddScore(drones[i].GetScoreOnDeath);
                    explosionManager.CreateExplosion(drones[i].GetPosition, drones[i].GetExplosionDamage, drones[i].GetExplosionRadius, Side.None);
                    drones.RemoveAt(i);
                    --i;
                }
            }

            // Get damage from explosions nearby
            GetDamageFromExplosions();

            // Chase player
            if (Vector2.Distance(position, player.GetPosition) > 30)
            {
                position.X -= Math.Sign(position.X - player.GetPosition.X);
                position.Y -= Math.Sign(position.Y - player.GetPosition.Y);

                double m = (position.Y - player.GetPosition.Y) / (position.X - player.GetPosition.X);
                rotation = (float)(Math.Atan(m) - Math.PI / 2f);
                if (player.GetPosition.X > position.X) rotation -= (float)Math.PI;
            }

            // Update timing
            timeTillNextDrone -= gameTime.ElapsedGameTime.Milliseconds;
            timeTillNextPulse -= gameTime.ElapsedGameTime.Milliseconds;

            /// Attack
            if (timeTillNextDrone <= 0)
            {
                timeTillNextDrone = 4000;
                SpawnDrone();
            }

            if (timeTillNextPulse <= 0)
            {
                timeTillNextPulse = 7000;
                FirePulse();
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Pulse pulse in pulses)
                pulse.Draw(gameTime, spriteBatch);

            base.Draw(gameTime, spriteBatch);

            foreach (Invader drone in drones)
                drone.Draw(gameTime, spriteBatch);
        }

        // Active even if out of bounds
        public override bool IsActive
        {
            get
            {
                return (health > 0);
            }
        }


    }
}
