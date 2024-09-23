using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender
{
    abstract class DialogBox // A class that can contain labels and buttons
    {
        SoundBank soundBack;


        Texture2D background;
        WallpaperType wallpaperType;
        List<Button> buttons = new List<Button>();
        List<Label> labels = new List<Label>();
        List<Animation> animations = new List<Animation>();

        Texture2D buttonTex; // Must be 1*3 sprite sheet
        Point frameSize; // For the button sprite sheet

        SpriteFont font;

        Rectangle window;

        public DialogBox(Texture2D background, WallpaperType wallpaperType, Texture2D buttonTex, SpriteFont font, Rectangle window, SoundBank soundBack)
        {
            this.background = background;
            this.wallpaperType = wallpaperType;
            this.buttonTex = buttonTex;
            this.font = font;
            this.window = window;
            this.frameSize = new Point(buttonTex.Width, buttonTex.Height/3);

            this.soundBack = soundBack;
        }

        public DialogBox(Texture2D buttonTex, SpriteFont font, Rectangle window, SoundBank soundBack)
            : this(null, WallpaperType.Centered, buttonTex, font, window, soundBack)
        {
        }

        public virtual void Update(GameTime gameTime)
        {
            // Update buttons
            foreach (Button button in buttons)
                button.Update(gameTime);

            // Update animations
            foreach (Animation animation in animations)
                animation.Update(gameTime);

            // Labels don't need to be updated
        }


        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (background != null)
            {                
                if (wallpaperType == WallpaperType.Centered)
                    spriteBatch.Draw(background, new Vector2(window.Width / 2f, window.Height / 2f) - new Vector2(background.Width / 2f, background.Height / 2f), Color.White);
                else if (wallpaperType==WallpaperType.Streched)
                    spriteBatch.Draw(background,new Rectangle(0,0,window.Width,window.Height),Color.White);
            }

            // Draw animations
            foreach (Animation animation in animations)
                animation.Draw(gameTime,spriteBatch);

            // Draw labels first
            foreach (Label label in labels)
                label.Draw(gameTime, spriteBatch);

            // Draw buttons second, therefore buttons will always be in front of labels
            foreach (Button button in buttons)
                button.Draw(gameTime, spriteBatch);
        }

        public virtual string ClickedButtonText
        {
            get
            {
                foreach (Button button in buttons)
                    if (button.Clicked) return button.Text;

                return "";
            }
        }

        public virtual void AddButton(Button button)
        {
            buttons.Add(button);
        }

        public virtual void AddButton(string text,Color color, Vector2 position)
        {
            this.AddButton(new Button(buttonTex, text, font,color, position,soundBack));
        }

        public virtual void AddLabel(Label label)
        {
            labels.Add(label);
        }

        public virtual void AddLabel(string text, Vector2 position)
        {
            this.AddLabel(new Label(font, position, text));
        }

        public virtual void AddAnimation(Animation animation)
        {
            this.animations.Add(animation);
        }
    }
}
