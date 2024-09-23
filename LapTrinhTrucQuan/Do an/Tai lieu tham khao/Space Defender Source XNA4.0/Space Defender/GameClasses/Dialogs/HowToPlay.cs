using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender
{
    class HowToPlay : DialogBox
    {
        public HowToPlay(Texture2D backGround, WallpaperType wallpaperType, Texture2D buttonTex, SpriteFont font, Color color, Rectangle window, SoundBank soundBack)
            : base(backGround, wallpaperType, buttonTex, font, window, soundBack)
        {
            this.AddButton("Start Game",color, new Vector2(window.Width / 2f, window.Height / 2f) + new Vector2(backGround.Width / 2f, backGround.Height / 2f) - new Vector2(0, buttonTex.Height));
            this.AddButton("Back",color,  new Vector2(window.Width / 2f, window.Height / 2f) + new Vector2(backGround.Width / 2f, backGround.Height / 2f) - new Vector2(50, buttonTex.Height/2f));
        }
    }
}
