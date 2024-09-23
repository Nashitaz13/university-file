using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Game2
{
    public class Player
    {
        Animation idle;
        Animation walking;
        Animation jumping;
        Animation shooting;
        Animation dashing;

        public Animation currentAnimation;

        Weapon currentWeapon;
        int bulletIndex;
        bool slopeCollision = false;

        Texture2D texture;
        Vector2 position;
        Vector2 velocity;
        Vector2 acceleration;
        int width;
        int height;
        Vector2 animationTransition;

        public bool facingRight = true;
        public bool facingLeft = false;
        public bool isOnGround;
        bool isDashing;
 
        double jumpTimerMax = 640;
        double shootTimerMax = 400;
        double jumpTimer = 641;
        double shootTimer = 401;

        Rectangle[] boundingBoxes = new Rectangle[4];
        Rectangle slopeBottomDetector;

        public Rectangle[] BoundingBoxes { get { return boundingBoxes; } }
        public Vector2 Position { get { return position; } }
        public Weapon CurrentWeapon { get { return currentWeapon; } }

        public Player(Texture2D texture, Vector2 position, Weapon weapon)
        {
            this.texture = texture;
            this.position = position;
            currentWeapon = weapon;
            acceleration = new Vector2(0, 1f);
            isOnGround = false;

            initializeAnimations();
            width = currentAnimation.drawRectangle.Width;
            height = currentAnimation.drawRectangle.Height;
            bulletIndex = 0;

        }
        

        void jump()
        {
            velocity.Y = -20f;
            isOnGround = false;
            jumpTimer = 0;
        }

        void initializeAnimations()
        {
            idle = new Animation(new Vector2(3, 45), texture, position, 43, 49, 8, 200, Color.White, true, 3f);
            walking = new Animation(new Vector2(55, 103), texture, position, 54, 54, 14, 80, Color.White, true, 3f);
            jumping = new Animation(new Vector2(0, 158), texture, position, 40, 61, 10, 64, Color.White, false, 3f);
            shooting = new Animation(new Vector2(0, 356), texture, position, 57, 48, 8, 40, Color.White, false, 3f);
            dashing = new Animation(new Vector2(6, 635), texture, position, 41, 56, 6, 30, Color.White, true, 3f);
            currentAnimation = idle;
            
        }

        public void updatePlayer(GameTime gameTime, InputManager input, Level1 level)
        {
            Result result;
            jumpTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
            shootTimer += gameTime.ElapsedGameTime.TotalMilliseconds;
            
            acceleration.X = 0f;
            if (velocity.X - 8f > 0f)
                velocity.X -= 8f;
            else if (velocity.X - 8f <= 0f && velocity.X > 0f)
                velocity.X = 0f;
            if (velocity.X + 8f < 0f)
                velocity.X += 8f;
            else if (velocity.X + 8f >= 0f && velocity.X < 0f)
                velocity.X = 0f;

            if (isOnGround)
            {
                velocity.Y = 0f;
            }
            else
            {
                acceleration.Y = 1f;
            }

            if (input.movingRight)
            {
                acceleration.X = 8f;
                facingRight = true;
                facingLeft = false;
            }
            if (input.movingLeft)
            {
                acceleration.X = -8f;
                facingLeft = true;
                facingRight = false;
            }

            if (input.isJumping && (isOnGround || slopeCollision))
            {
                jump();
                slopeCollision = false;
            }

            isDashing = false;
            if (input.isDashing)
            {
                isDashing = true;
            }
            velocity += acceleration;

            

            if (velocity.X > 16f)
                velocity.X = 16f;
            if (velocity.X < -16f)
                velocity.X = -16f;
            
            if (input.isShooting && isOnGround)
            {
                if (input.facingLeft)
                {
                    currentWeapon.Bullets[bulletIndex].setPosition(
                        new Vector2(position.X,
                                    position.Y + (height) / 4));
                    currentWeapon.Bullets[bulletIndex].setVelocity(new Vector2(-24f, 0));
                    currentWeapon.Bullets[bulletIndex].active = true;
                }
                else
                {
                    currentWeapon.Bullets[bulletIndex].setPosition(new Vector2(position.X + width - width /4,
                                                position.Y + (height) / 4));
                    currentWeapon.Bullets[bulletIndex].setVelocity(new Vector2(24f, 0));
                    currentWeapon.Bullets[bulletIndex].active = true;
                }
                bulletIndex++;
                if (bulletIndex >= currentWeapon.BulletCount)
                    bulletIndex = 0;
                shootTimer = 0;
                shooting.currentFrame = 0;
            }
            result = UnitLevelCollision.Detect(this, level);
            Vector2 slopeUnitVector = new Vector2();
            slopeCollision = false;
            for (int i = 0; i < level.BoundingSlopes.Count; i++)
                for (int j = 0; j < level.BoundingSlopes[i].BoundingBoxes.Count; j++)
                {
                    if (slopeBottomDetector.Intersects(level.BoundingSlopes[i].BoundingBoxes[j]))
                        if (facingRight)
                        {
                            slopeUnitVector = level.BoundingSlopes[i].PositiveSlope;
                            slopeCollision = true;
                            isOnGround = true;
                        }
                        else
                        {
                            slopeUnitVector = level.BoundingSlopes[i].NegativeSlope;
                            slopeCollision = true;
                            isOnGround = true;
                        }
                }

            if (isDashing)
            {
                if (facingRight && !result.contactRight)
                {
                    velocity.X = 32f;
                    position.Y *= 1;
                    position.X += velocity.X;
                }
                if (facingLeft && !result.contactLeft)
                {
                    velocity.X = -32f;
                    position.Y *= 1;
                    position.X += velocity.X;
                }
            }
            else if (shootTimer < shootTimerMax)
            {
                position.X *= 1;
                position.Y += velocity.Y;
            }
            else
            {
                if (slopeCollision && (input.movingRight || input.movingLeft) && (jumpTimer > jumpTimerMax))
                {
                    float scalar = Vector2.Dot(slopeUnitVector, velocity);
                    velocity = Vector2.Multiply(slopeUnitVector, scalar);
                }
                position += velocity;
            }

            if (result.contactBottom)
            {
                position = new Vector2(position.X, position.Y - result.downwardBox.Height);
                isOnGround = true;
            }

            else
                isOnGround = false;
            if (result.contactRight && facingRight)
            {
                position = new Vector2(position.X - result.rightBox.Width +1, position.Y);
                isDashing = false;
                velocity.X = 0f;
            }
            if (result.contactLeft && facingLeft)
            {
                position = new Vector2(position.X + result.leftBox.Width -1, position.Y);
                isDashing = false;
                velocity.X = 0f;
            }
            if (result.contactTop)
            {
                position = new Vector2(position.X, position.Y + result.upwardBox.Height);
                velocity.Y = 0f;
                jumpTimer += 100;
            }


            for (int i = 0; i < currentWeapon.BulletCount; i++)
            {
                if (BulletLevelCollision.Detect(currentWeapon.Bullets[i], level))
                    currentWeapon.Bullets[i].setVelocity(new Vector2(-currentWeapon.Bullets[i].Velocity.X, -20f));
                currentWeapon.Bullets[i].setPosition(currentWeapon.Bullets[i].Position + currentWeapon.Bullets[i].Velocity);
            }
            

            if (shootTimer < shootTimerMax)
            {
                currentAnimation = shooting;
                shooting.active = true;
                jumping.active = false;
                walking.active = false;
                idle.active = false;
            }
            else if (isDashing)
            {
                currentAnimation = dashing;
                dashing.active = true;
                shooting.active = false;
                jumping.active = false;
                walking.active = false;
                idle.active = false;
            }
            else if (jumpTimer < jumpTimerMax)
            {
                currentAnimation = jumping;
                jumping.active = true;
                walking.active = false;
                idle.active = false;

            }
            else if (input.movingRight || input.movingLeft)
            {
                currentAnimation = walking;
                walking.active = true;
                idle.active = false;
                jumping.active = false;
            }
            else
            {
                currentAnimation = idle;
                walking.active = false;
                idle.active = true;
                jumping.active = false;
            }
            int widthOffset = width - currentAnimation.drawRectangle.Width;
            int heightOffset = height - currentAnimation.drawRectangle.Height;
            animationTransition = new Vector2(widthOffset, heightOffset);
            
            width = currentAnimation.drawRectangle.Width;
            height = currentAnimation.drawRectangle.Height;
            currentAnimation.updateAnimation(gameTime, position, facingRight, facingLeft);
            position += animationTransition;
            
            boundingBoxes[0] = new Rectangle((int)position.X + width / 4, (int)position.Y, width /2, height / 4); //top
            boundingBoxes[1] = new Rectangle((int)position.X + width / 2, (int)position.Y + height/4, width /2, height /2); //rightSide
            boundingBoxes[2] = new Rectangle((int)position.X + width / 4, (int)position.Y + height - height /4, width /2, height /4); //bottom
            boundingBoxes[3] = new Rectangle((int)position.X, (int)position.Y + height / 4, width / 2, height / 2); //leftSide
            slopeBottomDetector = new Rectangle((int)position.X - width / 2, (int)position.Y + height - height / 4, width + width / 2, height / 4);

            
        }

        public void drawAnimatedObject(SpriteBatch spriteBatch)
        {   
            currentAnimation.draw(spriteBatch);
        }

       
    }
}
