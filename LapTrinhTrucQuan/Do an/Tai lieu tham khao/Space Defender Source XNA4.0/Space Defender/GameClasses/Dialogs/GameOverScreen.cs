using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender
{
    class GameOverScreen:DialogBox
    {
        public GameOverScreen(Texture2D buttonTex, SpriteFont font, Color color, Rectangle window, SoundBank soundBack)
            : base(buttonTex, font, window, soundBack)
        {
            this.AddLabel("Game Over!! you've lost the battle!.But it's not too late,wanna try again?", new Vector2(100,window.Height/3f));
            this.AddButton("Try Again",color, new Vector2(window.Width/2f-buttonTex.Width,window.Height/2f+70));
            this.AddButton("Exit",color, new Vector2(window.Width / 2f+30f, window.Height / 2f + 70));
        }
    }
}
