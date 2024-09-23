using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace Space_Defender
{
    class SelectDifficulty : DialogBox
    {
        public SelectDifficulty(Texture2D background,Texture2D buttonTex, SpriteFont font, Rectangle window, SoundBank soundBank)
            : base(background ,WallpaperType.Streched  ,buttonTex, font, window, soundBank)
        {
            this.AddLabel("Select Game Difficulty : ",new Vector2(100));
            this.AddButton("Easy", Color.Snow, new Vector2(window.Width / 2f, window.Height / 2f - 1.5f * (buttonTex.Height / 3f)));
            this.AddButton("Medium", Color.Snow, new Vector2(window.Width / 2f, window.Height / 2f));
            this.AddButton("Difficult", Color.Snow, new Vector2(window.Width / 2f, window.Height / 2f + 1.5f * (buttonTex.Height / 3f)));
        }
    }
}
