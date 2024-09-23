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

using XNA_RPG_textMapEditor.Scene;
using XNA_RPG_textMapEditor.Enemy;
using XNA_RPG_textMapEditor.Core;
using XNA_RPG_textMapEditor.Helper;
using XNA_RPG_textMapEditor.Controller;
using XNA_RPG_textMapEditor.Level.World1;
///
/// XNA_RPG textMapEditor engine duoc viet boi HuyetSat - Xvna.forumb.biz
/// Moi cap nhat hay thac mac ý kien ve engine xin liên he tai: xvna.forumb.biz hoac thanh_vinh648@yahoo.com
/// Engine hoàn toàn free và nó cho phép các ban phát trien RPG mot cách de dàng!
/// Yeu cau ghi ro~ nguon goc engine va tac gia khi ban phat trien game ca nhan bang engine nay!
/// Chân thành cam on ban dã quan tâm su dung engine này!
///
namespace XNA_RPG_textMapEditor
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class RPG : Microsoft.Xna.Framework.Game
    {
        
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Input input = new Input();
        int activeMap = 0;
        List<String> MapPaths = new List<string>();
        //Scene
        ActionScene1 scene;
        StartScene start;
        GameScene activeScene;
        //audio
        AudioManager audio;
        public RPG()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            graphics.IsFullScreen = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            audio = new AudioManager(this);
            //services
            Services.AddService(typeof(SpriteBatch), spriteBatch);
            Services.AddService(typeof(Input), input);
            Services.AddService(typeof(AudioManager), audio);
            Services.AddService(typeof(Vector2), new Vector2(0,0));
            //load map
            MapPaths.Add("map1.map");
            MapPaths.Add("map2.map");
            MapPaths.Add("map3.map");
            MapPaths.Add("map4.map");
            MapPaths.Add("map5.map");
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            
            scene = new ActionScene1(this, Content.Load<Texture2D>("BG"), MapPaths[activeMap]);
            start = new StartScene(this, Content.Load<Texture2D>("BG"));
            //add cac man` cua game
            Components.Add(start);
            Components.Add(scene);
            //thiet lap man dau` tien hien thi
            activeScene = start;
            start.Show();
            
            //play sound
            MediaPlayer.Play(audio.BackSound);
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
        // method chuyen man`
        private void ShowScene(GameScene scene)
        {
            activeScene.Hide();
            activeScene = scene;
            scene.Show();
        }
        TimeSpan time;
        protected override void Update(GameTime gameTime)
        {
            time += gameTime.ElapsedGameTime;
            if (time > TimeSpan.FromMinutes(2))
            {
                time -= TimeSpan.FromMinutes(2);
                MediaPlayer.Play(audio.BackSound);
            }

            input.Update();
            //controlling menu
            if (start.Enabled && start.Next)
                ShowScene(scene);
            //paue and resume game when playing
            if ((!scene.Next||!scene.Die)&&scene.Enabled && input.Release(Keys.Space))
            {
                scene.Pause();
            }
            else if (!scene.Enabled && input.Release(Keys.Space))
            {
                scene.Resume();
            }
            //Neu player chet:
            if (scene.Enabled && scene.Die)
            {
                scene.Pause();
                if (input.Release(Keys.Space))
                {
                    scene.Hide();
                    Components.Remove(scene);
                    scene = new ActionScene1(this, Content.Load<Texture2D>("BG"), MapPaths[activeMap]);
                    Components.Add(scene);
                    ShowScene(scene);
                }
            }
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
            //KT viec chuyen man`
            if (scene.Next)
            {
                scene.Pause();
                if(input.Release(Keys.Space))
                    {
                scene.Next = false;
                activeMap++;
                scene.Hide();
                Components.Remove(scene);
                if (activeMap >= 5)
                    activeMap = 0;
                scene = new ActionScene1(this, Content.Load<Texture2D>("BG"), MapPaths[activeMap]);
                scene.Show();
                Components.Add(scene);
                    }
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            float cameraPositionX = -scene.Level.Player.Position.X+400;
            float cameraPositionY = -scene.Level.Player.Position.Y+300;
            cameraPositionX = MathHelper.Clamp(cameraPositionX, -800, 0);
            cameraPositionY = MathHelper.Clamp(cameraPositionY, -800, 0);
            Services.RemoveService(typeof(Vector2));
            Services.AddService(typeof(Vector2), new Vector2(cameraPositionX, cameraPositionY));
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //draw bg
            spriteBatch.Begin();
            spriteBatch.Draw(Content.Load<Texture2D>("BG"),Vector2.Zero,Color.White);
            spriteBatch.End();
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Deferred, SaveStateMode.None, Matrix.CreateTranslation(cameraPositionX,cameraPositionY , 0f));
            //draw tat ca game compoments
            base.Draw(gameTime);
            
            spriteBatch.End();
        }
       
    }
}
