using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Game2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        Camera camera;
        SpriteFont font;
        InputManager input;
        UnitLevelCollision unitLevelCollision = new UnitLevelCollision();
        Level1 level1;
        Weapon defaultWeapon;
        Enemy[] enemies = new Enemy[2];

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
        }

        protected override void Initialize()
        {
            input = new InputManager();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Load Textures and Fonts
            Texture2D playerTexture = Content.Load<Texture2D>("MegaManSpriteSheet");
            Texture2D bulletTexture = Content.Load<Texture2D>("bullet");
            Texture2D levelTexture = Content.Load<Texture2D>("wall");
            Texture2D enemyTexture = Content.Load<Texture2D>("enemy");
            font = Content.Load<SpriteFont>("SpriteFont1");

            //Intialize Game Objects
            level1 = new Level1(levelTexture);
            defaultWeapon = new Weapon("buster", 10, bulletTexture);
            player = new Player(playerTexture, new Vector2(500, 500), defaultWeapon);
            enemies[0] = new Enemy(enemyTexture, new Vector2(1600, 900), new Vector2(10, 0), 10, true);
            enemies[1] = new Enemy(enemyTexture, new Vector2(3849, 175), new Vector2(0, 10), 10, true);
            camera = new Camera();

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            input.update(gameTime);
            player.updatePlayer(gameTime, input, level1);
            for (int i = 0; i < enemies.Length; i++)
                enemies[i].update();
            BulletEnemyCollsion.detect(player.CurrentWeapon.Bullets, enemies);
            camera.update(player.Position);


            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.viewPMatrix);

            
            level1.draw(spriteBatch);
            for (int i = 0; i < enemies.Length; i++)
                enemies[i].draw(spriteBatch);
            player.drawAnimatedObject(spriteBatch);
            for(int i = 0; i < 10; i++)
                player.CurrentWeapon.Bullets[i].draw(spriteBatch);
            spriteBatch.End();

            spriteBatch.Begin();
            spriteBatch.DrawString(font, Convert.ToString(player.Position.X), new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(font, Convert.ToString(player.Position.Y), new Vector2(0, 25), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
