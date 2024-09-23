using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

using XNA_RPG_textMapEditor.Enemy;
using XNA_RPG_textMapEditor.Helper;
using XNA_RPG_textMapEditor.Core;
using XNA_RPG_textMapEditor.Controller;
using XNA_RPG_textMapEditor.Level.World1;
///
/// XNA_RPG textMapEditor engine duoc viet boi HuyetSat - Xvna.forumb.biz
/// Moi cap nhat hay thac mac ý kien ve engine xin liên he tai: xvna.forumb.biz hoac thanh_vinh648@yahoo.com
/// Engine hoàn toàn free và nó cho phép các ban phát trien RPG mot cách de dàng!
/// Yeu cau ghi ro~ nguon goc engine va tac gia khi ban phat trien game ca nhan bang engine nay!
/// Chân thành cam an ban dã quan tâm su dung engine này!
///
namespace XNA_RPG_textMapEditor.Scene
{
    class ActionScene1:GameScene
    {
        AudioManager audio;
        public bool Die
        {
            get { return levelCreator.Player.IsDead; }
        }

        bool receiveKey = false;
        //level choi game
        public LevelCreator1 Level
        {
            get { return levelCreator; }
        }
        LevelCreator1 levelCreator = new LevelCreator1();
        //So diem phai den' (exit) ma` nguoi choi Phai den'
        int goalCount = 0;
        //So diem phai den' (exit) ma` nguoi choi Da~ den'
        int goalreceived = 0;
        public ActionScene1(Game game, Texture2D BG,String pathMap)
            : base(game, BG)
        {
            audio = Game.Services.GetService(typeof(AudioManager)) as AudioManager;

            Compoments = new List<DrawableGameComponent>();
            //tao level ;)
            levelCreator.CreateLevel(game, AssetPath.Map + pathMap);
            //add gameCompoments
            foreach (DrawableGameComponent dgc in levelCreator.Goals)
                Compoments.Add(dgc);
            foreach (DrawableGameComponent dgc in levelCreator.Tiles)
                Compoments.Add(dgc);
            foreach (DrawableGameComponent dgc in levelCreator.Keys)
                Compoments.Add(dgc);
            foreach (DrawableGameComponent dgc in levelCreator.Gates)
                Compoments.Add(dgc);

            Compoments.Add(levelCreator.Player);
            //KT va cham voi player
            levelCreator.Player.tiles = levelCreator.Tiles;

            //Tao va` KT va cham voi Enemy
            foreach (DrawableGameComponent dgc in levelCreator.Enemys)
            {
                Compoments.Add(dgc);
            }
            foreach (MeleeEnemy enemy in levelCreator.Enemys)
            {
                enemy.tiles = levelCreator.Tiles;
            }
            goalCount = levelCreator.Goals.Count;
        }
        public override void Update(GameTime gameTime)
        {
            foreach (Tiles goal in levelCreator.Keys)
            {
                if (levelCreator.Player.CheckCollides(goal.Rec))
                {
                    if (!receiveKey)
                    {
                        audio.KeyReceived.Play();
                        DisposeTile(goal);
                        receiveKey = true;
                    }
                }
            }
            foreach (Tiles goal in levelCreator.Gates)
            {
                if (Vector2.Distance(levelCreator.Player.Center, goal.Position + new Vector2(25, 25)) < 60)
                {
                    if (receiveKey)
                    {
                        audio.KeyReceived.Play();
                        DisposeTile(goal);
                        receiveKey = false;
                    }
                }
            }
            foreach (Tiles goal in levelCreator.Goals)
            {
                if (levelCreator.Player.CheckCollides(goal.Rec))
                {
                    DisposeTile(goal);
                    goalreceived++;
                    if (goalreceived >= goalCount)
                    {
                        audio.Exit.Play();
                        next = true;
                    }
                }
            }
            base.Update(gameTime);
        }
        private void DisposeTile(Tiles goal)
        {
            goal.Position = new Vector2(-100, -100);
            goal.Initialize();
            goal.Enabled = false;
            goal.Visible = false;
        }
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            Vector2 cameraPos = (Vector2)Game.Services.GetService(typeof(Vector2));
            if (Die)
            {
                levelCreator.Player.AnimationPlayer.PlayAnimation(levelCreator.Player.die);
                Pause();
                sBatch.Draw(Game.Content.Load<Texture2D>(AssetPath.OverlayTexture + "you_died"), new Vector2(Game.Window.ClientBounds.Width / 2 - cameraPos.X - 100, Game.Window.ClientBounds.Height / 2 - cameraPos.Y - 50), Color.White);
            }
            if (Next)
            {
                levelCreator.Player.AnimationPlayer.PlayAnimation(levelCreator.Player.cast);
                Pause();
                sBatch.Draw(Game.Content.Load<Texture2D>(AssetPath.OverlayTexture + "you_win"), new Vector2(Game.Window.ClientBounds.Width / 2 - cameraPos.X -100, Game.Window.ClientBounds.Height / 2 - cameraPos.Y-50), Color.White);
            }
        }
    }
}
