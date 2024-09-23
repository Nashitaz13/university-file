using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Space_Defender
{
    // This class is almost a graphical button
    class Animation : Sprite
    {
        protected SpriteFont font;
        protected string description;
        protected bool rotate = false;
        protected bool readyForHalfClick = false; // Mosue is over & button is realeased
        protected bool clicked = false;
        protected bool halfClick = false;
        protected bool wasReleased = false;
        protected bool mouseOver = false;

        public Animation(Texture2D textureImage, Point sheetSize, Vector2 position, int millisecondsPerFrame, bool rotate, SpriteFont font, string description, Rectangle window)
            : base(textureImage, sheetSize, position, Vector2.Zero, millisecondsPerFrame, window, null,null)
        {
            this.font = font;
            this.description = description;
            this.rotate = rotate;
        }


        public Vector2 direction
        {
            get { return Vector2.Zero; }
        }

        public virtual void SetPosition(Vector2 position)
        {
            this.position = position;
        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            clicked = false;
            mouseOver = false;

            if (this.collisionRect.Intersects(new Rectangle(mouseState.X, mouseState.Y, 1, 1)))
                mouseOver = true;
            else
                halfClick = false;

            if (mouseOver && halfClick && mouseState.LeftButton == ButtonState.Released)
            {
                halfClick = false;
                wasReleased = false;
                clicked = true;
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

            if (rotate) rotation += 0.01f;
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, description, position + new Vector2(frameSize.X, 0), Color.White);
            base.Draw(gameTime, spriteBatch);
        }

        public bool Clicked
        {
            get
            {
                return clicked;
            }
        }
    }
}
