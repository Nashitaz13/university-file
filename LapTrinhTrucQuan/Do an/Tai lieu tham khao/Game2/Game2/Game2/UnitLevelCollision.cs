using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Game2
{
    public class UnitLevelCollision
    {
        public static Result Detect(Player player, Level1 level)
        {
            Result result = new Result();
            int playerBoxes = player.BoundingBoxes.Length;
            int levelBoxes = level.BoundingBoxes.Count;
            result.contactTop = false;
            result.contactRight = false;
            result.contactBottom = false;
            result.contactLeft = false;

            for (int i = 0; i < playerBoxes; i++)
            {
                if (i == 0)
                    for (int j = 0; j < levelBoxes; j++)
                        if (player.BoundingBoxes[i].Intersects(level.BoundingBoxes[j]))
                        {
                            result.upwardBox = Rectangle.Intersect(player.BoundingBoxes[i], level.BoundingBoxes[j]);
                            result.contactTop = true;
                        }
                if (i == 1)
                    for (int j = 0; j < levelBoxes; j++)
                        if (player.BoundingBoxes[i].Intersects(level.BoundingBoxes[j]))
                        {
                            result.rightBox = Rectangle.Intersect(player.BoundingBoxes[i], level.BoundingBoxes[j]);
                            result.contactRight = true;
                        }
                if (i == 2)
                    for (int j = 0; j < levelBoxes; j++)
                        if (player.BoundingBoxes[i].Intersects(level.BoundingBoxes[j]))
                        {
                            result.downwardBox = Rectangle.Intersect(player.BoundingBoxes[i], level.BoundingBoxes[j]);
                            result.contactBottom = true;
                        }
                if (i == 3)
                    for (int j = 0; j < levelBoxes; j++)
                        if(player.BoundingBoxes[i].Intersects(level.BoundingBoxes[j]))
                        {
                            result.leftBox = Rectangle.Intersect(player.BoundingBoxes[i], level.BoundingBoxes[j]);
                            result.contactLeft = true;
                        }
            }
            return result;
        }    
    }
    
    public struct Result
    {
        public bool contactTop;
        public bool contactBottom;
        public bool contactRight;
        public bool contactLeft;
        public Rectangle upwardBox;
        public Rectangle rightBox;
        public Rectangle downwardBox;
        public Rectangle leftBox;
    }

}
