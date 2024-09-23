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
using Microsoft.Xna.Framework.Input.Touch;

namespace FrogJump
{
    public class Statics
    {
        public static float SCALE;
        public static Random RANDOM = new Random();
        public static Texture2D PIXEL;
        public static int HEIGHT_SCREEN = 800;
        public static int WIDTH_SCREEN = 480;
        public static int LEAFS_COUNT = 5;
        public static int LIFE = 5;
    }
}
