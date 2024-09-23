using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace New
{
    class Background
    {
        Texture2D background1, background2, background3, background4, background5, background6, background7, background8;
        Vector2 position1, position2, position3, position4, position5, position6, position7, position8;

        public void LoadContent(ContentManager Content)
        {
            background1 = Content.Load<Texture2D>("Background/Background1");
            position1 = new Vector2(0, 0);
            background2 = Content.Load<Texture2D>("Background/Background2");
            position2 = new Vector2(800, 0);
            background3 = Content.Load<Texture2D>("Background/Background1");
            position3 = new Vector2(800*2, 0);
            background4 = Content.Load<Texture2D>("Background/Background2");
            position4 = new Vector2(800*3, 0);
            background5 = Content.Load<Texture2D>("Background/Background1");
            position5 = new Vector2(800*4, 0);
            background6 = Content.Load<Texture2D>("Background/Background2");
            position6 = new Vector2(800*5, 0);
            background7 = Content.Load<Texture2D>("Background/Background1");
            position7 = new Vector2(800 * 6, 0);
            background8 = Content.Load<Texture2D>("Background/Background2");
            position8 = new Vector2(800 * 7, 0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background1, position1, Color.White);
            spriteBatch.Draw(background2, position2, Color.White);
            spriteBatch.Draw(background3, position3, Color.White);
            spriteBatch.Draw(background4, position4, Color.White);
            spriteBatch.Draw(background5, position5, Color.White);
            spriteBatch.Draw(background6, position6, Color.White);
            spriteBatch.Draw(background7, position7, Color.White);
            spriteBatch.Draw(background8, position8, Color.White);
        }
    }
}
