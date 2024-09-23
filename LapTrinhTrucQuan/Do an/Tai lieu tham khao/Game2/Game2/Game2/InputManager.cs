using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    public class InputManager
    {
        KeyboardState keyboardState;
        GamePadState gamePadState;

        public bool rightDown = false;
        public bool rightUp = false;
        public bool leftDown = false;
        public bool leftUp = false;
        public bool jumpDown = false;
        public bool jumpUp = false;
        public bool shootDown = false;
        public bool shootUp = false;
        public bool dashDown = false;
        public bool dashUp = false;

        public bool facingLeft = false;
        public bool facingRight = true;

        public bool isShooting = false;
        public bool isJumping = false;
        public bool movingRight = false;
        public bool movingLeft = false;
        public bool alreadyShot = false;
        public bool isDashing = false;

        private double inputTimer = 0f;

        public void update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();
            gamePadState = GamePad.GetState(PlayerIndex.One);
            
            inputTimer -= gameTime.ElapsedGameTime.Milliseconds;

            if (inputTimer <= 0f)
                inputTimer = 0f;

            if (keyboardState.IsKeyDown(Keys.Right) || (gamePadState.DPad.Right == ButtonState.Pressed ))
            {
                rightDown = true;
                rightUp = false;
            }
            else if (keyboardState.IsKeyUp(Keys.Right) || (gamePadState.DPad.Right == ButtonState.Released))
            {
                rightUp = true;
                rightDown = false;
            }
            if (keyboardState.IsKeyDown(Keys.Left) || gamePadState.DPad.Left == ButtonState.Pressed)
            {
                leftDown = true;
                leftUp = false;
            }
            else if (keyboardState.IsKeyUp(Keys.Left) || gamePadState.DPad.Left == ButtonState.Released)
            {
                leftUp = true;
                leftDown = false;
            }
            if (keyboardState.IsKeyDown(Keys.Z) || gamePadState.Buttons.X == ButtonState.Pressed)
            {
                shootDown = true;
                shootUp = false;
            }
            else if (keyboardState.IsKeyUp(Keys.Z) || gamePadState.Buttons.X == ButtonState.Released)
            {
                shootUp = true;
                shootDown = false;
                alreadyShot = false;
            }
            if (keyboardState.IsKeyDown(Keys.Space) || gamePadState.Buttons.A == ButtonState.Pressed)
            {
                jumpDown = true;
                jumpUp = false;
            }
            else if (keyboardState.IsKeyUp(Keys.Space) || gamePadState.Buttons.A == ButtonState.Released)
            {
                jumpUp = true;
                jumpDown = false;
            }
            if (keyboardState.IsKeyDown(Keys.X) || gamePadState.Buttons.RightShoulder == ButtonState.Pressed)
            {
                dashDown = true;
                dashUp = false;
            }
            else if (keyboardState.IsKeyUp(Keys.X) || gamePadState.Buttons.RightShoulder == ButtonState.Pressed)
            {
                dashDown = false;
                dashUp = true;
            }

            if (rightDown && !rightUp)
            {
                movingRight = true;
                facingRight = true;
                facingLeft = false;
            }
            else
            {
                movingRight = false;
            }
            if (leftDown && !leftUp)
            {
                movingLeft = true;
                facingLeft = true;
                facingRight = false;
            }
            else
                movingLeft = false;
            if (shootDown && !shootUp && !alreadyShot)
            {
                isShooting = true;
                alreadyShot = true;
            }
            else
                isShooting = false;
            if (jumpDown && !jumpUp)
            {
                isJumping = true;
            }
            else
                isJumping = false;
            if (dashDown && !dashUp)
                isDashing = true;
            else
                isDashing = false;
           
        }
    }
}
