using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Override
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle a = new Rectangle(5, 10);
            a.CalculateArea(); Console.Write("\n");
            a.CalculatePerimeter(); Console.Write("\n");
            Console.ReadLine();
        }
    }
}
