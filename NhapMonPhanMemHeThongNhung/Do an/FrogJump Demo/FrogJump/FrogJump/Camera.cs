using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrogJump
{
    class Camera
    {
        public Viewport view;
        public Matrix transform;
        public Vector2 centre;

        public Camera(Viewport newView)
        {
            view = newView;
        }
        public void Update(GameTime gameTime, Frog frog)
        {
            centre = new Vector2(0, frog.position.Y + frog.frogTexture.Height/2);
            transform = Matrix.CreateScale(new Vector3(1, 1, 0)) *
                Matrix.CreateTranslation(new Vector3(centre.X, Statics.HEIGHT_SCREEN - (40*Statics.SCALE) - centre.Y, 0));
        }
    }
}