using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Game2
{
    public class Camera
    {
        Vector2 position;
        Matrix viewMatrix;

        public Matrix viewPMatrix { get { return viewMatrix; } }
        public int screenWidth { get { return GraphicsDeviceManager.DefaultBackBufferWidth; } }
        public int screenHeight { get { return GraphicsDeviceManager.DefaultBackBufferHeight; } }

        public void update(Vector2 playerPosition)
        {
            position.X = playerPosition.X - screenWidth / 2;
            position.Y = playerPosition.Y - screenHeight / 1.5f;

            if (position.X < 0)
                position.X = 0;
            if (position.Y < 0)
                position.Y = 0;

            viewMatrix = Matrix.CreateTranslation(new Vector3(-position, 0));
        }
    }
}
