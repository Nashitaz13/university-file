using System;
using System.Collections.Generic;
using System.Text;


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
///
/// XNA_RPG textMapEditor engine được viết bởi HuyetSat - Xvna.forumb.biz
/// Mọi cập nhật hay thắc mắc ý kiến về engine xin liên hệ tại: xvna.forumb.biz hoặc thanh_vinh648@yahoo.com
/// Engine hoàn toàn free và nó cho phép các bạn phát triển được RPG một cách dễ dàng!
/// Chân thành cảm ơn bạn đã quan tâm sử dụng engine này!
///
namespace XNA_RPG_textMapEditor.Helper
{
    class RDHelper
    {
        public static Random RandomGenerator = new Random();

        public static Vector3 GeneratePositionXY(int distance)
        {
            int scaledDistance = distance * 10;
            float posX = (RandomGenerator.Next(2 * scaledDistance + 1) - scaledDistance) * 0.1f;
            float posZ = (RandomGenerator.Next(2 * scaledDistance + 1) - scaledDistance) * 0.1f;

            return new Vector3(posX, 0, posZ);
        }
        public static int GetRandomInt(int num)
        {
            RandomGenerator.GetHashCode();
            return RandomGenerator.Next(num);
        }
    }
}
