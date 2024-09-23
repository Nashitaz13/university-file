using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

using XNA_RPG_textMapEditor.Helper;

namespace XNA_RPG_textMapEditor.GUI
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Menu : Microsoft.Xna.Framework.DrawableGameComponent
    {
        List<Button> buttons = new List<Button>();
        int index = 0;
        #region Property
        public List<Button> Buttons
        {
            get { return buttons; }
            set { buttons = value; }
        }
        
        public int Index
        {
            get { return index; }
        }
        #endregion
        //service
        Input input;
        public Menu(Game game,List<Button> buttons)
            : base(game)
        {
            this.buttons = buttons;
            input = (Input)Game.Services.GetService(typeof(Input)) as Input;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            buttons[index].status = Button.Status.active;

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (input.Release(Keys.Up))
            {
                buttons[index].status = Button.Status.wait;
                if (index == 0)
                    index = buttons.Count-1;
                else
                    index--;
                buttons[index].status = Button.Status.active;
            }
            if (input.Release(Keys.Down))
            {
                buttons[index].status = Button.Status.wait;
                if (index + 1 == buttons.Count)
                    index = 0;
                else
                    index++;
                buttons[index].status = Button.Status.active;
            }

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            //Draw all buttons
            foreach (Button button in buttons)
                button.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}