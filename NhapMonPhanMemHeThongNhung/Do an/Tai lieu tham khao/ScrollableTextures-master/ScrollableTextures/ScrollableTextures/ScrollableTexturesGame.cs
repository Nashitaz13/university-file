namespace ScrollableTextures
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class ScrollableTexturesGame : Game
    {
        private SpriteBatch _spriteBatch;

        // Background texture
        private Texture2D _bg;

        // First cloud layer
        Texture2D _layer1;
        private float _scrollX1;
        private float _scrollY1;

        // Second cloud layer
        Texture2D _layer2;
        private float _scrollX2;
        private float _scrollY2;

        public ScrollableTexturesGame()
        {
            new GraphicsDeviceManager(this) { PreferredBackBufferWidth = 960, PreferredBackBufferHeight = 640 };
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _bg = Content.Load<Texture2D>("bg");
            _layer1 = Content.Load<Texture2D>("layer1");
            _layer2 = Content.Load<Texture2D>("layer2");
        }

        protected override void Update(GameTime gameTime)
        {
            // Scroll layer 1
            _scrollX1 += 0.5f;
            _scrollY1 += 0.5f;
            
            // Scroll layer 2
            _scrollX2 += 1.0f;
            _scrollY2 += 0.8f;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap /* Must be set to Wrap */, null, null);
            // Draw the background
            _spriteBatch.Draw(_bg, Vector2.Zero, Color.White);
            // Draw the scrolling layers
            _spriteBatch.Draw(_layer1, Vector2.Zero, new Rectangle((int)(-_scrollX1), (int)(-_scrollY1), _layer1.Width, _layer1.Height), Color.White);
            _spriteBatch.Draw(_layer2, Vector2.Zero, new Rectangle((int)(-_scrollX2), (int)(-_scrollY2), _layer2.Width, _layer2.Height), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        static void Main()
        {
            using (ScrollableTexturesGame game = new ScrollableTexturesGame())
            {
                game.Run();
            }
        }
    }
}
