using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mang1Chieu
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[50];
            int n;
            Mang1Chieu m = new Mang1Chieu();
            Console.Write("Nhap so phan tu trong mang: ");
            n = Int32.Parse(Console.ReadLine());
            Console.Write("Mang phan tu: ");
            m.Xuat(a, n); Console.WriteLine("");
            Console.WriteLine("Tong cac so le trong mang: {0}", m.TongSoLe(a, n));
            Console.Write("Cac so nguyen to trong mang: ");
            m.DemSNT(a,n);
            Console.Write("\nSo chinh phuong nho nhat: {0}", m.SCP(a,n));
            Console.ReadLine();
        }
    }
}
