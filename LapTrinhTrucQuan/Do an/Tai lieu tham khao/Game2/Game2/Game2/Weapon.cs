using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    public class Weapon
    {
        String name;
        int bulletCount;
        Bullet[] bullets;
        
        public int BulletCount
        { 
            get
            { 
                return bulletCount;
            }
            set { }
        }
        public Bullet[] Bullets { get { return bullets; } }

        public Weapon(String name, int bulletCount, Texture2D bulletTexture)
        {
            this.name = name;
            this.bulletCount = bulletCount;
            bullets = new Bullet[bulletCount];
            for(int i = 0; i < bulletCount; i++)
                bullets[i] = new Bullet(bulletTexture, new Vector2(-100, -100), new Vector2(0,0));
 
        }
     
    }
}
