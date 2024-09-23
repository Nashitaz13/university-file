using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Game2
{
    public class BulletEnemyCollsion
    {
        public static void detect(Bullet[] bullets, Enemy[] enemies)
        {
            for (int i = 0; i < bullets.Length; i++)
                for(int j = 0; j < enemies.Length; j++)
                    if (bullets[i].boundingBox.Intersects(enemies[j].BoundingBox) && bullets[i].active)
                    {
                        enemies[j].health -= bullets[i].Damage;
                        bullets[i].active = false;
                    }
        }
    }
}
