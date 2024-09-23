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
    class Button
    {
        protected bool mouseOverSoundPlayed = false;
        protected SoundBank soundBack;

        protected Texture2D buttonTex; // Must be 1*3 sprite
        protected Point currentFrame;
        protected Point frameSize;

        protected string text; // Text to be drawn on the button
        protected SpriteFont font;
        protected Color color;
        
        protected Vector2 position;

        protected bool readyForHalfClick = false; // Mosue is over & button is realeased
        protected bool halfClick = false; // Needed to allow the third part of the sprite to be drawn
        protected bool clicked = false;
        protected bool wasReleased = false; // To make sure that unintentional clicking doesn't happen
        protected bool mouseOver = false;

        public Button(Texture2D buttonTex, string text, SpriteFont font,Color color, Vector2 position,SoundBank soundBack)
        {
            this.buttonTex = buttonTex;
            this.frameSize = new Point(buttonTex.Width,buttonTex.Height/3);
            this.text = text;
            this.font = font;
            this.color = color;
            this.position = position;

            this.soundBack = soundBack;
        }

        public virtual void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            currentFrame = Point.Zero; // First frame
            clicked = false;
            mouseOver = false;

            if (this.collisionRect.Intersects(new Rectangle(mouseState.X, mouseState.Y, 1, 1)))
            {
                mouseOver = true;
                if (mouseOverSoundPlayed == false)
                    soundBack.PlayCue("ButtonMouseOver");

                mouseOverSoundPlayed = true;
            }
            else
            {
                mouseOverSoundPlayed = false;
                halfClick = false;
            }

            if (mouseOver && halfClick && mouseState.LeftButton == ButtonState.Released)
            {
                halfClick = false;
                wasReleased = false;
                clicked = true;
                soundBack.PlayCue("ButtonClick");
            }

            if (readyForHalfClick && wasReleased && mouseOver && mouseState.LeftButton == ButtonState.Pressed)
            {
                halfClick = true;
                wasReleased = false;
            }

            if (mouseOver && mouseState.LeftButton == ButtonState.Released)
                readyForHalfClick = true;
            else
                readyForHalfClick = false;

            if (mouseState.LeftButton == ButtonState.Released) wasReleased = true;

            if (halfClick)
                currentFrame = new Point(0, 2); // Third frame
            else if (mouseOver)
                currentFrame = new Point(0, 1); // Second frame
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                buttonTex,
                position,
                new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y),
                Color.White, 0, new Vector2(frameSize.X / 2f, frameSize.Y / 2f), 1f, SpriteEffects.None, 0);

            spriteBatch.DrawString(font, text, position - new Vector2(frameSize.X / 2f, frameSize.Y / 2f) + new Vector2(30, 20), color);
        }

        public bool Clicked
        {
            get
            {
                return clicked;
            }
        }

        public bool MouseOver
        {
            get
            {
                return mouseOver;
            }
        }

        public string Text
        {
            get
            {
                return text;
            }
        }

        protected virtual Rectangle collisionRect
        {
            get
            {
                return new Rectangle((int)(position.X - frameSize.X / 2), (int)(position.Y - frameSize.Y / 2), frameSize.X, frameSize.Y);
            }
        }

    }
}
