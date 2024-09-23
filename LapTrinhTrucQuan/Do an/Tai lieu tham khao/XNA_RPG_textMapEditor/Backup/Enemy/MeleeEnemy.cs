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
using XNA_RPG_textMapEditor.Controller;
using XNA_RPG_textMapEditor.Helper;
///
/// XNA_RPG textMapEditor engine duoc viet boi HuyetSat - Xvna.forumb.biz
/// Moi cap nhat hay thac mac ý kien ve engine xin liên he tai: xvna.forumb.biz hoac thanh_vinh648@yahoo.com
/// Engine hoàn toàn free và nó cho phép các ban phát trien RPG mot cách de dàng!
/// Yeu cau ghi ro~ nguon goc engine va tac gia khi ban phat trien game ca nhan bang engine nay!
/// Chân thành cam an ban dã quan tâm su dung engine này!
///
namespace XNA_RPG_textMapEditor.Enemy
{
    class MeleeEnemy:Sprite
    {
        public bool isWait = false;
        //Enemy dc dung` spell hay ko
        protected bool useSpell = false;
        //AI tu dong tan cong player
        //Khoang cach bat dau` "ruot duoi"
        protected int ChaseDistant = 200;
        //khoang cach bat dau` gay sat thuong
        protected int AttackDistant = 20;
        //Ke thu` (nguoi choi)
        protected Player user;
        //ke thu`
        public Player User
        {
            get { return user; }
            set { user = value; }
        }
        //Goc di chuyen cua enemy
        float alpha;

        public MeleeEnemy(Game game, Texture2D idle, Texture2D run, Texture2D attack, Texture2D castSpell, Texture2D die)
            : base(game,idle,run,attack,castSpell,die)
        {
        }
        public void Wander(GameTime time)
        {
            attackTime += time.ElapsedGameTime;
            if (attackTime > TimeSpan.FromMilliseconds(1000))
            {
                attackTime -= TimeSpan.FromMilliseconds(1000);
                alpha = RDHelper.GetRandomInt(7) * MathHelper.PiOver4;
                Velocity = new Vector2(RDHelper.GetRandomInt(1) - RDHelper.GetRandomInt(2), RDHelper.GetRandomInt(1) - RDHelper.GetRandomInt(2));

                Velocity = new Vector2((float)Math.Cos(alpha) * Velocity.X * RDHelper.GetRandomInt(3), (float)Math.Sin(alpha) * Velocity.Y * RDHelper.GetRandomInt(3));
            }
        }
        bool X = false;
        bool Y = false;
        public void MoveX(Player player)
        {
            X = true;
            Y = false;
            if (Center.X < player.Center.X)
            {
                Velocity += new Vector2(1, 0);
            }
            if (Center.X > player.Center.X)
            {
                Velocity += new Vector2(-1, 0);

            }
        }
        public void MoveY(Player player)
        {
            Y = true;
            X = false;
            if (Center.Y < player.Center.Y)
                Velocity += new Vector2(0, 1);
            if (Center.Y > player.Center.Y)
                Velocity += new Vector2(0, -1);
        }
        public Vector2 Chase(Player player)
        {
            Velocity = Vector2.Zero;
            if (Center.X > player.Center.X+1||Center.X<player.Center.X-1)
            {
                MoveX(player);
                
            }
            else
            {
                MoveY(player);
            }
            
            return Velocity;
        }
        public void Evade(Player player)
        {
            Velocity = -Chase(player);
        }
        public override void Update(GameTime gameTime)
        {
            UpdatePoint();
            //Xac dinh trang thai phu` hop cho AI
            //ruot duoi player
            if (Vector2.Distance(Center, user.Center) > ChaseDistant)
            {
                Casting = false;
                PhySicAtt = false;

                if (isWait)
                    Velocity = Vector2.Zero;
                else
                {
                    Wander(gameTime);
                }
            } 
            else if (Vector2.Distance(Center, user.Center) <= ChaseDistant && Vector2.Distance(Center, user.Center) > AttackDistant)
            {
                Casting = false;
                PhySicAtt = false;
                Chase(User); 
            }
            else if (Vector2.Distance(Center, user.Center) <= AttackDistant)
            {
                sprite = user;
                if (useSpell)
                {
                    PhySicAtt = false;
                    Casting = true;
                }
                else
                {
                    Casting = false;
                    PhySicAtt = true;
                }
            }
            
            base.Update(gameTime);
            //Code de? enemy biet tranh vat can khi truy duoi player
            if (Collides)
            {
                Vector2 last = Position;
                if (Center.X > user.Center.X + 1 || Center.X < user.Center.X - 1)
                {
                    Velocity = Vector2.Zero;
                    if (Y)
                    {
                        MoveX(user);
                    }
                    else
                        MoveY(user);
                    if (CheckCollidesTiles())
                    {
                        Position = last;
                    }
                }
                else
                {
                    AnimationPlayer.PlayAnimation(idle);
                    Velocity = Vector2.Zero;
                }
            }
        }
        
    }
}
