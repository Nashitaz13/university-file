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

using XNA_RPG_textMapEditor.Controller;
using XNA_RPG_textMapEditor.Animate;
///
/// XNA_RPG textMapEditor engine duoc viet boi HuyetSat - Xvna.forumb.biz
/// Moi cap nhat hay thac mac ý kien ve engine xin liên he tai: xvna.forumb.biz hoac thanh_vinh648@yahoo.com
/// Engine hoàn toàn free và nó cho phép các ban phát trien RPG mot cách de dàng!
/// Yeu cau ghi ro~ nguon goc engine va tac gia khi ban phat trien game ca nhan bang engine nay!
/// Chân thành cam an ban dã quan tâm su dung engine này!
///

namespace XNA_RPG_textMapEditor.Core
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Sprite : DrawableGameComponent
    { 
        //aimEnemy
        protected Sprite sprite;
        //aimGroupEnemy
        protected List<Sprite> sprites;
       
        //Animate:

        internal Animation idle;
        internal Animation run;
        internal Animation attack;
        internal Animation cast;
        internal Animation die;
        internal AnimationPlayer AnimationPlayer;
       
        
        //draw
        protected SpriteBatch sbBatch; 
        //xac dinh time to attack
        protected TimeSpan attackTime = TimeSpan.Zero;
        //hcn bao quanh sprite
        protected Rectangle spriteRectangle;

        public enum Face
        {
            Left = -1,
            Right = 1
        }
        //Do dai` cua mot frame
        protected float frameDelay = 0.1f;

        #region Property
        //Thuoc tinh aim sprite
        public Sprite SpriteAim
        {
            get { return sprite; }
            set { sprite = value; }
        }
        public List<Sprite> SpritesAim
        {
            get { return sprites; }
            set { sprites = value; }
        }
        //KT va cham voi tiles
        public List<Tiles> tiles { get; set; }

        //thuoc tinh co ban
        public Vector2 Center { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }

        public int MaxLife { get; set; }
        public int Life { get; set; }
        public float SpeedRun { get; set; }

        //Giap' cua sprite
        public float Amor { get; set; }
        //KT xem spite co dang tan cong vat ly hay ko
        public bool PhySicAtt { get; set; }
        //KT sprite co dang tan cong phep thuat hay ko
        public bool Casting { get; set; }
        //da chet chua?
        public bool IsDead { get; set; } 
        //Co bi tan cong tu` 1 sprite khac hay ko
        public bool IsHited { get; set; }
        //8 huong nhin` cua sprite
        public Face face { get; set; }
        #endregion

        
        
        public Sprite(Game game,Texture2D idle,Texture2D run,Texture2D attack,Texture2D castSpell,Texture2D die)
            : base(game)
        {
            Enabled = true;
            Visible = true;
            //centor
            Center = new Vector2(Position.X+25,Position.Y+25);
            //get service
            sbBatch = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch)) as SpriteBatch;
            //load animate texture
            this.idle = new Animation(idle, frameDelay, true);
            this.run = new Animation(run, frameDelay, true);
            this.attack = new Animation(attack, frameDelay, true);
            this.cast = new Animation(castSpell, frameDelay, false);
            this.die = new Animation(die, frameDelay, false);
            //play animate defaute:
            AnimationPlayer.PlayAnimation(this.idle);
            //load status
            IsDead = false;
            IsHited = false;

            face = Face.Left;
        }
        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected bool Collides = false;
        public bool CheckCollidesTiles()
        {
            Collides = false;
            
            //move sprite
            Position += Velocity;
            UpdatePoint();

            if (tiles != null)
                foreach (Tiles tile in tiles)
                {
                    if (CheckCollides(tile.Rec))
                    {
                        Collides = true;
                        break;
                    }

                }
            return Collides;
        }
        public override void Update(GameTime gameTime)
        {
            if (IsDead)
            {
                //chet la` het' :)
                AnimationPlayer.PlayAnimation(die);
                return;
            }
                //sprite trong trang thai tan cong vat ly'
            else if (PhySicAtt)
            {
                Velocity = Vector2.Zero;
                AnimationPlayer.PlayAnimation(attack);
                attackTime += gameTime.ElapsedGameTime;
                if (attackTime > TimeSpan.FromSeconds(attack.FrameCount * attack.FrameTime/2))
                {
                    attackTime -= TimeSpan.FromSeconds(attack.FrameCount * attack.FrameTime/2);
                    //Enemy nhan damage
                    if (sprite != null)
                        // 0  o day la damage cua sprite phai nhan
                        sprite.TakeDamage(0);
                    if (sprites != null)
                        foreach (Sprite sp in sprites)
                            sp.TakeDamage(0);
                    //ko con` attack nua

                }
            }
                //sprite trong trang thai' casting spell
            else if (Casting)
            {
                Velocity = Vector2.Zero;
                AnimationPlayer.PlayAnimation(cast);
                attackTime += gameTime.ElapsedGameTime;
                if (attackTime > TimeSpan.FromSeconds(attack.FrameCount * attack.FrameTime/2))
                {
                    attackTime -= TimeSpan.FromSeconds(attack.FrameCount * attack.FrameTime/2);
                    //Enemy nhan damage, 0 o duoi day la damage ma` sprite nhan
                    if (sprite != null)
                        sprite.TakeDamage(0);
                    if (sprites != null)
                        foreach (Sprite sp in sprites)
                            sp.TakeDamage(0);
                    //Ko con` dung` phep' nua
                }
            }
            else if (Velocity != Vector2.Zero&&!Casting&&!PhySicAtt)
            {
                Vector2 lastPos = Position;
                AnimationPlayer.PlayAnimation(run);
                ;
                //kt va cham voi tile
                if (CheckCollidesTiles())
                {
                    Position = lastPos;
                }
                //Cuon trong man` hinh`(for debugging)
                if (Position.X > 1550)
                    Position = new Vector2(0, Position.Y);
                if (Position.Y > 1350)
                    Position = new Vector2(Position.X, 0);
                if (Position.X < 0)
                    Position = new Vector2(1550, Position.Y);
                if (Position.Y < 0)
                    Position = new Vector2(Position.X, 1350);

                //xac dinh face
                if (Velocity.X > 0)
                {
                    face = Face.Right;    
                }
                if(Velocity.X < 0)
                    face = Face.Left;
            }
            if (Velocity == Vector2.Zero && !Casting && !PhySicAtt)
            {
                AnimationPlayer.PlayAnimation(idle);
            }
            //Update Center Position va` spriteRectangle
            UpdatePoint();
            base.Update(gameTime);
        }
        public void UpdatePoint()
        {
            Center = new Vector2(Position.X + 25, Position.Y + 20);
            spriteRectangle = new Rectangle((int)Position.X+10, (int)Position.Y+5,30,45);
        }
        
        public override void Draw(GameTime gameTime)
        {
            //dung` effect dao nguoc theo chieu ngang hay ko:

            SpriteEffects flip = (int)face > 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

            AnimationPlayer.Draw(gameTime, sbBatch, Position, flip);
            base.Draw(gameTime);
        }
        public bool CheckCollides(Rectangle rec)
        {
           return spriteRectangle.Intersects(rec);
        }
        public virtual void TakeDamage(int damage)
        {
            Amor = MathHelper.Max(Amor, 100);
            //so amor = so percent tranh dc damage
            Life -= 1;
            //sprite chet khi het mau'
            if (Life < -3)
            {
                IsDead = true;
            }
        }
    }
}