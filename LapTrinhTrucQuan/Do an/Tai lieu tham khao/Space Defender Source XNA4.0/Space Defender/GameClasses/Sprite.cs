using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Space_Defender
{
    abstract class Sprite
    {
        protected SoundBank soundBank;

        protected Texture2D textureImage;
        protected Point sheetSize;
        protected Point frameSize;
        protected Point currentFrame = new Point(0, 0);
        protected int timeSinceLastFrame = 0;
        protected int millisecondsPerFrame = 20;
        protected const int defualtMillisecondsPerFrame = 16;

        protected Vector2 position = Vector2.Zero;
        protected Vector2 speed = Vector2.Zero;
        protected float rotation = 0;
        protected Rectangle window;

        protected bool active = true;
        public float health = 1;

        protected Side side = Side.None; // Used to handle damage from explosions

        protected int scoreOnDeath = 0; // Score given to player for destroying this object

        protected float explosionRadius = 0;
        protected float explosionDamage = 0;
        protected float materialDensity = 1; // Used as an armor to reduce damage
        protected ExplosionManager explosionManager; // The object that will handle explosions for the sprite

        public Sprite(Texture2D textureImage, Point sheetSize, Vector2 position, Vector2 speed, Rectangle window, ExplosionManager explosionManager, SoundBank soundBank)
            : this(textureImage, sheetSize,  position, speed, defualtMillisecondsPerFrame, window, explosionManager, soundBank)
        {
        }

        public Sprite(Texture2D textureImage, Point sheetSize, Vector2 position, Vector2 speed, int millisecondsPerFrame, Rectangle window, ExplosionManager explosionManager, SoundBank soundBank)
        {
            this.textureImage = textureImage;
            this.sheetSize = sheetSize;
            this.frameSize = new Point(textureImage.Width / sheetSize.X, textureImage.Height / sheetSize.Y);
            this.position = position;
            this.speed = speed;
            this.millisecondsPerFrame = millisecondsPerFrame;

            this.window = window;
            this.explosionManager = explosionManager;
            this.soundBank = soundBank;
        }

        public Sprite(Texture2D textureImage, Point sheetSize, Vector2 position, Rectangle window)
            : this(textureImage, sheetSize, position, Vector2.Zero, window, null,null)
        {
        }

        public virtual void Update(GameTime gameTime)
        {
            // Get the next frame in the sprite sheet
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame = 0;

                ++currentFrame.X;
                if (currentFrame.X > sheetSize.X - 1)
                {
                    currentFrame.X = 0;
                    ++currentFrame.Y;

                    if (currentFrame.Y > sheetSize.Y - 1)
                        currentFrame.Y = 0;
                }
            }
        }

        public virtual bool IsActive
        {
            get
            {
                return (!outOfBounds(window, 30) && health > 0);
            }
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureImage, position,
                new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y),
                Color.White, rotation, new Vector2(frameSize.X / 2f, frameSize.Y / 2f), 1f, SpriteEffects.None, 0);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch, float scale)
        {
            spriteBatch.Draw(
                textureImage,
                position,
                new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y),
                Color.White, rotation, new Vector2(frameSize.X / 2f, frameSize.Y / 2f), scale, SpriteEffects.None, 0);
        }

        public virtual Rectangle collisionRect
        {
            get
            {
                return new Rectangle((int)(position.X - frameSize.X / 2), (int)(position.Y - frameSize.Y / 2), frameSize.X, frameSize.Y);
            }
        }

        public virtual Circle collisionCircle
        {
            get
            {
                return new Circle(position, frameSize.X / 2f);
            }
        }

        public virtual bool CheckCollision(Circle circle)
        {
            return collisionCircle.Intersects(circle);
        }

        public bool outOfBounds(Rectangle rect, float offset)
        {
            return (position.X < 0 - offset || position.X > rect.Width + offset
                || position.Y < 0 - offset || position.Y > rect.Height + offset);
        }

        public virtual void Kill(Side side)
        {
            soundBank.PlayCue("Explosion");
            explosionManager.CreateExplosion(position, explosionDamage, explosionRadius, side);
            health = 0;
        }

        public virtual void Kill()
        {
            this.Kill(this.side);
        }

        protected virtual void GetDamageFromExplosions(bool getFriendlyFire)
        {
            foreach (Explosion explosion in explosionManager.Explosions())
            {
                if (explosion.GetSide == this.side && !getFriendlyFire) continue;
                float radius = explosion.GetExplosionRadius;
                float distance = Vector2.Distance(explosion.GetPosition, position);
                if (distance < radius + collisionCircle.Radius)
                {
                    float distanceFactor = (radius + collisionCircle.Radius) / (distance + radius + collisionCircle.Radius);
                    health -= (explosion.GetExplosionDamage * distanceFactor) / materialDensity;
                }
            }
        }

        protected virtual void GetDamageFromExplosions()
        {
            this.GetDamageFromExplosions(false);
        }


        // Some getters
        public virtual Vector2 GetPosition
        {
            get
            {
                return position;
            }
        }

        public virtual float GetHealth
        {
            get
            {
                return health;
            }
        }

        public virtual int GetScoreOnDeath
        {
            get
            {
                return scoreOnDeath;
            }
        }

        public virtual float GetExplosionRadius
        {
            get
            {
                return explosionRadius;
            }
        }

        public virtual float GetExplosionDamage
        {
            get
            {
                return explosionDamage;
            }
        }

        public virtual float GetMaterialDensity
        {
            get
            {
                return materialDensity;
            }

        }

        public virtual float GetSpeed
        {
            get
            {
                return (float)Math.Sqrt((Math.Pow(speed.X, 2) + Math.Pow(speed.Y, 2)));
            }

        }

        public virtual Side GetSide
        {
            get
            {
                return side;
            }
        }
    }
}
