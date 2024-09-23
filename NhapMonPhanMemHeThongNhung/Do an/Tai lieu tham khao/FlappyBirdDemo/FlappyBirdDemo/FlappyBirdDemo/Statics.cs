using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FlappyBirdDemo
{
    public class Statics
    {
        public static int GAME_HIGHT = 600;
        public static int GAME_WIDTH = 400;

        public static String GAME_TILTE = "PlappyBrird - SpeedCoding";

        public static GameTime GAMETIME;
        public static ContentManager CONTENT;
        public static SpriteBatch SPRITEBATCH;
        public static GraphicsDevice GRAPHICSDEVICE;

        public static Managers.InputManager INPUT;

        public static Texture2D PIXEL;

        public static Random RANDOM = new Random();
    }
}
