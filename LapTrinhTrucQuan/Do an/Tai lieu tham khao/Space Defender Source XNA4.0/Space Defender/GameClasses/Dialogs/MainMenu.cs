using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender
{
    class MainMenu : DialogBox
    {
        public MainMenu(Texture2D buttonTex, SpriteFont font, Color color, Rectangle window, SoundBank soundBack)
            : base(buttonTex, font, window, soundBack)
        {
            int w = window.Width / 4;
            int h = window.Height / 4;
            this.AddButton("Start Game",color,new Vector2(w,h)+new Vector2(300,0));
            this.AddButton("How To Play",color,new Vector2(w, h) + new Vector2(250,100));
            this.AddButton("About",color,new Vector2(w, h)+ new Vector2(230,200));
            this.AddButton("Exit",color,new Vector2(w, h)+ new Vector2(250,300));
        }
    }
}
