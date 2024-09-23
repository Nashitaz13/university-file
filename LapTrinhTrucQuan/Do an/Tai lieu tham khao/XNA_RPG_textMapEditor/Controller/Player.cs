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

using XNA_RPG_textMapEditor.Core;
using XNA_RPG_textMapEditor.Helper;
///
/// XNA_RPG textMapEditor engine duoc viet boi HuyetSat - Xvna.forumb.biz
/// Moi cap nhat hay thac mac ý kien ve engine xin liên he tai: xvna.forumb.biz hoac thanh_vinh648@yahoo.com
/// Engine hoàn toàn free và nó cho phép các ban phát trien RPG mot cách de dàng!
/// Yeu cau ghi ro~ nguon goc engine va tac gia khi ban phat trien game ca nhan bang engine nay!
/// Chân thành cam an ban dã quan tâm su dung engine này!
///
namespace XNA_RPG_textMapEditor.Controller
{
    class Player : Sprite
    {

        AudioManager audio;

        Input input;

        public Player(Game game,Texture2D idle,Texture2D run,Texture2D attack,Texture2D castSpell,Texture2D die)
            :base(game,idle,run,attack,castSpell,die)

        {
            input = (Input)Game.Services.GetService(typeof(Input)) as Input;
            audio = Game.Services.GetService(typeof(AudioManager)) as AudioManager;
        }
        public override void Update(GameTime gameTime)
        {

            UpdatePoint();
            CheckKey(gameTime);
            base.Update(gameTime);
        }
        public void CheckKey(GameTime gameTime)
        {
            Velocity = Vector2.Zero;
            if (input.Press(Keys.Down))
                Velocity += new Vector2(0, 2);
            if (input.Press(Keys.Up))
                Velocity += new Vector2(0, -2);
            if (input.Press(Keys.Right))
                Velocity += new Vector2(+2, 0);
            if (input.Press(Keys.Left))
                Velocity += new Vector2(-2, 0);
            }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            audio.Die1.Play();
        } 
        }
    
    }
    

