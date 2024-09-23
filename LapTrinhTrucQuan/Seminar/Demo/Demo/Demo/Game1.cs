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

namespace Demo
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpriteEffects spriteEffects;

        Texture2D texture;
        Rectangle rectangle;
        Rectangle playerRectangle;

        Texture2D kbTexture;
        Rectangle kbRectangle;
        int x, y;

        Texture2D backgroundTexture;

        Texture2D winTexture;
        Rectangle winRectangle;
        bool win;

        Vector2 position;
        Vector2 origin = Vector2.Zero;

        int curFrame; // Khung hình hiện tại
        int curFrameY; // Tọa độ Y của khung hình hiện tại
        int frameWidth; //Chiều rộng khung hình
        int frameHeight; // Chiều dài khung hình
        int numFrame; // Số lượng khung hình
        float timer;
        const float frameDelay = 100;

        bool isfound;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 700;
            graphics.PreferredBackBufferWidth = 1200;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            texture = Content.Load<Texture2D>("Demo");

            backgroundTexture = Content.Load<Texture2D>("BackgrounDemo");

            kbTexture = Content.Load<Texture2D>("Treasure");
            Random r = new Random();
            x = r.Next(0, 1200 - kbTexture.Width);
            y = r.Next(0, 700 - kbTexture.Height);
            kbRectangle = new Rectangle(x, y, kbTexture.Width, kbTexture.Height);
            isfound = true;

            winTexture = Content.Load<Texture2D>("win");
            winRectangle = new Rectangle(500, 300, winTexture.Width, winTexture.Height);
            win = false;

            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (!win)
            {
                frameWidth = texture.Width / 5;
                frameHeight = texture.Height / 3;
                numFrame = 5;
                timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (timer > frameDelay)
                {
                    curFrame++;
                    if (curFrame > numFrame - 1)
                        curFrame = 0;
                    rectangle = new Rectangle(curFrame * frameWidth, curFrameY, frameWidth, frameHeight);
                    timer = 0;
                }
                playerRectangle = new Rectangle((int)position.X, (int)position.Y, frameWidth, frameHeight);
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    curFrameY = 0;
                    spriteEffects = SpriteEffects.None;
                    position.X += 3;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    curFrameY = 0;
                    spriteEffects = SpriteEffects.FlipHorizontally;
                    position.X -= 3;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    curFrameY = frameHeight;
                    position.Y += 3;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    curFrameY = 2 * frameHeight;
                    position.Y -= 3;
                }
            }
                if (playerRectangle.Intersects(kbRectangle))
                    isfound = false;
                if (playerRectangle.Intersects(kbRectangle))
                    win = true;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, backgroundTexture.Width, backgroundTexture.Height), Color.White);
            if(isfound)
                spriteBatch.Draw(kbTexture, kbRectangle, Color.White);
            spriteBatch.Draw(texture, position, rectangle, Color.White, 0f, origin, 1f, spriteEffects, 0);
            if (win)
                spriteBatch.Draw(winTexture, winRectangle, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
