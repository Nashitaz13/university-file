using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mang2Chieu
{
    class Mang2Chieu
    {
        private int m, n;
        int[,] a = new int[100,100];

        public void Nhap()
        {
            Console.Write("Nhap so dong: ");
            m = Int32.Parse(Console.ReadLine());
            Console.Write("Nhap so cot: ");
            n = Int32.Parse(Console.ReadLine());
            for (int i = 0; i<m ; i++)
            {
                for (int j = 0 ; j<n ; j++)
                {
                    Console.Write("a[{0},{1}]: ", i + 1, j + 1);
                    a[i, j] = Int32.Parse(Console.ReadLine());
                }
            }
        }
        public void Xuat()
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0}\t",a[i, j]);
                    if (j == n-1)
                        Console.Write("\n");
                }
            }
        }
        public int TinhTong()
        {
            int s = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    s += a[i, j];
                }
            }
            return s;
        }
    }
}
