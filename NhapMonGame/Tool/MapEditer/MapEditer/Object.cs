using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapEditer.Properties;

namespace Contra_Map_Editor
{
    
    class Object
    {

        public int  _id,_type, _pos_x, _pos_y,_width,_height;
        public Object(int type, int Pos_X, int Pos_Y,int width,int height)
        {
            _type = type;
            _pos_x = Pos_X;
            _pos_y = Pos_Y;
            _width = width;
            _height = height;
        }

        public Image getImageByType()
        {
            Image image = new Bitmap(16,16);
            switch (_type)
            {
                case 0: image = MapEditer.Resource._0;
                    break;
                case 1: image =MapEditer.Resource._1;
                    break;
                case 2: image = MapEditer.Resource._2;
                    break;
                case 3: image = MapEditer.Resource._3;
                    break;
                case 4: image = MapEditer.Resource._4;
                    break;
                case 5: image = MapEditer.Resource._5;
                    break;
                case 6: image = MapEditer.Resource._6;
                    break;
                case 7: image = MapEditer.Resource._7;
                    break;
                case 8: image = MapEditer.Resource._8;
                    break;
                case 9: image = MapEditer.Resource._9;
                    break;
                case 10: image = MapEditer.Resource._10;
                    break;
                case 11: image = MapEditer.Resource._11;
                    break;
                case 12: image = MapEditer.Resource._12;
                    break;
                case 13: image = MapEditer.Resource._13;
                    break;
                case 14: image = MapEditer.Resource._14;
                    break;
                case 15: image = MapEditer.Resource._15;
                    break;
                case 16: image = MapEditer.Resource._16;
                    break;
                case 17: image = MapEditer.Resource._17;
                    break;
                case 18: image = MapEditer.Resource._18;
                    break;
                case 19: image = MapEditer.Resource._19;
                    break;
                case 20: image = MapEditer.Resource._20;
                    break;
            }
            return image;
        }

        public static Image getImageByType(int type)
        {
            Image image = new Bitmap(16,16);
            switch (type)
            {
                case 0: image = MapEditer.Resource._0;
                    break;
                case 1: image = MapEditer.Resource._1;
                    break;
                case 2: image = MapEditer.Resource._2;
                    break;
                case 3: image = MapEditer.Resource._3;
                    break;
                case 4: image = MapEditer.Resource._4;
                    break;
                case 5: image = MapEditer.Resource._5;
                    break;
                case 6: image = MapEditer.Resource._6;
                    break;
                case 7: image = MapEditer.Resource._7;
                    break;
                case 8: image = MapEditer.Resource._8;
                    break;
                case 9: image = MapEditer.Resource._9;
                    break;
                case 10: image = MapEditer.Resource._10;
                    break;
                case 11: image = MapEditer.Resource._11;
                    break;
                case 12: image = MapEditer.Resource._12;
                    break;
                case 13: image = MapEditer.Resource._13;
                    break;
                case 14: image = MapEditer.Resource._14;
                    break;
                case 15: image = MapEditer.Resource._15;
                    break;
                case 16: image = MapEditer.Resource._16;
                    break;
                case 17: image = MapEditer.Resource._17;
                    break;
                case 18: image = MapEditer.Resource._18;
                    break;
                case 19: image = MapEditer.Resource._19;
                    break;
                case 20: image = MapEditer.Resource._20;
                    break;

            }
            return image;
        }
    }
}
