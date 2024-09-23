using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender
{
    class CloudManager
    {
        Texture2D textureImage;
        Rectangle window;
        int period;
        int timeTillNextSmoke = 0;
        Random rnd;

        List<Cloud> clouds = new List<Cloud>();
                
        public CloudManager(Texture2D textureImage, int period,int randomSeed, Rectangle window)
        {
            this.textureImage = textureImage;
            this.period = period;
            rnd = new Random(randomSeed);
            this.window = window;
        }

        protected virtual Vector2 RandomSpawnPosition(float offset)
        {            
            return new Vector2(window.Width + offset, rnd.Next(window.Height));
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i <= clouds.Count - 1; i++)
            {
                if (clouds[i].GetPosition.X<-15.5f*clouds[i].GetScale)
                {
                    clouds.RemoveAt(i);
                    --i;
                }
            }

            foreach (Cloud cloud in clouds)
                cloud.Update(gameTime);

            timeTillNextSmoke += gameTime.ElapsedGameTime.Milliseconds;

            if (timeTillNextSmoke >= period)
            {
                timeTillNextSmoke = 0;
                clouds.Add(new Cloud(textureImage,RandomSpawnPosition(30),new Vector2(-rnd.Next(100)/50f-1,0),(float)(rnd.NextDouble()*5f)+0.1f, window));
            }
        }

        public void DrawSmoke(GameTime gameTime,SpriteBatch spriteBatch)
        {
            foreach (Cloud cloud in clouds)
                cloud.Draw(gameTime, spriteBatch);
        }

        public void ClearClouds()
        {
            clouds.Clear();
        }
    }
}
