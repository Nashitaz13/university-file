using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanSo
{
    class Program
    {
        static void Main(string[] args)
        {
            PhanSo a = new PhanSo(0,1);
            PhanSo b = new PhanSo(0,1);
            a.Nhap(); Console.Write("\n");
            b.Nhap(); Console.Write("\n");
            Console.Write("Phan so A: "); a.RutGon(); a.Xuat(); Console.Write("\n");
            Console.Write("Phan so B: "); b.RutGon(); b.Xuat(); Console.Write("\n");
            Console.WriteLine("A + B = {0}", a + b);
            Console.WriteLine("A - B = {0}", a - b);
            Console.WriteLine("A * B = {0}", a * b);
            Console.WriteLine("A / B = {0}", a / b);
            Console.WriteLine("A + 5 = {0}", a + 5);
            if (a == b)
                Console.Write("A = B");
            //else
            //    Console.Write("A!=B");
            if (a > b)
                Console.Write("A>B");
            if (a<b)
                Console.Write("A<B");
            Console.ReadLine();
        }
    }
}
