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

namespace FlappyBirdDemo.Entities
{
    public class Bird
    {
        public Texture2D [] textures;
        public float rotation;
        public float YSpeed;
        public int PositionTexture;
        public Vector2 position;


        public int jumbTimer = 500;
        public double jumbElapsed = 0;
        public bool canJumb = true;

        public int animTimer = 100;
        public double animElapsed = 0;
        public int textureAdd = 1;

        
        public bool dead = false;

        

        public Bird()
        {
            textures = new Texture2D[3];
            textures[0] = Statics.CONTENT.Load<Texture2D>("Textures/bird1");
            textures[1] = Statics.CONTENT.Load<Texture2D>("Textures/bird2");
            textures[2] = Statics.CONTENT.Load<Texture2D>("Textures/bird3");
            YSpeed = 0;
            this.position = new Vector2(150, 300);
        }

        public Rectangle Bound
        {
            get
            {
                return new Rectangle((int)this.position.X - 20, (int)this.position.Y - 20, 40, 40); 
            }
            set
            {

            }
        }
        
        public void Update()
        {
            YSpeed += 0.4f;

            jumbElapsed += Statics.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            if (jumbElapsed > jumbTimer)
            {
                canJumb = true;
                jumbElapsed = 0;
            }

            animElapsed += Statics.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            if (animElapsed > animTimer)
            {
                this.PositionTexture += this.textureAdd;
                if (this.PositionTexture == 2 || this.PositionTexture == 0)
                    this.textureAdd = this.textureAdd * -1;
                animElapsed = 0;
            }

            if(Statics.INPUT.IsKeyPressed(Keys.Space) && canJumb)
            {
                YSpeed = -8;
            }

            rotation = (float)Math.Atan2(YSpeed, 7);

            //if (YSpeed > 0f)
            //    rotation = 0.5f; 
            //else
            //    rotation = -0.5f;

            this.position.Y += YSpeed;
            if (this.position.Y > 500)
                dead = true;
        }
        public void Draw()
        {
            Statics.SPRITEBATCH.Draw(this.textures[this.PositionTexture], this.position, null, Color.White, this.rotation, new Vector2(20, 20), 1f, SpriteEffects.None, 0f);
            //show debug
            Statics.SPRITEBATCH.Draw(Statics.PIXEL, this.Bound, new Color(1f, 0f, 0f, 0.3f));
        }
    }
}
