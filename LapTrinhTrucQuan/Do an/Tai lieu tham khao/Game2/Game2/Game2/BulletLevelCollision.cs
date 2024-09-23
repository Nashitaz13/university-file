using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;


namespace Game2
{
    class BulletLevelCollision
    {
        public static bool Detect(Bullet bullet, Level1 level)
        {
            bool result = false;
            for (int j = 0; j < level.BoundingBoxes.Count; j++)
                if (bullet.boundingBox.Intersects(level.BoundingBoxes[j]))
                    result = true;
            return result;

        }
    }
}
