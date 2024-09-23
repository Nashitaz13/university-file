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



namespace XNA_RPG_textMapEditor.GUI
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Button : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public string Label;
        public Vector2 Position { get; set; }
        public List<Texture2D> textures {get;set;}
        public enum Status
        {
            active = 0,
            wait
        }
        public Status status { get; set; }
        //service:
        SpriteBatch sBatch;

        public Button(Game game,Texture2D active,Texture2D wait,Status status)
            : base(game)
        {
            textures = new List<Texture2D>();
            textures.Add(active);
            textures.Add(wait);
            this.status = status;
            // lay services tu` RPG game
            sBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch)) as SpriteBatch;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            sBatch.Draw(textures[(int)status], Position, Color.White);
            
            base.Draw(gameTime);
        }
    }
}