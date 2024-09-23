using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace New
{
    class Player
    {
        AnimationPlayer animationPlayer;
        Animation idleAnimation;
        Animation runAnimation;
        Animation jumpAnimation;
        Animation dashAnimation;
        Animation shootAnimation;
        Animation runshootAnimation;
        Animation jumpshootAnimation;
        Animation injuredAnimation;

        public bool beInjured = false;
        public int health = 147;
        public int life = 3;

        public Texture2D idleTexture;
        public Texture2D runTexture;
        public Texture2D jumpTexture;
        public Texture2D dashTexture;
        public Texture2D shootTexture;
        public Texture2D runshootTexture;
        public Texture2D jumpshootTexture;
        public Texture2D injuredTexture;

        public Vector2 position = new Vector2(100, 100);
        public Vector2 velocity;
        public Rectangle rectangle;

        KeyboardState cur;
        public SpriteEffects spriteEffects;

        private bool hasJumped = false;

        public Vector2 Position
        {
            get { return position; }
        }
        public Player()
        {}
        public void Load(ContentManager Content)
        {
            idleTexture = Content.Load<Texture2D>("Player/Idle");
            idleAnimation = new Animation(idleTexture, 31, 5f, true);
            runTexture = Content.Load<Texture2D>("Player/Run");
            runAnimation = new Animation(runTexture, 36, 2f, true);
            jumpTexture = Content.Load<Texture2D>("Player/Jump");
            jumpAnimation = new Animation(jumpTexture, 39, 1f, true);
            dashTexture = Content.Load<Texture2D>("Player/Dash");
            dashAnimation = new Animation(dashTexture, 40, 1f, true);
            shootTexture = Content.Load<Texture2D>("Player/Shoot");
            shootAnimation = new Animation(shootTexture, 46, 1f, true);
            runshootTexture = Content.Load<Texture2D>("Player/RunShoot");
            runshootAnimation = new Animation(runshootTexture, 45, 1f, true);
            jumpshootTexture = Content.Load<Texture2D>("Player/JumpShoot");
            jumpshootAnimation = new Animation(jumpshootTexture, 43, 1f, true);
            injuredTexture = Content.Load<Texture2D>("Player/Injured");
            injuredAnimation = new Animation(injuredTexture, 39, 10f, true);
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
            rectangle = new Rectangle((int)position.X - 10, (int)position.Y - 35, idleTexture.Width/2, idleTexture.Height);

            Input(gameTime);
        }
        private void Input(GameTime gameTime)
        {
            cur = Keyboard.GetState();

            if (cur.IsKeyDown(Keys.Right))
                spriteEffects = SpriteEffects.None;
            else if (cur.IsKeyDown(Keys.Left))
                spriteEffects = SpriteEffects.FlipHorizontally;

            if (cur.IsKeyDown(Keys.Right))
                velocity.X = 3f;
            else
                if (cur.IsKeyDown(Keys.Left))
                    velocity.X = -3f;
                else
                    velocity.X = 0f;

            if (beInjured)
            {
                animationPlayer.PlayAnimation(injuredAnimation);
                beInjured = false;
                rectangle = new Rectangle((int)position.X - 10, (int)position.Y - 35, injuredTexture.Width, injuredTexture.Height);
            }
            else
                if (cur.IsKeyDown(Keys.X) && cur.IsKeyDown(Keys.C))
                {
                    animationPlayer.PlayAnimation(jumpshootAnimation);
                    rectangle = new Rectangle((int)position.X - 10, (int)position.Y - 35, jumpshootTexture.Width, jumpshootTexture.Height);
                }
                else
                    if (cur.IsKeyDown(Keys.Right) && cur.IsKeyDown(Keys.C) ||
                        cur.IsKeyDown(Keys.Left) && cur.IsKeyDown(Keys.C))
                    {
                        animationPlayer.PlayAnimation(runshootAnimation);
                        rectangle = new Rectangle((int)position.X - 10, (int)position.Y - 35, runshootTexture.Width/3, runshootTexture.Height);
                    }
                    else
                        if (cur.IsKeyDown(Keys.C))
                        {
                            animationPlayer.PlayAnimation(shootAnimation);
                            rectangle = new Rectangle((int)position.X - 10, (int)position.Y - 35, shootTexture.Width, shootTexture.Height);
                        }
                        else
                            if (cur.IsKeyDown(Keys.Right) && cur.IsKeyDown(Keys.X) ||
                                cur.IsKeyDown(Keys.Left) && cur.IsKeyDown(Keys.X) ||
                                cur.IsKeyDown(Keys.X))
                            {
                                animationPlayer.PlayAnimation(jumpAnimation);
                                rectangle = new Rectangle((int)position.X - 10, (int)position.Y - 35, jumpTexture.Width, jumpTexture.Height);
                            }
                            else
                                if (cur.IsKeyDown(Keys.Right) && cur.IsKeyDown(Keys.Z) ||
                                    cur.IsKeyDown(Keys.Left) && cur.IsKeyDown(Keys.Z))
                                {
                                    animationPlayer.PlayAnimation(dashAnimation);
                                    rectangle = new Rectangle((int)position.X - 10, (int)position.Y - 35, dashTexture.Width, dashTexture.Height);
                                }
                                else
                                    if (cur.IsKeyDown(Keys.Z))
                                    {
                                        if (spriteEffects == SpriteEffects.None)
                                            velocity.X = 4f;
                                        if (spriteEffects == SpriteEffects.FlipHorizontally)
                                            velocity.X = -4f;
                                        animationPlayer.PlayAnimation(dashAnimation);
                                        rectangle = new Rectangle((int)position.X - 10, (int)position.Y - 35, dashTexture.Width, dashTexture.Height);
                                    }
                                    else
                                        if (cur.IsKeyDown(Keys.Right) || cur.IsKeyDown(Keys.Left))
                                        {
                                            animationPlayer.PlayAnimation(runAnimation);
                                            rectangle = new Rectangle((int)position.X - 10, (int)position.Y - 35, runTexture.Width / 4, runTexture.Height);
                                        }
                                        else
                                            animationPlayer.PlayAnimation(idleAnimation);

            if (cur.IsKeyDown(Keys.X) && hasJumped == false)
            {
                position.Y -= 10f;
                velocity.Y = -8f;
                hasJumped = true;
            }
            if (velocity.Y < 8)
                velocity.Y += 0.5f;
        }

        public void Collision(Rectangle newRectangle, int mapWidth, int mapHeight)
        {
            if (rectangle.TouchTopOf(newRectangle))
            {
                rectangle.Y = newRectangle.Y - rectangle.Height;
                velocity.Y = 0f;
                hasJumped = false;
            }
            if (rectangle.TouchLeftOf(newRectangle))
            {
                position.X = newRectangle.X - rectangle.Width + 17;
            }
            if (rectangle.TouchRightOf(newRectangle))
            {
                position.X = newRectangle.X + newRectangle.Width + 13 ;
            }
            if (rectangle.TouchBottomOf(newRectangle))
                velocity.Y = 1f;

            if (position.X < 0) position.X = 0;
            if (position.X > mapWidth - rectangle.Width) position.X = mapWidth - rectangle.Width;
            if (position.Y < 0) velocity.Y = 1f;
            if (position.Y > mapHeight - rectangle.Height) position.Y = mapHeight - rectangle.Height;
        }
        public void Draw(GameTime gameTime,SpriteBatch spriteBatch)
        {
            animationPlayer.Draw(gameTime, spriteBatch, position, spriteEffects);   
        }
    }
}
