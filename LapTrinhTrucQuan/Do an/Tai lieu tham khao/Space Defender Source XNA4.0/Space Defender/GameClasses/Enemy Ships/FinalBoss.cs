using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace Space_Defender
{
    class FinalBoss : Sprite
    {
        protected bool PulseCannonSoundPlayed = false;

        protected Player player; // Player to figt against

        protected int timeTillNextPulseStorm = 7000; // Firing pulses in many directions
        protected int timeTillNextLBolt = 5000; // Electricity bolt ( left )
        protected int timeTillNextRBolt = 4000; // Electricity bolt ( right )
        protected int timeTillNextDefenders = 2500; // Invaders spawned from the ship, they'll chase the player

        // Textures
        protected Texture2D pulseCannonTex; // Red lights
        protected Texture2D boltCannonTex; // White lightning ball
        protected Texture2D defendersPlatformTex; // Red light
        protected Texture2D defenderTex;
        protected Texture2D pulseTex;
        protected Texture2D boltTex;

        protected List<Pulse> pulses = new List<Pulse>();
        protected List<Invader> defenders = new List<Invader>();
        protected Bolt boltL;
        protected Bolt boltR;

        // When the final boss first spawns it cannot harm/be harmed,the situation changes when the final boss takes his final position
        protected bool fighting = false;

        public FinalBoss(Texture2D textureImage, Texture2D pulseCannonTex, Texture2D boltCannonTex, Texture2D defendersPlatformTex, Texture2D defenderTex, Texture2D pulseTex, Texture2D boltTex, Player player, Rectangle window, ExplosionManager explosionManager, SoundBank soundBank)
            : base(textureImage, new Point(1, 1),  new Vector2(window.Width / 2f, window.Height + 400), Vector2.Zero, window, explosionManager, soundBank)
        {
            this.pulseCannonTex = pulseCannonTex;
            this.boltCannonTex = boltCannonTex;
            this.defendersPlatformTex = defendersPlatformTex;
            this.defenderTex = defenderTex;
            this.pulseTex = pulseTex;
            this.boltTex = boltTex;

            this.player = player;

            this.explosionDamage = 200f;
            this.explosionRadius = 300f;
            this.scoreOnDeath = 3000;
            this.health = 14000;
            this.materialDensity = 10f;

            this.rotation = (float)Math.PI;

            boltR = new Bolt(boltTex, new Point(1, 4), position - new Vector2(230 + 105 + 10, 15), 60, false, window, explosionManager);
            boltL = new Bolt(boltTex, new Point(1, 4), position + new Vector2(230 + 105 + 10, -15), 60, true, window, explosionManager);

            this.side = Side.Aliens;

            soundBank.PlayCue("FinalBossFlyBy");
        }

        protected virtual void FirePulseStorm()
        {
            pulses.Add(new Pulse(pulseTex, position + new Vector2(0, 26), position - new Vector2(0, 100), window, explosionManager));

            pulses.Add(new Pulse(pulseTex, position + new Vector2(23, 28), position + new Vector2(37, 50), window, explosionManager));
            pulses.Add(new Pulse(pulseTex, position + new Vector2(-23, 28), position + new Vector2(-37, 50), window, explosionManager));

            pulses.Add(new Pulse(pulseTex, position + new Vector2(41, 18), position + new Vector2(62, 36), window, explosionManager));
            pulses.Add(new Pulse(pulseTex, position + new Vector2(-41, 18), position + new Vector2(-62, 36), window, explosionManager));

            pulses.Add(new Pulse(pulseTex, position + new Vector2(46, -6), position + new Vector2(71, 4), window, explosionManager));
            pulses.Add(new Pulse(pulseTex, position + new Vector2(-46, -6), position + new Vector2(-71, 4), window, explosionManager));

            pulses.Add(new Pulse(pulseTex, position + new Vector2(49, -27), position + new Vector2(75, -21), window, explosionManager));
            pulses.Add(new Pulse(pulseTex, position + new Vector2(-49, -27), position + new Vector2(-75, -21), window, explosionManager));

            pulses.Add(new Pulse(pulseTex, position + new Vector2(49, -46), position + new Vector2(76, -46), window, explosionManager));
            pulses.Add(new Pulse(pulseTex, position + new Vector2(-49, -46), position + new Vector2(-76, -46), window, explosionManager));

            soundBank.PlayCue("PulseFire");
            PulseCannonSoundPlayed = false;
        }

        protected virtual void SpawnDefenders()
        {
            defenders.Add(new Invader(defenderTex, position - new Vector2(85, -20), player, true, window, explosionManager, soundBank));
            defenders.Add(new Invader(defenderTex, position - new Vector2(-85, -20), player, true, window, explosionManager, soundBank));

            soundBank.PlayCue("DroneLaunch");
        }

        public override Rectangle collisionRect // I removed 37 pixles from the bottom of the collision rectangle
        {
            get
            {
                return new Rectangle((int)(position.X - frameSize.X / 2), (int)(position.Y - frameSize.Y / 2), frameSize.X, frameSize.Y - 37);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (!fighting)
            {
                // Move it to the top of the screen
                if (position.Y > -300)
                {
                    position.Y -= 10;
                    return;
                }
                else
                {
                    fighting = true; // Now it can harm/be harmed
                    rotation = 0;
                }

            }

            // Let the monster enter the screen
            if (position.Y < 37)
            {
                position.Y += 2;
                return;
            }

            // Update defenders
            for (int i = 0; i <= defenders.Count - 1; i++)
            {
                defenders[i].Update(gameTime);
                if (defenders[i].GetHealth <= 0)
                {
                    player.AddScore(defenders[i].GetScoreOnDeath);
                    defenders[i].Kill();
                    defenders.RemoveAt(i);
                    --i;
                }
            }

            // Update pulses
            for (int i = 0; i <= pulses.Count - 1; i++)
            {
                pulses[i].Update(gameTime);
                if (pulses[i].IsActive == false)
                {
                    pulses.RemoveAt(i);
                    --i;
                }
            }

            // Update Bolts
            boltL.Update(gameTime);
            boltR.Update(gameTime);

            // Get damage from nearby explosions
            GetDamageFromExplosions();

            /// Attack
            if (timeTillNextPulseStorm <= 0)
            {
                FirePulseStorm();
                timeTillNextPulseStorm = 5000;
            }

            if (timeTillNextRBolt <= 0)
            {
                soundBank.PlayCue("Bolt");
                boltR.Activate(position - new Vector2(230 + 105 + 10, 15));
                timeTillNextRBolt = 3000;
            }

            if (timeTillNextLBolt <= 0)
            {
                soundBank.PlayCue("Bolt");
                boltL.Activate(position + new Vector2(230 + 105 + 10, -15));
                timeTillNextLBolt = 4000;
            }

            if (timeTillNextDefenders <= 0)
            {
                SpawnDefenders();
                timeTillNextDefenders = 2500;
            }

            // Update times
            timeTillNextPulseStorm -= gameTime.ElapsedGameTime.Milliseconds;
            timeTillNextLBolt -= gameTime.ElapsedGameTime.Milliseconds;
            timeTillNextRBolt -= gameTime.ElapsedGameTime.Milliseconds;
            timeTillNextDefenders -= gameTime.ElapsedGameTime.Milliseconds;

            // Chase the player on the X axis
            if (Math.Abs(position.X - player.GetPosition.X) > 2d) position.X -= Math.Sign(position.X - player.GetPosition.X);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);

            if (timeTillNextPulseStorm <= 500 && timeTillNextPulseStorm >= 0)
            {
                if (PulseCannonSoundPlayed == false)
                {
                    soundBank.PlayCue("PulseCannon");
                    PulseCannonSoundPlayed = true;
                }

                spriteBatch.Draw(pulseCannonTex, position - new Vector2(pulseCannonTex.Width / 2f, pulseCannonTex.Height / 2f), Color.White);
            }

            if (timeTillNextLBolt <= 500 && timeTillNextLBolt >= 0)
                spriteBatch.Draw(boltCannonTex, position + new Vector2(148, -17) - new Vector2(boltCannonTex.Width / 2f, boltCannonTex.Height / 2f), Color.White);


            if (timeTillNextRBolt <= 500 && timeTillNextRBolt >= 0)
                spriteBatch.Draw(boltCannonTex, position - new Vector2(148, 17) - new Vector2(boltCannonTex.Width / 2f, boltCannonTex.Height / 2f), Color.White);

            if (timeTillNextDefenders <= 500 && timeTillNextDefenders >= 0)
            {
                spriteBatch.Draw(defendersPlatformTex, position - new Vector2(100, -19) - new Vector2(defendersPlatformTex.Width / 2f, defendersPlatformTex.Height / 2f), Color.White);
                spriteBatch.Draw(defendersPlatformTex, position + new Vector2(100, 19) - new Vector2(defendersPlatformTex.Width / 2f, defendersPlatformTex.Height / 2f), Color.White);
            }

            foreach (Pulse pulse in pulses)
                pulse.Draw(gameTime, spriteBatch);

            foreach (Invader invader in defenders)
                invader.Draw(gameTime, spriteBatch);

            boltL.Draw(gameTime, spriteBatch);
            boltR.Draw(gameTime, spriteBatch);
        }


        public List<Invader> Defenders()
        {
            return defenders;
        }

        public Bolt LBolt()
        {
            return boltL;
        }

        public Bolt RBolt()
        {
            return boltR;
        }

        // I overrided this method becuase the player can cause extra damage be attacking the final boss from the sides ;)
        protected override void GetDamageFromExplosions(bool getFriendlyFire)
        {
            foreach (Explosion explosion in explosionManager.Explosions())
            {
                if (explosion.GetSide == this.side && !getFriendlyFire) continue;
                float radius = explosion.GetExplosionRadius;
                float distance = Vector2.Distance(explosion.GetPosition, position);
                if (distance < radius + collisionCircle.Radius)
                {
                    float extraDamageFactor = 1;
                    if (explosion.GetPosition.Y < collisionRect.Bottom - 37) extraDamageFactor = 3f;
                    float distanceFactor = (radius + collisionCircle.Radius) / (distance + radius + collisionCircle.Radius);
                    health -= extraDamageFactor * ((explosion.GetExplosionDamage * distanceFactor) / materialDensity);
                }
            }
        }
        protected override void GetDamageFromExplosions()
        {
            this.GetDamageFromExplosions(false);
        }

        public bool IsFighting
        {
            get
            {
                return fighting;
            }
        }

        public override bool IsActive
        {
            get
            {
                return (health > 0);
            }
        }

        public override void Kill()
        {
            soundBank.PlayCue("FinalBossExplosion");
            base.Kill();
        }

        public override void Kill(Side side)
        {
            soundBank.PlayCue("FinalBossExplosion");
            base.Kill(side);
        }
    }
}
