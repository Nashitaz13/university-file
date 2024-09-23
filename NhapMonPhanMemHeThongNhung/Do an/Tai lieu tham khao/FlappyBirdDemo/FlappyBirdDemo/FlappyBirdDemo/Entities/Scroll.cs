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

namespace FlappyBirdDemo.Entities
{
    public class Scroll
    {
        public Vector2 position;
        public Texture2D texture;

        public int animTimer = 10;
        public double animElapsed = 0;
        public int decalX = 0;

        public Scroll()
        {
            position = new Vector2(0, 529);
            texture = Statics.CONTENT.Load<Texture2D>("Textures/scroll");
        }
        public void Update()
        {
            animElapsed += Statics.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            if (animElapsed > animTimer)
            {
                this.decalX += 2;
                if (this.decalX > 12)
                    this.decalX = 0;

                animElapsed = 0;
            }
        }
        public void Draw()
        {
            Statics.SPRITEBATCH.Draw(this.texture, this.position, new Rectangle(this.decalX, 0, Statics.GAME_WIDTH, 12), Color.White);
        }
    }
}
