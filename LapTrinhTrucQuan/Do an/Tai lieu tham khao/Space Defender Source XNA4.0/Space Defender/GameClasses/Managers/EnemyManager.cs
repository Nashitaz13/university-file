using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Space_Defender
{
    // This class will handle enemies spawning\updating\drawing...
    class EnemyManager
    {
        protected Texture2D finalBossTex;
        protected Texture2D boltTex;
        protected Texture2D boltCannonTex;
        protected Texture2D defendersPlatformTex;
        protected Texture2D pulseCannonTex;

        protected Texture2D motherShipTex;
        protected Texture2D droneTex;
        protected Texture2D pulseTex;

        protected Texture2D invaderTex;

        protected List<Invader> invaders = new List<Invader>();
        protected List<MotherShip> motherShips = new List<MotherShip>();
        protected FinalBoss finalBoss;

        protected int timeTillNextInvasion = 0; // When reaches zero,an invader will be added to max invaders in screen
        protected int maxMotherShips = 0;
        protected int maxInvaders = 10; // Max invaders in screen
        protected int scoreTillNextBoss = 500; // Score the player must have to face the next group of mother ships
        protected int scoreTillFinalBoss = 5000; // Score the player must have to fight the final boss & finish the game
        protected int motherShipsToAdd = 0; // We add one mother ship per frame until we reach the limit of mother ships

        protected bool noMoreEnemies = false; // No more enemies = victory

        protected ExplosionManager explosionManager; // To make enemies able to get damage from explosions
        protected SoundBank soundBank;
        
        protected Player player; // Player to interact with

        protected Rectangle window; // The window to perform OutOfBounds check with

        public EnemyManager(Texture2D invaderTex, Texture2D motherShipTex, Texture2D droneTex, Texture2D pulseTex, Texture2D finalBossTex, Texture2D boltTex, Texture2D boltCannonTex, Texture2D pulseCannonTex, Texture2D defendersPlatformTex, Player player, Rectangle window, ExplosionManager explosionManager, SoundBank soundBank)
        {
            this.invaderTex = invaderTex;

            this.motherShipTex = motherShipTex;
            this.droneTex = droneTex;
            this.pulseTex = pulseTex;

            this.finalBossTex = finalBossTex;
            this.boltTex = boltTex;
            this.boltCannonTex = boltCannonTex;
            this.pulseCannonTex = pulseCannonTex;
            this.defendersPlatformTex = defendersPlatformTex;

            this.player = player;

            this.window = window;

            this.explosionManager = explosionManager;
            this.soundBank = soundBank;
        }

        // Returns a random spawning position ( used for spawning invaders & mother ships )
        protected Vector2 RandomSpwanPosition(float offset)
        {
            Vector2 position = new Vector2();
            Random xy = new Random();
            if (xy.Next(100) > 50)
            {
                Random rnd = new Random();
                int y = rnd.Next(100);
                if (y < 70)
                    position.Y = 0f - offset;
                else
                    position.Y = window.Height + offset;
                position.X = rnd.Next(window.Width);
            }
            else
            {
                Random rnd = new Random();
                int x = rnd.Next(100);
                if (x < 30)
                    position.X = 0f - offset;
                else
                    position.X = window.Width + offset;
                position.Y = rnd.Next(window.Height);
            }

            return position;
        }

        public virtual void Update(GameTime gameTime)
        {
            // Update final boss
            if (finalBoss != null)
            {
                finalBoss.Update(gameTime);
                if (finalBoss.IsActive == false)
                {
                    finalBoss.Kill();
                    player.AddScore(finalBoss.GetScoreOnDeath);
                    finalBoss = null;
                    noMoreEnemies = true; // Victory
                }
            }

            // Update invaders
            for (int i = 0; i <= invaders.Count - 1; i++)
            {
                invaders[i].Update(gameTime);
                if (invaders[i].IsActive == false)
                {
                    if (invaders[i].GetHealth <= 0)
                    {
                        player.AddScore(invaders[i].GetScoreOnDeath);
                        invaders[i].Kill(Side.None);
                    }
                    invaders.RemoveAt(i);
                    --i;
                }
            }

            // Update mother ships
            for (int i = 0; i <= motherShips.Count - 1; i++)
            {
                motherShips[i].Update(gameTime);
                if (motherShips[i].GetHealth <= 0)
                {
                    player.AddScore(motherShips[i].GetScoreOnDeath);
                    motherShips[i].Kill();
                    motherShips.RemoveAt(i);
                    --i;
                }
            }

            // Spawn an invader if the limit isn't reached yet
            if (invaders.Count < maxInvaders)
                invaders.Add(new Invader(invaderTex, RandomSpwanPosition(30), player, false, window, explosionManager,soundBank));

            // We don't want any mother ship in the presence of the final boss
            if (finalBoss == null)
            {
                if (motherShipsToAdd > 0)
                {
                    motherShips.Add(new MotherShip(motherShipTex, droneTex, pulseTex, RandomSpwanPosition(300), player, window, explosionManager, soundBank));
                    --motherShipsToAdd;
                }

                if (player.GetPlayerScore >= scoreTillNextBoss)
                {
                    ++maxMotherShips;
                    motherShipsToAdd = maxMotherShips;
                    scoreTillNextBoss *= 4;
                }
            }

            if (timeTillNextInvasion <= 0)
            {
                timeTillNextInvasion = 10000;
                if (player.GetPlayerScore < scoreTillFinalBoss)
                    maxInvaders += 1;
                else
                    maxInvaders -= 4; // Reduce invaders count
            }

            // The final boss will only appear if there's no more invaders
            if (player.GetPlayerScore >= scoreTillFinalBoss && finalBoss == null && maxInvaders <= 0 && invaders.Count == 0 && motherShips.Count == 0 && !noMoreEnemies)
            {
                finalBoss = new FinalBoss(finalBossTex, pulseCannonTex, boltCannonTex, defendersPlatformTex, invaderTex, pulseTex, boltTex, player, window, explosionManager, soundBank);
            }

            timeTillNextInvasion -= gameTime.ElapsedGameTime.Milliseconds;
        }

        public virtual void DrawSprites(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (MotherShip motherShip in motherShips)
                motherShip.Draw(gameTime, spriteBatch);

            foreach (Invader invader in invaders)
                invader.Draw(gameTime, spriteBatch);

            if (finalBoss != null) finalBoss.Draw(gameTime, spriteBatch);
        }

        public List<Invader> Invaders()
        {
            return invaders;
        }

        public List<MotherShip> MotherShips()
        {
            return motherShips;
        }

        public FinalBoss FinalBoss()
        {
            return finalBoss;
        }

        public virtual bool IsGameFinished
        {
            get
            {
                return noMoreEnemies;
            }
        }
    }
}
