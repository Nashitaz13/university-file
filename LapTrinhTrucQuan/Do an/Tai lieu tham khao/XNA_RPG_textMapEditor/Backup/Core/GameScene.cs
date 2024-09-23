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
///
/// XNA_RPG textMapEditor engine duoc viet boi HuyetSat - Xvna.forumb.biz
/// Moi cap nhat hay thac mac ý kien ve engine xin liên he tai: xvna.forumb.biz ho?c thanh_vinh648@yahoo.com
/// Engine hoàn toàn free và nó cho phép các ban phát trien RPG mot cách de dàng!
/// Chân thành cam an ban dã quan tâm su dung engine này!
///

namespace XNA_RPG_textMapEditor.Core
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class GameScene : Microsoft.Xna.Framework.DrawableGameComponent
    {
        protected bool next;
        public bool Next
        {
            get {return next;}
            set { next = value; }
        }
        protected SpriteBatch sBatch;
        Texture2D BG;
        List<DrawableGameComponent> compoments;
        public List<DrawableGameComponent> Compoments
        {
            get { return compoments; }
            set { compoments = value; }
        }
        public GameScene(Game game,Texture2D BG)
            : base(game)
        {
            //DK chuyen man`
            Next = false;
            //Lay dich vu
            sBatch = Game.Services.GetService(typeof(SpriteBatch)) as SpriteBatch;
            //tao mang compoment, chung se dc tu dong update va` Draw
            compoments = new List<DrawableGameComponent>();
            //Lay background
            this.BG = BG;
            //an? man`
            Hide();
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            for (int i = 0; i < compoments.Count; i++)
                compoments[i].Initialize();

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            //update all gameCompoments
            for (int i = 0; i < compoments.Count; i++)
                if (compoments[i].Enabled)
                    compoments[i].Update(gameTime);
                
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            //draw background
            //sBatch.Draw(BG, Vector2.Zero, Color.White);
            //draw all game compoments
            for (int i = 0; i < compoments.Count; i++)
                if (compoments[i].Visible)
                    compoments[i].Draw(gameTime);
            base.Draw(gameTime);
        }
        public void removeAll()
        {
            for(int i = 0;i<Compoments.Count;i++)
                Compoments.RemoveAt(i);
        }
        //Man choi bi an? de 1 man` khac dc the hien
        public void Hide()
        {
            Enabled = false;
            Visible = false;
        }
        //Man` choi dc the hien
        public void Show()
        {
            Enabled = true;
            Visible = true;
        }
        //dung` tro` choi tam thoi` (nhan space)
        public void Pause()
        {
            Enabled = false;
            Visible = true;
        }
        //Cho phep game chay tro lai (nhan space)
        public void Resume()
        {
            Show();
        }
    }
}