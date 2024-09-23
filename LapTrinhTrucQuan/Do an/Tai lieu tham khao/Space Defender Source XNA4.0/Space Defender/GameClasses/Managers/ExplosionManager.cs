using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Space_Defender
{
    // This class will handle all the explosions in the game
    class ExplosionManager
    {
        protected Texture2D textureImage; // for the explosions
        protected List<Explosion> explosions = new List<Explosion>(); // List of all the explosions in the game

        public ExplosionManager(Texture2D textureImage)
        {
            this.textureImage = textureImage;
        }

        public void CreateExplosion(Vector2 location, float explosionDamage, float explosionRadius, Side side)
        {
            explosions.Add(new Explosion(textureImage, new Point(7, 1),  location, explosionDamage, explosionRadius, side));
        }

        public void CreateExplosion(Vector2 location, float explosionDamage, float explosionRadius, Side side, bool visible)
        {
            explosions.Add(new Explosion(textureImage, new Point(7, 1),  location, explosionDamage, explosionRadius, side, visible));
        }

        public void CreateExplosion(Vector2 location, float explosionDamage, float explosionRadius,int millisecondsPerFrame, Side side )
        {
            explosions.Add(new Explosion(textureImage, new Point(7, 1),  location, explosionDamage, explosionRadius,millisecondsPerFrame ,side));
        }


        public void Update(GameTime gameTime)
        {
            // Remove dead explosions
            for (int i = 0; i <= explosions.Count - 1; i++)
            {
                if (explosions[i].IsActive == false)
                {
                    explosions.RemoveAt(i);
                    --i;
                }
            }

            // Update the remaining ones
            for (int i = 0; i <= explosions.Count - 1; i++)
            {
                explosions[i].Update(gameTime);
            }
        }

        public void DrawExplosions(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (int i = 0; i <= explosions.Count - 1; i++)
            {
                explosions[i].Draw(gameTime, spriteBatch, explosions[i].GetExplosionRadius / (56f / 2f));
            }
        }

        public List<Explosion> Explosions()
        {
            return explosions;
        }
    }
}
