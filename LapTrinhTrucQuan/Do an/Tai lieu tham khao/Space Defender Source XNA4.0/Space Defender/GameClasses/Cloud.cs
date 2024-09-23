using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender
{
    class Cloud : Sprite
    {
        float scale;

        public Cloud(Texture2D textureImage, Vector2 position,Vector2 speed,float scale,Rectangle window)
            : base(textureImage, new Point(1, 1), position,speed,window,null,null)
        {
            this.scale = scale;
        }
       
        public Vector2 direction
        {
            get
            {
                return speed;
            }
        }

        public override void Update(GameTime gameTime)
        {
            position += direction;

            base.Update(gameTime);
        }

        public float GetScale
        {
            get
            {
                return scale;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            this.Draw(gameTime, spriteBatch, scale);
        }

        protected override void GetDamageFromExplosions()
        {
            // clouds cannot be damaged or destroyed
        }
        protected override void GetDamageFromExplosions(bool getFriendlyFire)
        {
            // clouds cannot be damaged or destroyed
        }        
    }
}
