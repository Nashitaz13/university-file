/*
 * Space Defender
 * Programmed by Hisham Ghosheh
 * Comments and suggestions are always welcome!
 * ghoshehsoft@live.com
 * www.ghoshehsoft.wordpress.com
 * 
*/


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

namespace Space_Defender
{
    enum ControlMethod { Mouse, Keyboard };
    enum Side { Player, Aliens, None };
    enum Difficulty { Easy,Medium,Difficult};
    enum GameState { MainMenu, HowToPlay, About, SelectShip, SelectControl, SelectDifficulty, InGame, Won, Lost, Results };
    enum WallpaperType { Streched , Centered}

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    /// 
    public class SpaceDefender : Microsoft.Xna.Framework.Game
    {
        SpriteManager spriteManager;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
       
        public SpaceDefender()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = GetScreenDimensions.X;
            graphics.PreferredBackBufferHeight = GetScreenDimensions.Y;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            spriteManager = new SpriteManager(this);                        
            Components.Add(spriteManager);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
          
            base.Draw(gameTime);
        }

        public Point GetScreenDimensions
        {
            get
            {
                return new Point(graphics.GraphicsDevice.DisplayMode.Width, graphics.GraphicsDevice.DisplayMode.Height);
            }
        }
    }
}
