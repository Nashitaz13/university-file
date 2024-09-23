using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThoiGian
{
    class Program
    {
        static void Main(string[] args)
        {
            System.DateTime currentTime = 
            System.DateTime.Now;
            ThoiGian t1 = new ThoiGian( currentTime );
            t1.ThoiGianHienHanh();
            ThoiGian t2 = new ThoiGian(2001,7,3,10,5);
            t2.ThoiGianHienHanh();
            Console.ReadLine();
        }
    }
}
