using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender
{
    class WinningScreen : DialogBox
    {
        Texture2D playerTex;
        Texture2D control;

        public WinningScreen(Texture2D background, Texture2D buttonTex, SpriteFont font, Color color, Difficulty difficulty,Texture2D control, Player player, bool superShipWasAvailable, bool superShipAvailable, TimeSpan TotalTime, Rectangle window, SoundBank soundBack)
            : base(background, WallpaperType.Streched, buttonTex, font, window, soundBack)
        {
            this.playerTex = player.GetTexture;
            this.control = control;


            this.AddButton("Play Again", color, new Vector2(buttonTex.Width / 2f + buttonTex.Height / 3f, window.Height - buttonTex.Height / 3f));
            this.AddButton("Exit", color, new Vector2(buttonTex.Width * 2f + buttonTex.Height / 3f, window.Height - buttonTex.Height / 3f));

            this.AddLabel("Well Done! You have finished the game!", new Vector2(50));

            float w = window.Width / 2f-150;
            float h = window.Height / 14f;
            float t = 100;
             
            this.AddLabel("Bullets fired : " + player.GetBulletsFired,new Vector2(w,h+t));
            this.AddLabel("      Accuracy: " + player.GetBulletsAccuracy + "%", new Vector2(w, h * 2 + t));
            this.AddLabel("Missiles fired: " + player.GetMissilesFired, new Vector2(w, h * 3 + t));
            this.AddLabel("      Accuracy: " + player.GetMissilesAccuracy + "%", new Vector2(w, h * 4 + t));
            this.AddLabel("Total Accuracy: " + player.GetTotalAccuracy + "%", new Vector2(w, h * 5 + t));
            this.AddLabel("MidKits Used  : " + player.GetMidkitsUsed, new Vector2(w, h * 6 + t));
            this.AddLabel("Player Score  : " + player.GetPlayerScore , new Vector2(w, h * 7 + t));
            this.AddLabel("Time played     " + TotalTime.Hours +":" + TotalTime.Minutes + ":" + TotalTime.Seconds , new Vector2(w, h * 8 + t));

            this.AddAnimation( new Animation(playerTex, new Point(4, 1),new Vector2(100,window.Height/2f),20,true,font,difficulty.ToString(),window));
            this.AddAnimation( new Animation(control,new Point(1,3),new Vector2(150,window.Height/2f+100),700,false,font,"",window));

            if (superShipAvailable && !superShipWasAvailable)
                this.AddLabel("*Congratulations!! You've unlocked a new ship,The ultimate ship.", new Vector2(100, h * 9f + t));
        }
    }
}
