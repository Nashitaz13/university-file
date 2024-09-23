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

using XNA_RPG_textMapEditor.Helper;
using XNA_RPG_textMapEditor.Core;
using XNA_RPG_textMapEditor.GUI;
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

    class StartScene:GameScene
    {
        
        Menu menu;
        Button start;
        Button end;
        List<Button> listButton = new List<Button>();
        //service
        Input input;
        public StartScene(Game game, Texture2D BG)
            : base(game, BG)
        {
            Compoments = new List<DrawableGameComponent>();
            Texture2D active = game.Content.Load<Texture2D>(AssetPath.ButtonTexture+"Selected");
            Texture2D wait = game.Content.Load<Texture2D>(AssetPath.ButtonTexture+"NoSelect");
            start = new Button(game, active, wait, Button.Status.active);
            start.Position = Vector2.Zero;
            end = new Button(game, active, wait, Button.Status.wait);
            end.Position = new Vector2(0, 50);
            listButton.Add(start);
            listButton.Add(end);
            menu = new Menu(game, listButton);
            Compoments.Add(menu);
            input = (Input)Game.Services.GetService(typeof(Input)) as Input;
        }
        public override void Update(GameTime gameTime)
        {
            if (menu.Index == 0 && input.Release(Keys.Enter))
                next = true;
            if (menu.Index == 1 && input.Release(Keys.Enter))
                Game.Exit();
            base.Update(gameTime);
        }
    }
}
