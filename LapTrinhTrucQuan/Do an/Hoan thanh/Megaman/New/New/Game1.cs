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

namespace New
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Screens
        ScreenManager screenManager;
        ScreenFactory screenFactory;

        SpriteFont font;
        KeyboardState cur, old;

        //Map
        Map map;
        Background background;
        Camera camera;

        Player player;

        //Enemys
        EnemyPatrol enemyPatrol;
        EnemyPatrol2 enemyPatrol2;
        EnemyCannon enemyCannon;
        Texture2D enemyTexture;
        Texture2D enemyTexture2;
        Texture2D cannonTexture;
        int d = 0;

        //Bullets
        List<Bullets> bullets = new List<Bullets>();
        List<BulletsCannon> bulletsCannon = new List<BulletsCannon>();

        //Music
        SoundEffect ShootEffect;
        Song Theme;

        //Health Bar
        Texture2D healthbarTexture;
        Rectangle healthbarRectangle;
        Texture2D healthTexture;
        Rectangle healthRectangle;
        //Cannon Health
        Texture2D chealthTexture;
        Rectangle chealthRectangle;

        //Platform
        Platform platform;
        Texture2D platformTexture;

        //Trap
        Rectangle trapRectangle = new Rectangle(1755, 327, 242, 30);
        Rectangle trap2Rectangle = new Rectangle(2565, 50, 540, 25);
        Rectangle trap3Rectangle = new Rectangle(4260, 388, 300, 30);

        //Save
        Texture2D saveTexture;
        Rectangle saveRectangle;
        bool isSaved;

        //Blood
        Texture2D bloodTexture;
        Rectangle bloodRectangle;
        bool smallBlood;
        Texture2D blood2Texture;
        Rectangle blood2Rectangle;
        bool bigBlood;

        //Gameover
        Texture2D gameoverTexture;
        Rectangle gameoverRectangle;
        bool GameOver;

        //key
        Texture2D keyTexture;
        Rectangle keyRectangle;
        bool key;

        //Win
        Texture2D winTexture;
        Rectangle winRectangle;
        bool isWin;

        //Pause
        bool paused = false;
        Texture2D pauseTexture;
        Rectangle pauseRectangle;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 480;
            graphics.PreferredBackBufferWidth = 800;
            Content.RootDirectory = "Content";

            // Create the screen factory and add it to the Services
            screenFactory = new ScreenFactory();
            Services.AddService(typeof(IScreenFactory), screenFactory);

            // Create the screen manager component.
            screenManager = new ScreenManager(this);
            Components.Add(screenManager);
            // On Windows and Xbox we just add the initial screens
            AddInitialScreens();
        }

        private void AddInitialScreens()
        {
            // Activate the first screens.
            screenManager.AddScreen(new BackgroundScreen(), null);

            // We have different menus for Windows Phone to take advantage of the touch interface
            screenManager.AddScreen(new MainMenuScreen(), null);
        }

        protected override void Initialize()
        {
            map = new Map();
            player = new Player();
            background = new Background();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Tiles.Content = Content;

            font = Content.Load<SpriteFont>("Font/SpriteFont1");

            camera = new Camera(GraphicsDevice.Viewport);

            map.Generate(new int[,]{
                {1,11,11,11,9,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,17,17,17,17,17,17,12,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,0,0,0,0,0,0,18,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,1,1,1},
                {1,11,11,9,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,18,0,0,18,0,18,18,18,0,18,18,18,0,0,0,0,0,0,0,0,0,0,4,17,17,17,17,17,17,12,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21,21,0,0,0,0,0,18,18,18,0,0,0,0,0,0,0,0,0,0,0,14,14,14,14,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,6,6,6,6,6,6,6,6,6,6,6,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,16,16,16,16,16,16,16,16,16,0,0,0,0,0,0,0,0,3,1,1},
                {1,11,9,0,0,0,0,0,0,0,0,0,0,0,0,0,1,18,18,18,1,0,0,18,0,0,18,0,0,18,0,0,0,18,0,0,0,0,0,0,0,0,0,0,0,4,17,17,17,17,17,17,12,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,18,18,18,18,18,0,0,0,0,0,0,0,0,0,0,14,14,14,14,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,6,6,6,6,6,6,6,6,6,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,0,0,0,0,0,0,0,0,0,3,1},
                {1,9,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,18,1,18,0,1,0,18,0,0,18,0,0,18,0,0,0,18,0,0,0,0,0,0,0,0,0,0,0,4,14,14,14,14,14,14,12,0,0,0,0,0,0,0,0,0,0,0,0,0,3,11,11,11,11,11,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,18,18,18,0,0,0,0,0,0,0,0,0,0,0,14,14,14,14,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,6,6,6,6,6,6,6,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,18,18,18,1,0,0,18,18,18,18,0,18,18,18,0,0,18,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,5,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,18,0,0,0,0,0,0,0,0,0,0,0,0,16,16,16,16,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,6,6,6,6,6,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,3,5,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,16,16,16,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,6,6,6,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,5,5,5,5,3,14,14,14,14,14,14,0,0,11,11,11,11,11,11,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,6,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,14,6,6,6,6,14,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,11,0,0,0,0,0,0,0,0,0,0,3,1},
                {1,10,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,1,1,1,1,1,1,1,1,1,1,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,14,6,6,6,6,14,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,1,9,0,0,0,0,0,0,0,0,3,2,1},
                {1,9,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,10,17,17,10,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,16,16,16,16,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,14,6,6,6,6,14,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,1,0,1,9,0,0,0,0,0,0,3,2,2,1},
                {1,9,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,2,10,17,17,10,2,0,0,0,0,0,0,3,9,0,0,0,0,0,0,0,0,2,0,0,0,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,14,6,6,6,6,14,0,0,0,0,0,0,0,0,0,0,11,11,11,11,11,11,0,0,0,0,0,0,7,13,5,5,5,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,1,1,1,0,9,0,0,0,0,3,2,2,2,1},
                {1,5,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,17,17,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,19,19,19,19,19,19,19,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,14,6,6,6,6,14,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13,0,0,0,9,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,2,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,16,16,16,16,16,16,16,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,14,6,6,6,6,14,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13,0,0,0,0,9,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,16,16,16,16,16,16,16,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,14,6,6,6,6,14,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,22,22,22,22,22,22,22,22,22,22,6,6,6,0,0,6,6,6,0,0,6,6,6,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,17,17,17,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            }, 30);

            player.Load(Content);

            //Save
            saveTexture = Content.Load<Texture2D>("Items/SaveFlag");
            saveRectangle = new Rectangle(4730, 340, saveTexture.Width, saveTexture.Height);
            isSaved = false;

            //Blood
            bloodTexture = Content.Load<Texture2D>("Items/Blood1");
            bloodRectangle = new Rectangle(3452, 228, bloodTexture.Width, bloodTexture.Height);
            smallBlood = true;

            blood2Texture = Content.Load<Texture2D>("Items/Blood2");
            blood2Rectangle = new Rectangle(5705, 179, blood2Texture.Width, blood2Texture.Height);
            bigBlood = true;

            //Game Over
            gameoverTexture = Content.Load<Texture2D>("Background/GameOver");
            GameOver = false;

            //key
            keyTexture = Content.Load<Texture2D>("Items/Key");
            keyRectangle = new Rectangle(5880, 160, keyTexture.Width, keyTexture.Height);
            key = true;

            //Platform
            platformTexture = Content.Load<Texture2D>("Map/Platform");
            platform = new Platform(platformTexture);

            //Win
            winTexture = Content.Load<Texture2D>("Background/Win");
            isWin = false;

            //Enemys
            enemyTexture = Content.Load<Texture2D>("Enemy/Enemy1");
            enemyPatrol = new EnemyPatrol(enemyTexture);
            enemyTexture2 = Content.Load<Texture2D>("Enemy/Enemy2");
            enemyPatrol2 = new EnemyPatrol2(enemyTexture2);
            cannonTexture = Content.Load<Texture2D>("Enemy/EnemyCannon");
            enemyCannon = new EnemyCannon(cannonTexture);

            //Background
            background.LoadContent(Content);

            //Music
            ShootEffect = Content.Load<SoundEffect>("Sounds/ShootEffect");
            Theme = Content.Load<Song>("Sounds/Theme");
            MediaPlayer.Play(Theme);

            //Health
            healthbarTexture = Content.Load<Texture2D>("Others/HealthBar");
            healthTexture = Content.Load<Texture2D>("Others/Health");
            chealthTexture = Content.Load<Texture2D>("Others/CannonHealth");

            //Pause
            pauseTexture = Content.Load<Texture2D>("Others/Pause");
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {   
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //Pause
            if (!paused)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    paused = true;
                }
                player.Update(gameTime);
                enemyPatrol.Update();
                enemyPatrol2.Update();
                enemyCannon.Update();
                platform.Update();
                UpdateBullets();
                UpdateBulletsCannon();

                //Shoot
                if (Keyboard.GetState().IsKeyDown(Keys.C) && old.IsKeyUp(Keys.C))
                {
                    Shoot();
                    ShootEffect.Play();
                }
                old = Keyboard.GetState();
                
                //Enemy Patrol 1
                if (player.rectangle.Intersects(enemyPatrol.rectangle))
                {
                    player.beInjured = true;
                    player.health -= 1;
                }
                foreach (Bullets bullet in bullets)
                {
                    if (bullet.rectangle.Intersects(enemyPatrol.rectangle))
                    {
                        bullet.isVisible = false;
                        enemyPatrol.health -= 1;
                    }
                    if (enemyPatrol.health == 0)
                        enemyPatrol.isVisible = false;
                }

                //Enemy Patrol 2
                if (player.rectangle.Intersects(enemyPatrol2.rectangle))
                {
                    player.beInjured = true;
                    player.health -= 1;
                }
                foreach (Bullets bullet in bullets)
                {
                    if (bullet.rectangle.Intersects(enemyPatrol2.rectangle))
                    {
                        enemyPatrol2.health -= 1;
                        bullet.isVisible = false;
                    }
                    if(enemyPatrol2.health == 0)
                        enemyPatrol2.isVisible = false;
                }

                //Enemy Cannon
                if (player.rectangle.Intersects(enemyCannon.rectangle))
                {
                    player.beInjured = true;
                    player.health -= 1;
                }
                foreach (BulletsCannon b in bulletsCannon)
                {
                    if (player.rectangle.Intersects(b.rectangle))
                    {
                        player.beInjured = true;
                        player.health -= 15;
                        b.isVisible = false;
                    }
                }
                foreach (Bullets bullet in bullets)
                {
                    if (bullet.rectangle.Intersects(enemyCannon.rectangle))
                    {
                        enemyCannon.health -= 5;
                        bullet.isVisible = false;
                    }
                    if (enemyCannon.health == 0)
                        enemyCannon.isVisible = false;
                }
                if (player.health <= 0)
                    enemyCannon.health = 50;
                if (enemyCannon.isVisible)
                {
                    if (enemyCannon.bulletDelay > 0)
                        enemyCannon.bulletDelay--;
                    if (enemyCannon.bulletDelay == 0)
                    {
                        EnemyShoot();
                        enemyCannon.bulletDelay = 20;
                        d++;
                    }
                }

                //Trap
                if (player.rectangle.Intersects(trapRectangle))
                {
                    player.beInjured = true;
                    player.health -= 3;
                }
                if (player.rectangle.Intersects(trap2Rectangle))
                {
                    player.beInjured = true;
                    player.health -= 3;
                }
                if (player.rectangle.Intersects(trap3Rectangle))
                {
                    player.beInjured = true;
                    player.health -= 3;
                }

                //Quit
                if (Keyboard.GetState().IsKeyDown(Keys.Q))
                    this.Exit();

                // Die
                if (player.health <= 0 && player.life > 0)
                {
                    if(isSaved)
                        player.position = new Vector2(4730, 200);
                    else
                        player.position = new Vector2(100, 100);
                    player.life -= 1;
                    if(player.life > 0)
                        player.health = 147;
                }
                if (player.position.Y >= 444)
                    player.health = 0;

                //Gameover
                if (player.life == 0)
                {
                    MediaPlayer.Stop();
                    GameOver = true;
                }

                //Win
                if(player.rectangle.Intersects(keyRectangle) && enemyCannon.isVisible == false)
                {
                    key = false;
                    isWin = true;
                }

                //Collision Map
                foreach (CollisionTiles tile in map.CollisionTiles)
                {
                    foreach (Bullets bullet in bullets)
                        bullet.Collision(tile.Rectangle, map.Width, map.Height);    
                    player.Collision(tile.Rectangle, map.Width, map.Height);
                    camera.Update(player.Position, map.Width, map.Height);
                }
                player.Collision(platform.rectangle, map.Width, map.Height);
                if(player.rectangle.Intersects(platform.rectangle))
                    player.velocity.Y = -1f;

                //Health Bar
                healthbarRectangle = new Rectangle((int)camera.centre.X - 378, (int)camera.centre.Y - 207, healthbarTexture.Width, healthbarTexture.Height);
                healthRectangle = new Rectangle((int)camera.centre.X - 350,(int)camera.centre.Y - 200, player.health, healthTexture.Height);
                chealthRectangle = new Rectangle(5560, 290, enemyCannon.health, chealthTexture.Height);

                //Pause
                pauseRectangle = new Rectangle((int)camera.centre.X - pauseTexture.Width / 2, (int)camera.centre.Y - pauseTexture.Height / 2, pauseTexture.Width, pauseTexture.Height);

                //Game Over
                gameoverRectangle = new Rectangle((int)camera.centre.X - camera.viewport.Width/2, (int)camera.centre.Y - camera.viewport.Height/2, gameoverTexture.Width, gameoverTexture.Height);
                
                //Win
                winRectangle = new Rectangle((int)camera.centre.X - winTexture.Width / 2, (int)camera.centre.Y - winTexture.Height / 2, winTexture.Width, winTexture.Height);

                //Save
                if(player.rectangle.Intersects(saveRectangle))
                    isSaved = true;

                //Blood
                if (smallBlood)
                {
                    if (player.rectangle.Intersects(bloodRectangle))
                    {
                        if (player.health + 50 > 147)
                        {
                            while (player.health < 147)
                                player.health += 1;
                        }
                        else
                            player.health += 50;
                        smallBlood = false;
                    }
                }
                if (bigBlood)
                {
                    if (player.rectangle.Intersects(blood2Rectangle))
                    {
                        while (player.health < 147)
                            player.health += 1;
                        bigBlood = false;
                    }
                }
            }
            else
                if (paused)
                {
                    player.health -= 0;
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                        paused = false;
                }
            base.Update(gameTime);
        }

        public void UpdateBullets()
        {
            foreach (Bullets bullet in bullets)
            {
                bullet.position += bullet.velocity;
                bullet.rectangle = new Rectangle((int)bullet.position.X, (int)bullet.position.Y, bullet.texture.Width, bullet.texture.Height);
                if (Vector2.Distance(bullet.position, player.position) > 300)
                    bullet.isVisible = false;
            }
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].isVisible)
                    bullets.RemoveAt(i);
            }
        }

        public void Shoot()
        {
            Bullets newBullet = new Bullets(Content.Load<Texture2D>("Others/Bullet"));

            if (player.spriteEffects == SpriteEffects.None)
            {
                newBullet.velocity.X = 5f;
                newBullet.position.X = player.position.X + 18 + newBullet.velocity.X;
            }
            if (player.spriteEffects == SpriteEffects.FlipHorizontally)
            {
                newBullet.velocity.X = -5f;
                newBullet.position.X = player.position.X - 18 + newBullet.velocity.X;
            }
            if ((cur.IsKeyDown(Keys.X) && cur.IsKeyDown(Keys.C) && cur.IsKeyDown(Keys.Right))
                || (cur.IsKeyDown(Keys.X) && cur.IsKeyDown(Keys.C) && cur.IsKeyDown(Keys.Left))
                || (cur.IsKeyDown(Keys.X) && cur.IsKeyDown(Keys.C)))
            {
                if (player.spriteEffects == SpriteEffects.None)
                {
                    newBullet.position.X = player.position.X + 15 + newBullet.velocity.X;
                }
                if (player.spriteEffects == SpriteEffects.FlipHorizontally)
                {
                    newBullet.position.X = player.position.X - 15 + newBullet.velocity.X;
                }
                newBullet.position.Y = player.position.Y - 20 + newBullet.velocity.Y;
            }
            newBullet.position.Y = player.position.Y - 23 + newBullet.velocity.Y;
            newBullet.isVisible = true;

            if (bullets.Count() < 4)
                bullets.Add(newBullet);
        }

        public void UpdateBulletsCannon()
        {
            foreach (BulletsCannon b in bulletsCannon)
            {
                b.position -= b.velocity;
                b.rectangle = new Rectangle((int)b.position.X, (int)b.position.Y, b.texture.Width, b.texture.Height);
                if (Vector2.Distance(b.position, enemyCannon.position) > 600)
                    b.isVisible = false;
            }
            for (int i = 0; i < bulletsCannon.Count; i++)
            {
                if (!bulletsCannon[i].isVisible)
                    bulletsCannon.RemoveAt(i);
            }
        }

        public void EnemyShoot()
        {
            BulletsCannon newBulletC = new BulletsCannon(Content.Load<Texture2D>("Others/BulletCannon"));
            newBulletC.velocity.X = 5f;
            newBulletC.position.X = enemyCannon.position.X - newBulletC.velocity.X;
            newBulletC.position.Y = enemyCannon.position.Y + newBulletC.velocity.Y + 5;
            newBulletC.isVisible = true;

            if (bulletsCannon.Count() < 5)
                bulletsCannon.Add(newBulletC);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice device = graphics.GraphicsDevice;

            spriteBatch.Begin(SpriteSortMode.Deferred,
                                BlendState.AlphaBlend,
                                null, null, null, null,
                                camera.Transform);

            background.Draw(spriteBatch);
            map.Draw(spriteBatch);
            platform.Draw(spriteBatch);

            foreach (BulletsCannon b in bulletsCannon)
                b.Draw(spriteBatch);
            foreach (Bullets bullet in bullets)
                bullet.Draw(spriteBatch);

            if (enemyPatrol.isVisible)
                enemyPatrol.Draw(spriteBatch);
            if (enemyPatrol2.isVisible)
                enemyPatrol2.Draw(spriteBatch);
            enemyCannon.Draw(spriteBatch);

            if (key)
                spriteBatch.Draw(keyTexture, keyRectangle, Color.White);

            if (!isSaved)
                spriteBatch.Draw(saveTexture, saveRectangle, Color.White);
            if (smallBlood)
                spriteBatch.Draw(bloodTexture, bloodRectangle, Color.White);
            if (bigBlood)
                spriteBatch.Draw(blood2Texture, blood2Rectangle, Color.White);
            if (player.health > 0 && player.life > 0)
                player.Draw(gameTime, spriteBatch);

            spriteBatch.Draw(healthTexture, healthRectangle, Color.White);
            spriteBatch.Draw(healthbarTexture, healthbarRectangle, Color.White);
            spriteBatch.Draw(chealthTexture, chealthRectangle, Color.White);

            spriteBatch.DrawString(font, Convert.ToString(player.life), new Vector2((int)camera.centre.X - 366, (int)camera.centre.Y - 205), Color.White);

            if (paused)
            {
                spriteBatch.Draw(pauseTexture, pauseRectangle, Color.White);
                spriteBatch.DrawString(font, "Press Enter to countinue!", new Vector2((int)camera.centre.X - pauseTexture.Width / 2 - 50, (int)camera.centre.Y - pauseTexture.Height / 2 + 50), Color.Black);
            }

            if (isWin)
                spriteBatch.Draw(winTexture, winRectangle, Color.White);
            if (GameOver)
                spriteBatch.Draw(gameoverTexture, gameoverRectangle, Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
