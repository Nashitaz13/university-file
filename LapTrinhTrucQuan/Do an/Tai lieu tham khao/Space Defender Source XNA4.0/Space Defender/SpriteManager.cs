using System;
using System.Collections.Generic;
using System.IO;
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
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class SpriteManager : Microsoft.Xna.Framework.DrawableGameComponent
    {        
        SpriteBatch spriteBatch;
        Rectangle window;

        bool paused = false;
        GameTime pausedGameTime;
        int pauseDelay = 0;

        AudioEngine audioEngine;
        WaveBank waveBank;
        SoundBank soundBank;

        TimeSpan totalTimePlayed = TimeSpan.Zero;

        GameState gameState = GameState.MainMenu; // We use a switch statement in both Update,Draw methods
        Difficulty difficulty=Difficulty.Medium;

        ControlMethod controlMethod = ControlMethod.Mouse; // Player can play using mouse ot keyboard
        StatusPanel statusPanel; // Displays missiles/health/engine status
        ScorePanel scorePanel; // Displays player score

        Player player;

        HealthKit healthKit;
        float iTimeTillNextHealth = 60000;
        float timeTillNextHealth = 60000;

        bool lockedOnTarget = false;
        Cursor cursor;
        Cursor sniper;

        SpriteFont font;

        ExplosionManager explosionManager; // Handles all explosion in the game
        EnemyManager enemyManager;  // Spawns enemies & updates\draws them
        CloudManager cloudManagerBack;
        CloudManager cloudManagerFront;

        // // Sprite sheets
        // / Space ships
        Texture2D notAvailableTex;
        Texture2D rapidFireShipTex;
        Texture2D turboShipTex;
        Texture2D armoredShipTex;
        Texture2D superShipTex;
        Texture2D playerTex;

        // / Player weapons
        Texture2D bulletTex;
        Texture2D missileTex;

        // / Enemies' space ships & weapons
        Texture2D smokeTex;
        Texture2D motherShipTex;
        Texture2D pulseTex;
        Texture2D droneTex;

        Texture2D finalBossTex;
        Texture2D boltTex;
        Texture2D pulseCannonTex;
        Texture2D boltCannonTex;
        Texture2D defendersPlatformTex;

        Texture2D invaderTex;

        Texture2D explosionTex;

        Texture2D healthKitTex;

        // / Mouse cursors
        Texture2D cursorTex;
        Texture2D sniperTex;

        // / Status panel
        Texture2D panelTex;
        Texture2D missileGaugeTex;
        Texture2D lifeGaugeTex;
        Texture2D scorePanelTex;

        // / Menus & others
        Texture2D backGroundTex;
        Texture2D logoTex;
        Label copyRight;
        Texture2D selectShipBGTex;
        Texture2D winningBGTex;
        Texture2D howToPlayTex;
        Texture2D aboutTex;
        Texture2D addictionTex;

        // / Buttons
        Texture2D buttonTex;
        Texture2D mouseTex;
        Texture2D keyboardTex;

        Texture2D pausedTex;

        // // Dialogs
        MainMenu mainMenu;
        HowToPlay howToPlay;
        SelectDifficulty selectDifficulty;
        WinningScreen winningScreen;
        GameOverScreen gameOverScreen;
        About about;

        // / Animations to show in the ship selection dialog
        string shipIndex = "bjus6e"; // To add to the config file (save used ships)
        Animation rapidFireShip;
        Animation turboShip;
        Animation armoredShip;
        Animation superShip;
        Animation superShipNotAvailable;
        bool superShipAvailable = false; // Super ship will be available after player finishes the game with two different ships

        // / Two buttons to show in the prefered control selection dialog
        Button keyboard;
        Button mouse;

        Button btnBack;

        // / Default ship properties
        float health;
        int bulletFireDelay;
        float maxEngineTorque;

        public SpriteManager(Game game)
            : base(game)
        {             
            // TODO: Construct any child components here
        }

        protected override void LoadContent()
        {
            ResetGame();
            audioEngine = new AudioEngine(@"Content\Audio\Audio.xgs");
            waveBank = new WaveBank(audioEngine, @"Content\Audio\Wave Bank.xwb");
            soundBank = new SoundBank(audioEngine, @"Content\Audio\Sound Bank.xsb");

            soundBank.PlayCue("Splash");
            
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            notAvailableTex = Game.Content.Load<Texture2D>(@"Images\SpaceDefenders\NotAvailable");
            rapidFireShipTex = Game.Content.Load<Texture2D>(@"Images\SpaceDefenders\RapidFireShip");
            turboShipTex = Game.Content.Load<Texture2D>(@"Images\SpaceDefenders\TurboShip");
            armoredShipTex = Game.Content.Load<Texture2D>(@"Images\SpaceDefenders\ArmoredShip");
            superShipTex = Game.Content.Load<Texture2D>(@"Images\SpaceDefenders\SuperShip");

            smokeTex  = Game.Content.Load<Texture2D>(@"Images\Smoke");

            bulletTex = Game.Content.Load<Texture2D>(@"Images\SpaceDefenders\Weapons\Bullet");
            missileTex = Game.Content.Load<Texture2D>(@"Images\SpaceDefenders\Weapons\Missile");
            healthKitTex = Game.Content.Load<Texture2D>(@"Images\Items\Health");

            cursorTex = Game.Content.Load<Texture2D>(@"Images\Cursors\Cursor");
            sniperTex = Game.Content.Load<Texture2D>(@"Images\Cursors\Sniper");

            explosionTex = Game.Content.Load<Texture2D>(@"Images\Effects\Explosion");
            invaderTex = Game.Content.Load<Texture2D>(@"Images\Enemies\Invader");
            motherShipTex = Game.Content.Load<Texture2D>(@"Images\Enemies\MotherShip");
            finalBossTex = Game.Content.Load<Texture2D>(@"Images\Enemies\FinalBoss");
            boltCannonTex = Game.Content.Load<Texture2D>(@"Images\Enemies\Weapons\BoltCannon");
            pulseCannonTex = Game.Content.Load<Texture2D>(@"Images\Enemies\Weapons\PulseCannon");
            droneTex = Game.Content.Load<Texture2D>(@"Images\Enemies\Drone");
            pulseTex = Game.Content.Load<Texture2D>(@"Images\Enemies\Weapons\Pulse");
            boltTex = Game.Content.Load<Texture2D>(@"Images\Enemies\Weapons\Bolt");
            defendersPlatformTex = Game.Content.Load<Texture2D>(@"Images\Enemies\Weapons\DefendersPlatform");

            scorePanelTex = Game.Content.Load<Texture2D>(@"Images\Panel\ScorePanel");
            panelTex = Game.Content.Load<Texture2D>(@"Images\Panel\Panel");
            missileGaugeTex = Game.Content.Load<Texture2D>(@"Images\Panel\MissileGauge");
            lifeGaugeTex = Game.Content.Load<Texture2D>(@"Images\Panel\LifeGauge");

            buttonTex = Game.Content.Load<Texture2D>(@"Images\Menus\Button");
            mouseTex = Game.Content.Load<Texture2D>(@"Images\Menus\Mouse");
            keyboardTex = Game.Content.Load<Texture2D>(@"Images\Menus\Keyboard");

            backGroundTex = Game.Content.Load<Texture2D>(@"Images\BackGround");
            logoTex = Game.Content.Load<Texture2D>(@"Images\Logo");
            selectShipBGTex = Game.Content.Load<Texture2D>(@"Images\SelectShipBG");
            winningBGTex = Game.Content.Load<Texture2D>(@"Images\WinningBG");
            howToPlayTex = Game.Content.Load<Texture2D>(@"Images\Menus\HowToPlay");
            aboutTex = Game.Content.Load<Texture2D>(@"Images\Menus\About");
            addictionTex = Game.Content.Load<Texture2D>(@"Images\Menus\Addiction");

            pausedTex = Game.Content.Load<Texture2D>(@"Images\Paused");

            font = Game.Content.Load<SpriteFont>(@"Fonts\Arial");

            copyRight=new Label(font,new Vector2(10,window.Height-40),"Programmed by Ghoshehsoft");

            // Creating menus & dialogs
            mainMenu = new MainMenu(buttonTex, font,Color.Snow, window,soundBank);
            selectDifficulty = new SelectDifficulty(backGroundTex,buttonTex, font, window, soundBank);
            howToPlay = new HowToPlay(howToPlayTex, WallpaperType.Centered, buttonTex, font, Color.DarkGray, window,soundBank);

            about = new About(aboutTex, buttonTex, font, Color.DarkGray, window,soundBank);
            about.AddAnimation(new Animation(addictionTex, new Point(3, 1), WindowCenter + new Vector2(aboutTex.Width / 3f, 0), 300, false, font, "", window));

            gameOverScreen = new GameOverScreen(buttonTex, font, Color.Snow, window,soundBank);
            // Winning screen isn't created here becuase it needs to know player info,so it'll be created after the game is finished



            // (Select Ship) dialog elements
            float w = window.Width / 5.5f;
            float h = window.Height / 5.5f;
            Vector2 v = new Vector2(w - 50, h);

            rapidFireShip = new Animation(rapidFireShipTex, new Point(4, 1), 1 * v, 20, true, font, "Rapid fire ship: has extra fire rate", window);
            turboShip = new Animation(turboShipTex, new Point(4, 1), 2 * v, 20, true, font, "Turbo ship: has extra moving speed", window);
            armoredShip = new Animation(armoredShipTex, new Point(4, 1), 3 * v, 20, true, font, "Armored ship: has extra hit points", window);
            superShip = new Animation(superShipTex, new Point(4, 1), 4 * v, 20, true, font, "Super ship: the ultimate ship!!", window);
            superShipNotAvailable = new Animation(notAvailableTex, new Point(1, 1), 4 * v, 20, false, font, "????????????????????????????", window);

            // (Select Control) dialog components
            mouse = new Button(mouseTex, "", font,Color.Snow, new Vector2(window.Width / 4, window.Height / 2),soundBank);
            keyboard = new Button(keyboardTex, "", font,Color.Snow, new Vector2(2.5f * window.Width / 4, window.Height / 2),soundBank);

            btnBack = new Button(buttonTex, "Back", font, Color.Snow, new Vector2(buttonTex.Width / 2f + buttonTex.Height / 3f, window.Height - buttonTex.Height / 3f),soundBank);

            scorePanel = new ScorePanel(scorePanelTex, font, 10);

            // Cursors
            cursor = new Cursor(cursorTex, new Point(12, 1));
            sniper = new Cursor(sniperTex, new Point(20, 1));


            explosionManager = new ExplosionManager(explosionTex);
            cloudManagerBack = new CloudManager(smokeTex, 3000,4323, window);
            cloudManagerFront = new CloudManager(smokeTex, 3000,2397 ,window);
            //enemy manager takes player parameter so it won't be created here

            base.LoadContent();
        }

        /// <summary>
        /// Checks whether to unlock the ultimate ship depending on the file "config.ini"
        /// </summary>
        protected void UpdateConfigFile()
        {
            try
            {
                File.AppendAllText(@"config.ini", shipIndex);

                string config = File.ReadAllText(@"config.ini");

                int i = 0;
                if (config.Contains("webljb")) ++i;
                if (config.Contains("vweub3")) ++i;
                if (config.Contains("vh5424")) ++i;

                if (i >= 2) superShipAvailable = true;
            }
            catch (Exception)
            {
                // I don't want any error messages in my game!
            }
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            if (File.Exists(@"config.ini"))
            {
                string config = File.ReadAllText(@"config.ini");
                int i = 0;
                if (config.Contains("webljb")) ++i;
                if (config.Contains("vweub3")) ++i;
                if (config.Contains("vh5424")) ++i;
                if (config.Contains("vnuq[s")) i += 2;

                if (i >= 2) superShipAvailable = true;
            }

            window = Game.Window.ClientBounds;
            base.Initialize();
        }

        /// <summary>
        /// Resets essential game variables
        /// </summary>
        public void ResetGame()
        {
            player = null;
            healthKit = null;
            totalTimePlayed = TimeSpan.Zero;

            if ( difficulty==Difficulty.Easy)
                iTimeTillNextHealth = 20000;
            else if (difficulty == Difficulty.Medium)
                iTimeTillNextHealth = 60000;
            else if (difficulty == Difficulty.Difficult)
                iTimeTillNextHealth = 99999999999;

            timeTillNextHealth = iTimeTillNextHealth;
            health = 850f;
            bulletFireDelay = 35;
            maxEngineTorque = 1.5f;
        }

        protected Vector2 WindowCenter
        {
            get
            {
                return new Vector2(window.Width / 2f, window.Height / 2f);
            }
        }

        /// <summary>
        /// Returns a random position
        /// </summary>
        /// <param name="offset"></param>
        /// <returns>Vector2</returns>
        protected Vector2 RandomSpawnPosition(float offset)
        {
            Vector2 position = new Vector2();
            Random xy = new Random();
            if (xy.Next(100) > 50)
            {
                Random rnd = new Random();
                int y = rnd.Next(100);
                if (y < 70)
                    position.Y = 0f - offset;
                else
                    position.Y = window.Height + offset;
                position.X = rnd.Next(window.Width);
            }
            else
            {
                Random rnd = new Random();
                int x = rnd.Next(100);
                if (x < 30)
                    position.X = 0f - offset;
                else
                    position.X = window.Width + offset;
                position.Y = rnd.Next(window.Height);
            }

            return position;
        }

        protected void UpdateInGame(GameTime gameTime)
        {            
           
            // Update both panels
            statusPanel.Update(gameTime, player.GetHealth, player.GetEngineTorque, player.GetMissileProgress(1), player.GetMissileProgress(2));
            scorePanel.Update(gameTime, player.GetPlayerScore);

            if (controlMethod == ControlMethod.Mouse)
            {
                // Change mouse cursor when locked on enemy
                MouseState mouseState = Mouse.GetState();
                lockedOnTarget = false;
                foreach (Invader invader in enemyManager.Invaders())
                {
                    if (invader.collisionRect.Intersects(new Rectangle(mouseState.X, mouseState.Y, 1, 1)))
                    {
                        lockedOnTarget = true;
                        break;
                    }
                }

                if (!lockedOnTarget)
                {

                    foreach (MotherShip motherShip in enemyManager.MotherShips())
                    {
                        if (motherShip.collisionRect.Intersects(new Rectangle(mouseState.X, mouseState.Y, 1, 1)))
                        {
                            lockedOnTarget = true;
                            break;
                        }
                        if (!lockedOnTarget)
                            foreach (Invader drone in motherShip.Drones())
                                if (drone.collisionRect.Intersects(new Rectangle(mouseState.X, mouseState.Y, 1, 1)))
                                {
                                    lockedOnTarget = true;
                                    break;
                                }
                    }
                }
            }


            player.Update(gameTime);
            if (healthKit != null) healthKit.Update(gameTime);

            enemyManager.Update(gameTime);
            explosionManager.Update(gameTime);

            if (controlMethod == ControlMethod.Mouse)
            {
                cursor.Update(gameTime);
                sniper.Update(gameTime);
            }

            timeTillNextHealth -= gameTime.ElapsedGameTime.Milliseconds;

            if (healthKit != null)
            {
                if (player.collisionRect.Intersects(healthKit.collisionRect))
                {                    
                    player.Repair(); // Restore player's hit points
                    healthKit = null;
                }
                else if (healthKit.outOfBounds(window, 30))
                    healthKit = null;
            }

            if (timeTillNextHealth <= 0)
            {
                timeTillNextHealth = iTimeTillNextHealth;
                healthKit = new HealthKit(healthKitTex, RandomSpawnPosition(15), window);
            }

            // // Player projectles | Enemy ships collision
            // // We just kill the projectle which in turn will create an explosion
            // // Each enemy class will check the explosion manager to get damage from near by explosions

            // Bullets|Invaders
            foreach (Bullet bullet in player.Bullets())
            {
                foreach (Invader invader in enemyManager.Invaders())
                    if (invader.collisionCircle.Intersects(bullet.collisionCircle) && bullet.GetHealth>0) bullet.Kill();
            }

            // Missiles|Invaders
            foreach (Missile missile in player.Missiles())
            {
                foreach (Invader invader in enemyManager.Invaders())
                    if (missile.collisionRect.Intersects(invader.collisionRect)) missile.Kill();
            }

            // Bullets|MotherShips
            foreach (Bullet bullet in player.Bullets())
            {
                foreach (MotherShip motherShip in enemyManager.MotherShips())
                {
                    foreach (Pulse pulse in motherShip.Pulses())
                        if (bullet.collisionRect.Intersects(pulse.collisionRect)) bullet.Kill();

                    if (bullet.GetHealth > 0)
                        foreach (Invader drone in motherShip.Drones())
                            if (bullet.collisionRect.Intersects(drone.collisionRect)) bullet.Kill();

                    if (bullet.GetHealth > 0)
                        if (bullet.collisionCircle.Intersects(motherShip.collisionCircle)) bullet.Kill();
                }
            }

            // Missiles|MotherShips
            foreach (Missile missile in player.Missiles())
            {
                foreach (MotherShip motherShip in enemyManager.MotherShips())
                {
                    foreach (Pulse pulse in motherShip.Pulses())
                        if (missile.collisionCircle.Intersects(pulse.collisionCircle)) missile.Kill();

                    if (missile.GetHealth > 0)
                        foreach (Invader drone in motherShip.Drones())
                            if (missile.collisionCircle.Intersects(drone.collisionCircle)) missile.Kill();

                    if (missile.GetHealth > 0)
                        if (missile.collisionCircle.Intersects(motherShip.collisionCircle)) missile.Kill();
                }
            }

            //Bullets | finalboss
            if (enemyManager.FinalBoss() != null && enemyManager.FinalBoss().IsFighting)
            {
                foreach (Bullet bullet in player.Bullets())
                {
                    if (bullet.collisionRect.Intersects(enemyManager.FinalBoss().collisionRect)) bullet.Kill();

                    foreach (Invader invader in enemyManager.FinalBoss().Defenders())
                        if (invader.collisionCircle.Intersects(bullet.collisionCircle)) bullet.Kill();

                    if (enemyManager.FinalBoss().LBolt().IsActive && bullet.collisionRect.Intersects(enemyManager.FinalBoss().LBolt().collisionRect)) bullet.Kill();
                    if (enemyManager.FinalBoss().RBolt().IsActive && bullet.collisionRect.Intersects(enemyManager.FinalBoss().RBolt().collisionRect)) bullet.Kill();
                }

                foreach (Missile missile in player.Missiles())
                {
                    if (missile.collisionRect.Intersects(enemyManager.FinalBoss().collisionRect)) missile.Kill();

                    foreach (Invader invader in enemyManager.FinalBoss().Defenders())
                        if (invader.collisionCircle.Intersects(missile.collisionCircle)) missile.Kill();

                    if (enemyManager.FinalBoss().RBolt().IsActive && missile.collisionRect.Intersects(enemyManager.FinalBoss().RBolt().collisionRect)) missile.Kill();
                    if (enemyManager.FinalBoss().LBolt().IsActive && missile.collisionRect.Intersects(enemyManager.FinalBoss().LBolt().collisionRect)) missile.Kill();
                }
            }
            
            //// Space Ships Collision : creates explosions that affects both player & enemy ships
            if (player.IsActive)
            {
                //Player|invaders
                foreach (Invader invader in enemyManager.Invaders())
                {
                    if (player.collisionRect.Intersects(invader.collisionRect))
                    {
                        soundBank.PlayCue("ShipCollision");
                        float totalSpeed = 1 + (player.GetSpeed + invader.GetSpeed) / 2f;
                        explosionManager.CreateExplosion((player.GetPosition + invader.GetPosition) / 2, 3f * totalSpeed, 2f, Side.None);
                    }
                }


                // Player|MotherShips
                foreach (MotherShip motherShip in enemyManager.MotherShips())
                {
                    foreach (Invader drone in motherShip.Drones())
                    {
                        if (player.collisionRect.Intersects(drone.collisionRect))
                        {                            
                            soundBank.PlayCue("ShipCollision");
                            float totalSpeed = 1 + (player.GetSpeed + drone.GetSpeed) / 2f;
                            explosionManager.CreateExplosion((player.GetPosition + drone.GetPosition) / 2f, 3 * totalSpeed, 2f, Side.None);
                        }
                    }

                    if (player.collisionRect.Intersects(motherShip.collisionRect))
                    {
                        soundBank.PlayCue("ShipCollision");
                        float totalSpeed = 1 + (player.GetSpeed + motherShip.GetSpeed) / 2f;
                        explosionManager.CreateExplosion((player.GetPosition + motherShip.GetPosition) / 2f, totalSpeed, 2f, Side.None);
                    }
                }

                // Player|FinalBoss
                if (enemyManager.FinalBoss() != null && enemyManager.FinalBoss().IsFighting)
                {
                    if (player.collisionRect.Intersects(enemyManager.FinalBoss().collisionRect))
                    {
                        soundBank.PlayCue("ShipCollision");
                        float totalSpeed = 1 + (player.GetSpeed + enemyManager.FinalBoss().GetSpeed) / 2f;
                        explosionManager.CreateExplosion(player.GetPosition, 3f * totalSpeed, 10f, Side.None);
                    }

                    foreach (Invader invader in enemyManager.FinalBoss().Defenders())
                        if (player.collisionRect.Intersects(invader.collisionRect))
                        {
                            soundBank.PlayCue("ShipCollision");
                            float totalSpeed2 = 1 + (player.GetSpeed + invader.GetSpeed) / 2f;
                            explosionManager.CreateExplosion((player.GetPosition + invader.GetPosition) / 2, 3f * totalSpeed2, 2f, Side.None);
                        }

                    Bolt bolt;
                    bolt = enemyManager.FinalBoss().LBolt();

                    if (player.collisionRect.Intersects(bolt.collisionRect) && bolt.IsActive)
                        explosionManager.CreateExplosion(player.GetPosition, 50f, 2f, Side.Aliens);

                    bolt = enemyManager.FinalBoss().RBolt();
                    if (player.collisionRect.Intersects(bolt.collisionRect) && bolt.IsActive)
                        explosionManager.CreateExplosion(player.GetPosition, 50f, 2f, Side.Aliens);
                }
            }


            if (player.GetHealth <= 0) player.Kill();

            if (explosionManager.Explosions().Count == 0)
            {
                if (enemyManager.IsGameFinished)
                {
                    gameState = GameState.Won;
                    bool temp = superShipAvailable;
                    UpdateConfigFile();
                    Texture2D control = mouseTex;
                    if (controlMethod == ControlMethod.Keyboard) control = keyboardTex;
                    // Create winning screen here since player results will no longer be changed                    
                    winningScreen = new WinningScreen(winningBGTex,buttonTex, font, Color.Snow,difficulty,control, player, temp, superShipAvailable,totalTimePlayed, window,soundBank);
                    ResetGame();
                }
                else if (player.GetHealth <= 0)
                {                    
                    gameState = GameState.Lost;
                    ResetGame();
                }
            }
        }
       
        protected void UpdateSelectShip(GameTime gameTime)
        {
            rapidFireShip.Update(gameTime);
            turboShip.Update(gameTime);
            armoredShip.Update(gameTime);
            superShip.Update(gameTime);

            // Each ship has a code that will be added to "config.ini" if the player wins
            if (rapidFireShip.Clicked)
            {
                shipIndex = "webljb";
                bulletFireDelay = 0;
                playerTex = rapidFireShipTex;
                gameState = GameState.SelectDifficulty;
                soundBank.PlayCue("RapidFireShip");
            }
            else if (turboShip.Clicked)
            {
                shipIndex = "vweub3";
                maxEngineTorque = 2f;
                playerTex = turboShipTex;
                gameState = GameState.SelectDifficulty;
                soundBank.PlayCue("TurboShip");
            }
            else if (armoredShip.Clicked)
            {
                shipIndex = "vh5424";
                health = 1700f;
                playerTex = armoredShipTex;
                gameState = GameState.SelectDifficulty;
                soundBank.PlayCue("ArmoredShip");
            }
            else if (superShipAvailable && superShip.Clicked)
            {
                shipIndex = "vnuq[s";
                bulletFireDelay = 0;
                maxEngineTorque = 2f;
                health = 1700f;
                playerTex = superShipTex;
                gameState = GameState.SelectDifficulty;
                soundBank.PlayCue("SuperShip");

            }
            else if (btnBack.Clicked)
            {
                gameState = GameState.MainMenu;
            }
        }
        protected void UpdateSelectControl(GameTime gameTime)
        {
            mouse.Update(gameTime);
            keyboard.Update(gameTime);

            if (mouse.Clicked)
            {
                controlMethod = ControlMethod.Mouse;
                gameState = GameState.InGame;
            }
            else if (keyboard.Clicked)
            {
                controlMethod = ControlMethod.Keyboard;
                gameState = GameState.InGame;
            }
            else if (btnBack.Clicked)
            {
                gameState = GameState.SelectDifficulty;
            }
        }

        protected void UpdateSelectDifficulty(GameTime gameTime)
        {
            selectDifficulty.Update(gameTime);

            string text = selectDifficulty.ClickedButtonText;
                            
            if (text == "Easy")
            {
                difficulty = Difficulty.Easy;
                iTimeTillNextHealth = 20000;
                gameState = GameState.SelectControl;
            }
            else if (text == "Medium")
            {
                difficulty = Difficulty.Medium;
                iTimeTillNextHealth = 60000;
                gameState = GameState.SelectControl;
            }
            else if (text == "Difficult")
            {
                difficulty = Difficulty.Difficult;
                iTimeTillNextHealth = 99999999999;
                gameState = GameState.SelectControl;
            }
            else if (btnBack.Clicked)
                gameState = GameState.SelectShip;

            timeTillNextHealth = iTimeTillNextHealth;
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            audioEngine.Update();
            switch (gameState)
            {
                case GameState.MainMenu:
                    {
                        mainMenu.Update(gameTime);
                        if (mainMenu.ClickedButtonText == "Start Game")
                            gameState = GameState.SelectShip;
                        else if (mainMenu.ClickedButtonText == "How To Play")
                            gameState = GameState.HowToPlay;
                        else if (mainMenu.ClickedButtonText == "About")
                            gameState = GameState.About;
                        else if (mainMenu.ClickedButtonText == "Exit")
                            Game.Exit();
                        break;
                    }
                case GameState.HowToPlay:
                    {
                        howToPlay.Update(gameTime);
                        string text = howToPlay.ClickedButtonText;
                        if (text == "Start Game")
                            gameState = GameState.SelectShip;
                        else if (text == "Back")
                            gameState = GameState.MainMenu;
                        break;
                    }
                case GameState.About:
                    {
                        about.Update(gameTime);
                        string text = about.ClickedButtonText;
                        if (text == "Back") gameState = GameState.MainMenu;
                        break;
                    }
                case GameState.SelectShip:
                    {
                        btnBack.Update(gameTime);
                        UpdateSelectShip(gameTime);
                        break;
                    }
                case GameState.SelectDifficulty:
                    {
                        btnBack.Update(gameTime);
                        UpdateSelectDifficulty(gameTime);
                        break;
                    }
                case GameState.SelectControl:
                    {
                        btnBack.Update(gameTime);
                        UpdateSelectControl(gameTime);
                        break;
                    }
                case GameState.InGame:
                    {
                        if (paused && Keyboard.GetState().IsKeyDown(Keys.Escape))
                        {
                            gameState = GameState.MainMenu;
                            paused = false;
                            ResetGame();
                            player = null;
                            return;
                        }

                        pauseDelay -= gameTime.ElapsedGameTime.Milliseconds;
                        if (Keyboard.GetState().IsKeyDown(Keys.P) && pauseDelay<=0)
                        {
                            if (paused==false)
                            {
                                pausedGameTime = gameTime;
                            }
                            else
                            {
                                gameTime = pausedGameTime;
                                Mouse.SetPosition((int)cursor.GetPosition.X, (int)cursor.GetPosition.Y);
                            }

                            paused = !paused;
                            pauseDelay = 500;
                        }
                        if (paused) return;

                        cloudManagerBack.Update(gameTime);
                        cloudManagerFront.Update(gameTime);

                        totalTimePlayed += gameTime.ElapsedGameTime;
                        if (player == null) // Happens only once when starting the InGame session
                        {
                            player = new Player(playerTex, new Point(4, 1), bulletTex, missileTex, WindowCenter, health, maxEngineTorque, bulletFireDelay, controlMethod, window, explosionManager, soundBank);
                            statusPanel = new StatusPanel(panelTex, lifeGaugeTex, player.GetMaxHealth, missileGaugeTex, 100f, player.GetMaxEngineTorque, window);
                            enemyManager = new EnemyManager(invaderTex, motherShipTex, droneTex, pulseTex, finalBossTex, boltTex, boltCannonTex, pulseCannonTex, defendersPlatformTex, player, window, explosionManager, soundBank);
                            totalTimePlayed = TimeSpan.Zero;
                        }
                        UpdateInGame(gameTime);

                        break;
                    }
                case GameState.Won:
                    {
                        winningScreen.Update(gameTime);
                        string clickedButtonText = winningScreen.ClickedButtonText;
                        ResetGame();
                        if (clickedButtonText == "Exit")
                            gameState = GameState.MainMenu;
                        else if (clickedButtonText == "Play Again")
                            gameState = GameState.SelectShip;
                        break;
                    }

                case GameState.Lost:
                    {
                        gameOverScreen.Update(gameTime);

                        string clickedButtonText = gameOverScreen.ClickedButtonText;
                        if (clickedButtonText == "Exit")
                            gameState = GameState.MainMenu;
                        else if (clickedButtonText == "Try Again")
                            gameState = GameState.SelectShip;

                        break;
                    }
            }
            if (gameState != GameState.InGame) sniper.Update(gameTime);
            base.Update(gameTime);
        }

        protected void DrawInGame(GameTime gameTime)
        {
            enemyManager.DrawSprites(gameTime, spriteBatch);
            explosionManager.DrawExplosions(gameTime, spriteBatch);

            if (healthKit != null) healthKit.Draw(gameTime, spriteBatch);
            player.Draw(gameTime, spriteBatch);

            if (controlMethod == ControlMethod.Mouse)
            {
                if (lockedOnTarget)
                    sniper.Draw(gameTime, spriteBatch);
                else
                    cursor.Draw(gameTime, spriteBatch);
            }

            //foreach (Invader invader in enemyManager.Invaders())
            //    spriteBatch.DrawString(font, (int)invader.GetHealth + "", invader.GetPosition, Color.White);


            //foreach (MotherShip motherShip in enemyManager.MotherShips())
            //{
            //    spriteBatch.DrawString(font, (int)motherShip.GetHealth + "", motherShip.GetPosition, Color.White);

            //    foreach (Invader drone in motherShip.Drones())
            //        spriteBatch.DrawString(font, (int)drone.GetHealth + "", drone.GetPosition, Color.White);
            //}

            //if (enemyManager.FinalBoss() != null)
            //{
            //    spriteBatch.DrawString(font, (int)enemyManager.FinalBoss().GetHealth + "", enemyManager.FinalBoss().GetPosition, Color.White);

            //    foreach (Invader invader in enemyManager.FinalBoss().Defenders())
            //        spriteBatch.DrawString(font, (int)invader.GetHealth + "", invader.GetPosition, Color.White);
            //}           
        }
        protected void DrawSelectShipDialog(GameTime gameTime)
        {
            rapidFireShip.Draw(gameTime, spriteBatch);
            turboShip.Draw(gameTime, spriteBatch);
            armoredShip.Draw(gameTime, spriteBatch);

            if (superShipAvailable == false)
                superShipNotAvailable.Draw(gameTime, spriteBatch);
            else
                superShip.Draw(gameTime, spriteBatch);
        }
       
        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            switch (gameState)
            {
                case GameState.MainMenu:
                    {
                        spriteBatch.Draw(backGroundTex, new Rectangle(0,0,window.Width,window.Height), Color.White);
                        spriteBatch.Draw(logoTex, new Vector2(30), Color.White);
                        copyRight.Draw(gameTime,spriteBatch);
                        mainMenu.Draw(gameTime, spriteBatch);
                        break;
                    }
                case GameState.HowToPlay:
                    {
                        GraphicsDevice.Clear(Color.White);
                        howToPlay.Draw(gameTime, spriteBatch);
                        break;
                    }
                case GameState.About:
                    {
                        GraphicsDevice.Clear(Color.White);
                        about.Draw(gameTime, spriteBatch);
                        break;
                    }
                case GameState.SelectShip:
                    {
                        spriteBatch.Draw(selectShipBGTex, new Rectangle(0, 0, window.Width, window.Height), new Color(100, 100, 100));
                        DrawSelectShipDialog(gameTime);
                        btnBack.Draw(gameTime, spriteBatch);
                        break;
                    }
                case GameState.SelectDifficulty:
                    {                        
                        selectDifficulty.Draw(gameTime, spriteBatch);
                        btnBack.Draw(gameTime, spriteBatch);
                        break;
                    }
                case GameState.SelectControl:
                    {
                        spriteBatch.Draw(backGroundTex, new Rectangle(0, 0, window.Width, window.Height), new Color(100,100,100));
                        keyboard.Draw(gameTime, spriteBatch);
                        mouse.Draw(gameTime, spriteBatch);
                        btnBack.Draw(gameTime, spriteBatch);
                        break;
                    }
                case GameState.InGame:
                    {
                        cloudManagerBack.DrawSmoke(gameTime, spriteBatch);
                        if (player != null) DrawInGame(gameTime);
                        cloudManagerFront.DrawSmoke(gameTime, spriteBatch);

                        if (statusPanel != null)
                        {
                            statusPanel.Draw(gameTime, spriteBatch);
                            scorePanel.Draw(gameTime, spriteBatch);
                        }

                        if (paused) spriteBatch.Draw(pausedTex, WindowCenter - new Vector2(pausedTex.Width / 2f, pausedTex.Height / 2f), Color.White);
                        
                        break;
                    }
                case GameState.Won:
                    {
                        winningScreen.Draw(gameTime, spriteBatch);
                        break;
                    }

                case GameState.Lost:
                    {
                        spriteBatch.Draw(backGroundTex, new Rectangle(0, 0, window.Width, window.Height), Color.Red);
                        gameOverScreen.Draw(gameTime, spriteBatch);
                        break;
                    }
            }
            if (gameState != GameState.InGame) sniper.Draw(gameTime, spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}