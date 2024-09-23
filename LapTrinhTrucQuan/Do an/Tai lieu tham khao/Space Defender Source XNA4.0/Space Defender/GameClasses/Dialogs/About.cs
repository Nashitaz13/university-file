using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender
{
    class About : DialogBox
    {
        public About(Texture2D backGround, Texture2D buttonTex, SpriteFont font, Color color, Rectangle window, SoundBank soundBack)
            : base(backGround, WallpaperType.Centered, buttonTex, font, window, soundBack)
        {            
            this.AddButton("Back",color, new Vector2(window.Width / 2f, window.Height / 2f) + new Vector2(backGround.Width / 2f-buttonTex.Width/2f, backGround.Height / 2f+ buttonTex.Height/3f));
        }
    }
}
