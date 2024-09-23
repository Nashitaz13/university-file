using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mang2Chieu
{
    class Program
    {
        static void Main(string[] args)
        {
            Mang2Chieu p = new Mang2Chieu();
            p.Nhap(); Console.Write("\n");
            p.Xuat(); Console.Write("\n");
            Console.Write("Tong cac phan tu : s = {0}",p.TinhTong());
            Console.ReadLine();
        }
    }
}
