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
using FlappyBirdDemo.Entities;

namespace FlappyBirdDemo.Screens
{
    public class GameScreen: Screen
    {
        public Texture2D background;
        public Texture2D sand;
        public Entities.Bird bird;
        public Entities.Scroll scroll;
        public List<Entities.Tuyaux> tuyaux;

        public int tuyauxTimer = 2000;
        public double tuyauxElapsed = 0;

        public int score = 0;

        public SpriteFont font;
        public Texture2D gameover ;
        public bool gameOver = false;
        public GameScreen()
        {

        }

        public override void LoadContent()
        {
            background = Statics.CONTENT.Load<Texture2D>("Textures/background");
            sand = Statics.CONTENT.Load<Texture2D>("Textures/sand");
            font = Statics.CONTENT.Load<SpriteFont>("Fonts/font");
            gameover = Statics.CONTENT.Load<Texture2D>("Textures/gameover");
            Reset();
            base.LoadContent();
        }

        public void Reset()
        {
            bird = new Entities.Bird();
            scroll = new Entities.Scroll();
            tuyaux = new List<Entities.Tuyaux>();
            tuyaux.Add(new Entities.Tuyaux());
            score = 0;
            gameOver = false;
            tuyauxElapsed = 0;
        }

        public override void Update()
        {
            TuyauxCreator();
            //foreach (var item in tuyaux)
            //{
            //    item.Upadate();
            //}

            if (!bird.dead)
            {
                for (int i = tuyaux.Count - 1; i > -1; i--)
                {
                    if (tuyaux[i].position.X < -50)
                        tuyaux.RemoveAt(i);
                    else
                    {
                        tuyaux[i].Upadate();
                        if (!tuyaux[i].scored && bird.position.X > tuyaux[i].position.X + 50)
                        {
                            //tuyaux[i].Upadate();
                            tuyaux[i].scored = true;
                            score++;
                        }

                        if(bird.Bound.Intersects(tuyaux[i].TopBound) || bird.Bound.Intersects(tuyaux[i].BottomBound))
                        {
                            bird.dead = true;
                        }
                    }

                }
                bird.Update();
                scroll.Update();
            }

            if (bird.dead && Statics.INPUT.IsKeyPressed(Microsoft.Xna.Framework.Input.Keys.R))
            {
                this.Reset();
            }

            
            base.Update();
        }

        public void TuyauxCreator()
        {
            tuyauxElapsed += Statics.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            if (tuyauxElapsed > tuyauxTimer)
            {

                tuyaux.Add(new Entities.Tuyaux());
                tuyauxElapsed = 0;
            }
        }
        public override void Draw()
        {
            //Statics.SPRITEBATCH.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearWrap, null, null);
            Statics.SPRITEBATCH.Begin();

            Statics.SPRITEBATCH.Draw(this.background, Vector2.Zero, Color.White);
            foreach (var item in tuyaux)
            {
                item.Draw();
            }
            Statics.SPRITEBATCH.Draw(this.sand, new Vector2(0, 529), Color.White);

            
            scroll.Draw();
            bird.Draw();

            Statics.SPRITEBATCH.DrawString(this.font, "Score : " + this.score.ToString(), new Vector2(10, 10), Color.Red);

            if (bird.dead)
            {

                //Statics.SPRITEBATCH.Draw(Statics.PIXEL, new Rectangle(0, 0, Statics.GAME_WIDTH, Statics.GAME_HIGHT), new Color(1f, 0f, 0f, 0.3f));
                Statics.SPRITEBATCH.Draw(this.gameover, new Vector2(0, 80), Color.White);
            }
            Statics.SPRITEBATCH.End();
            base.Draw();
        }
    }
}
