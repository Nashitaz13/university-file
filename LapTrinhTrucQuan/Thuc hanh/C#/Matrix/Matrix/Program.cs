using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] a = new int[50, 50];
            int m,n;
            Matrix k = new Matrix();
            Console.Write("Nhap so dong: ");
            m = Int32.Parse(Console.ReadLine());
            Console.Write("Nhap so cot: ");
            n = Int32.Parse(Console.ReadLine());
            k.Xuat(a,m,n);
            Console.WriteLine("Phan tu lon nhat: {0}", k.Max(a,m,n));
            Console.WriteLine("Phan tu nho nhat: {0}", k.Min(a, m, n));
            Console.WriteLine("Tong cac so khong phai la so nguyen to: {0}", k.TongCacSoKhongPhaiLaSoNguyenTo(a, m, n));
            //Console.WriteLine("Dong co tong lon nhat: {0}", k.TimDongCoTongLonNhat(a, m, n));
            Console.ReadLine();
        }
    }
}
