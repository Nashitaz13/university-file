using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextDay
{
    class Program
    {
        static void Main(string[] args)
        {
            NextDay nd = new NextDay();
            nd.Nhap();
            nd.OutputNextDay();
            Console.ReadLine();
        }
    }
}
