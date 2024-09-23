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
    // User controlled sprite!
    class Player : Sprite
    {
        protected List<Bullet> bullets = new List<Bullet>();
        protected List<Missile> missiles = new List<Missile>();

        protected int missileFireDelay = 1000; // Time between firing two missiles
        protected int missilesCount = 0; // Current fired missiles
        protected int maxNumOfMissiles = 2; // Max number of missiles the player may launch
        protected float missile1Progress = 0;
        protected float missile2Progress = 0;

        protected int initBulletFireDelay = 0; // Time between firing two bullets ( differs between space ships )
        protected int bulletFireDelay = 0;

        protected int playerScore = 0; // Score collected
        protected int midKitsUsed = 0;

        protected bool diedOnce = false; // To make it possible to see the explosion of the player's ship on death

        // Statistic variables
        protected int bulletsFired = 0;
        protected int missilesFired = 0;
        protected int missilesHits = 0;
        protected int bulletsHits = 0;

        protected int lastWheelValue = 0; // To compare with current mouse wheel value

        protected float engineTorque = 1.5f;
        protected float maxEngineTorque = 1.5f;
        protected float maxHealth = 500;

        protected ControlMethod controlMethod; // Mouse\Keyboard

        protected Texture2D bulletTex; // Texture for bullets
        protected Texture2D missileTex;// Textuer for missiles

        protected float timeTillNextFlop = 0; // To limit switching direction while using keyboard to play

        public Player(Texture2D textureImage, Point sheetSize,Texture2D bulletTex, Texture2D missileTex, Vector2 position, float health, float maxEngineTorque, int bulletFireDelay, ControlMethod controlMethod, Rectangle window, ExplosionManager explosionManager, SoundBank soundBank)
            : base(textureImage, sheetSize, position, Vector2.Zero, window, explosionManager,soundBank)
        {
            this.bulletTex = bulletTex;
            this.missileTex = missileTex;

            this.health = this.maxHealth = health;
            this.maxEngineTorque = this.engineTorque = maxEngineTorque;
            this.initBulletFireDelay = bulletFireDelay;

            this.explosionDamage = 20f;
            this.explosionRadius = 10f;
            this.materialDensity = 10f;

            this.controlMethod = controlMethod;

            this.side = Side.Player;
        }

        public Vector2 direction
        {
            get
            {
                if (health <= 0) return Vector2.Zero;
                Vector2 dir = Vector2.Zero;

                if (controlMethod == ControlMethod.Mouse)
                {
                    MouseState mouseState = Mouse.GetState();

                    // follow the mouse cursor
                    if (mouseState.X > position.X)
                        dir.X++;
                    else if (mouseState.X < position.X)
                        dir.X--;

                    if (mouseState.Y > position.Y)
                        dir.Y++;
                    else if (mouseState.Y < position.Y)
                        dir.Y--;

                    // Accelerate\Decelerate
                    if (mouseState.ScrollWheelValue > lastWheelValue)
                        engineTorque = engineTorque <= maxEngineTorque ? engineTorque + 0.07f : engineTorque;
                    else if (mouseState.ScrollWheelValue < lastWheelValue)
                        engineTorque = engineTorque >= 0f ? engineTorque - 0.07f : engineTorque;

                    if (engineTorque < 0f) engineTorque = 0f;

                    lastWheelValue = mouseState.ScrollWheelValue;

                    // Speed is related to distance from the mouse cursor
                    speed.X = Math.Abs(mouseState.X - position.X) / 150f;
                    speed.Y = Math.Abs(mouseState.Y - position.Y) / 150f;
                    speed *= new Vector2(engineTorque);

                    double m = (mouseState.Y - position.Y) / (mouseState.X - position.X);
                    rotation = (float)(Math.PI / 2f + Math.Atan(m));
                    if (mouseState.X < position.X) rotation -= (float)Math.PI;
                }
                else
                {
                    KeyboardState keyboardState = Keyboard.GetState();

                    if (keyboardState.IsKeyDown(Keys.Left)) rotation -= 0.04f;
                    if (keyboardState.IsKeyDown(Keys.Right)) rotation += 0.04f;
                    if (keyboardState.IsKeyDown(Keys.Up))
                    {
                        dir = new Vector2((float)Math.Sin(rotation), -(float)Math.Cos(rotation));
                        speed = new Vector2(3f * engineTorque);
                    }
                    if (keyboardState.IsKeyDown(Keys.Down))
                    {
                        if (timeTillNextFlop <= 0)
                        {
                            rotation += (float)Math.PI;
                            timeTillNextFlop = 500f;
                        }
                    }

                    // Accelerate\Decelerate
                    if (keyboardState.IsKeyDown(Keys.D2)) engineTorque = engineTorque <= maxEngineTorque ? engineTorque + 0.07f : engineTorque;
                    if (keyboardState.IsKeyDown(Keys.D1))
                    {
                        engineTorque = engineTorque >= 0f ? engineTorque - 0.07f : engineTorque;
                        if (engineTorque < 0f) engineTorque = 0f;
                    }
                }
                return dir * speed;
            }
        }

        protected virtual void FireBullet()
        {
            if (bulletFireDelay <= 0)
            {
                soundBank.PlayCue("BulletFire");
                
                ++bulletsFired;
                ++bulletsHits; // We assume the bullet will hit a target

                bullets.Add(new Bullet(bulletTex, position,10f* new Vector2((float)Math.Cos(rotation - Math.PI / 2f), (float)Math.Sin(rotation - Math.PI / 2f)), window, explosionManager, soundBank));
                bulletFireDelay = initBulletFireDelay;
            }
        }

        protected virtual void FireMissile()
        {
            if (missileFireDelay<=0) soundBank.PlayCue("MissileRelease");
            if (missileFireDelay <= 0 && missilesCount < maxNumOfMissiles && (missile1Progress >= 100f || missile2Progress >= 100f))
            {                
                ++missilesFired;
                ++missilesHits; // We assume the missile will hit a target

                missiles.Add(new Missile(missileTex, new Point(4, 1), position, new Vector2((float)Math.Cos(rotation - Math.PI / 2f), (float)Math.Sin(rotation - Math.PI / 2f)), rotation, window, explosionManager, soundBank));

                missileFireDelay = 1000;
                ++missilesCount;

                if (missile1Progress >= 100)
                    missile1Progress = 0f;
                else
                    missile2Progress = 0f;                
            }
        }

        public virtual int GetPlayerScore
        {
            get
            {
                return playerScore;
            }
        }
        public virtual float GetMissileProgress(int index)
        {
            if (index == 1)
                return missile1Progress;
            else
                return missile2Progress;
        }



        public override void Update(GameTime gameTime)
        {
            foreach (Bullet bullet in bullets)
                bullet.Update(gameTime);
            foreach (Missile missile in missiles)
                missile.Update(gameTime);

            // Projectles that went off the screen
            for (int i = 0; i <= bullets.Count - 1; i++)
            {
                if (!bullets[i].IsActive)
                {
                    if (bullets[i].GetHealth > 0) --bulletsHits; // bullet didn't hit a target
                    bullets.RemoveAt(i);
                    --i;
                }
            }
            for (int i = 0; i <= missiles.Count - 1; i++)
            {
                if (!missiles[i].IsActive)
                {
                    if (missiles[i].GetHealth > 0) --missilesHits; // missile didn't hit a target
                    missiles.RemoveAt(i);
                    --missilesCount;
                    --i;
                }
            }

            // Get damage from explosions near by
            GetDamageFromExplosions();

            // Attacking
            if (health > 0)
            {
                if (controlMethod == ControlMethod.Mouse)
                {
                    // Firing bullets from the rail gun using mouse left click
                    MouseState mouseState = Mouse.GetState();
                    if (mouseState.LeftButton == ButtonState.Pressed) FireBullet();
                   
                    // Firing missile using mouse right click
                    if (mouseState.RightButton == ButtonState.Pressed) FireMissile();
                }
                else
                {
                    KeyboardState keyboardState = Keyboard.GetState();

                    if (keyboardState.IsKeyDown(Keys.LeftAlt)) FireBullet();

                    if (keyboardState.IsKeyDown(Keys.LeftControl)) FireMissile();

                }
            }

            // Updating times
            missileFireDelay -= gameTime.ElapsedGameTime.Milliseconds;
            bulletFireDelay -= gameTime.ElapsedGameTime.Milliseconds;
            if (missile1Progress < 100f) missile1Progress += 0.1f;
            if (missile2Progress < 100f) missile2Progress += 0.1f;
            timeTillNextFlop -= gameTime.ElapsedGameTime.Milliseconds;

            // The player isn't allowd to leave the screen
            Vector2 prevPosition = position;
            position += direction;

            if (position.X < 0 || position.X > window.Width || position.Y < 0 || position.Y > window.Height)
                position = prevPosition;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Bullet bullet in bullets)
                bullet.Draw(gameTime, spriteBatch);

            foreach (Missile missile in missiles)
                missile.Draw(gameTime, spriteBatch);

            if (health>0) base.Draw(gameTime, spriteBatch);
        }
        public void Repair()
        {
            soundBank.PlayCue("HealthKit");
            ++midKitsUsed;
            health = maxHealth;
        }

        public void AddScore(int score)
        {
            this.playerScore += score;
        }

        public override void Kill()
        {
            if (!diedOnce) // Kill only once
            {
                soundBank.PlayCue("Explosion");
                health = 0;
                explosionManager.CreateExplosion(position, 100f, 40f,100, Side.Player);
                diedOnce = true;
            }
        }

        // Some getters
        public float GetEngineTorque
        {
            get
            {
                return engineTorque;
            }
        }

        public float GetMaxHealth
        {
            get
            {
                return maxHealth;
            }
        }

        public float GetMaxEngineTorque
        {
            get
            {
                return maxEngineTorque;
            }
        }

        public ControlMethod GetControlMethod
        {
            get
            {
                return controlMethod;
            }
        }

        public List<Bullet> Bullets()
        {
            return bullets;
        }

        public List<Missile> Missiles()
        {
            return missiles;
        }



        public int GetBulletsFired
        {
            get
            {
                return bulletsFired;
            }
        }

        public int GetBulletsHits
        {
            get
            {
                return bulletsHits;
            }
        }

        public int GetMissilesFired
        {
            get
            {
                return missilesFired;
            }
        }

        public int GetMissilesHits
        {
            get
            {
                return missilesHits;
            }
        }

        public float GetBulletsAccuracy
        {
            get
            {
                if (bulletsFired == 0) // n/a
                    return 0;
                else
                    return (bulletsHits * 100) / bulletsFired;
            }
        }

        public float GetMissilesAccuracy
        {
            get
            {
                if (missilesFired == 0) // n/a
                    return 0;
                else
                    return (missilesHits * 100) / missilesFired;
            }
        }

        public float GetTotalAccuracy
        {
            get
            {
                float totalAcc= GetBulletsAccuracy + GetMissilesAccuracy;
                if (missilesFired !=0 && bulletsFired!=0) totalAcc/=2f;
                return totalAcc;
            }
        }

        public int GetMidkitsUsed
        {
            get
            {
                return midKitsUsed;
            }
        }

        public Texture2D GetTexture
        {
            get
            {
                return textureImage;
            }
        }
    }

}
