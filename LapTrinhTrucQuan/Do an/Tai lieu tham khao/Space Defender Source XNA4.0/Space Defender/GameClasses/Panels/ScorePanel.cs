using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender
{
    // This class will display the player's score, It has an auto resize ability
    class ScorePanel
    {
        protected Texture2D panelTex;
        protected SpriteFont font;

        protected float playerScore = 0;

        protected Vector2 position;
        protected float charWidth = 10;

        public ScorePanel(Texture2D panelTex, SpriteFont font, float charWidth)
        {
            this.panelTex = panelTex;
            this.font = font;
            this.charWidth = charWidth;
        }

        public void Update(GameTime gameTime, float playerScore)
        {
            // Make the panel pop from the top of the screen
            if (position.Y < 0)
            {
                position.Y += 0.7f;
            }

            this.playerScore = playerScore;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Draw the most left part of the panel
            spriteBatch.Draw(panelTex, position,
                new Rectangle(0, 0, 3, 30), Color.White);

            // Draw the middile part of the panel
            int i = 0;
            for (i = 0; i <= playerScore.ToString().Length + "Score : ".Length; i++)
            {
                spriteBatch.Draw(panelTex, position + new Vector2(i * charWidth, 0),
                new Rectangle(3, 0, (int)charWidth, 30), Color.White);
            }

            // Draw the most right part of the pannel
            spriteBatch.Draw(panelTex, position + new Vector2(i * charWidth, 0),
                new Rectangle(26, 0, 6, 30), Color.White);

            // Display score
            spriteBatch.DrawString(font, "Score : " + playerScore, position + new Vector2(3, 3), Color.White);
        }
    }
}
