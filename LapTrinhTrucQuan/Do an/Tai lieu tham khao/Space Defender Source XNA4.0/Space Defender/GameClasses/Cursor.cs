using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Space_Defender
{
    // An animation that automatically moves with the mouse cursor
    class Cursor : Sprite
    {
        public Cursor(Texture2D textureImage, Point sheetSize, int millisecondsPerFrame, Rectangle window)
            : base(textureImage, sheetSize, Vector2.Zero, Vector2.Zero, millisecondsPerFrame, window, null,null)
        {
        }

        public Cursor(Texture2D textureImage, Point sheetSize)
            : base(textureImage, sheetSize, Vector2.Zero, Vector2.Zero, Rectangle.Empty, null,null)
        {
        }

        public Vector2 direction
        {
            get { return Vector2.Zero; }
        }

        public override void Update(GameTime gameTime)
        {
            position = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            base.Update(gameTime);
        }
    }
}
