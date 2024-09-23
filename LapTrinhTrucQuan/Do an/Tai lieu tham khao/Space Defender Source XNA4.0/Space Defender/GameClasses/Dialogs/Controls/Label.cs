using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender
{
    class Label
    {
        protected SpriteFont font;

        protected string text; // Text to be drawn
        protected int charsPerLine; // This class allows text wrapping
        protected int distanceBetweenLines;

        protected List<string> lines = new List<string>();

        protected Vector2 position;

        public Label(SpriteFont font,Vector2 position,string text,int charsPerLine,int distanceBetweenLines)
        {
            this.font=font;
            this.position=position;
            this.text=text;
            this.charsPerLine = charsPerLine;
            this.distanceBetweenLines = distanceBetweenLines;

            if (charsPerLine == 0) return; // No wrapping

            string[] words = text.Split(' ');
            string line = "";
            
            for (int i = 0; i <= words.Count() - 1; i++)
            {
                if (words[i].Length >= charsPerLine)
                {
                    if (line != "") lines.Add(line);
                    lines.Add(words[i]);
                }
                else
                {
                    if (line.Length < charsPerLine)
                    {
                        line += words[i] + " ";
                    }
                    else
                    {
                        lines.Add(line);
                        line = "";
                        --i;
                    }
                }
            }
            if (line != "") lines.Add(line);
        }

        public Label(SpriteFont font, Vector2 position, string text)
            :this(font,position,text,0,0)
        {
        }

        public virtual void Draw(GameTime gameTime,SpriteBatch spriteBatch)
        {
            if (charsPerLine == 0) // All text in one line
            {
                spriteBatch.DrawString(font, text, position, Color.White);
                return;
            }

            Vector2 pen = position;
            foreach (string s in lines)
            {
                spriteBatch.DrawString(font, s, pen, Color.White);
                pen.Y += distanceBetweenLines;
            }
        }

        public virtual void SetText(string text)
        {
            this.text = text;
        }
    }
}
