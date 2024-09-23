using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Matrix
    {
        //private int[,] a = new int[50,50];
        //public int m,n;
        public void Xuat(int[,] a, int m, int n)
        {
            Random r = new Random();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = r.Next(0, 10);
                    Console.Write("{0} ", a[i, j]);
                    if (j == n - 1)
                        Console.WriteLine("");
                }
            }
        }
        public int Max(int[,] a, int m, int n)
        {
            int max=a[0,0];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (a[i, j] > max)
                        max = a[i, j];
                }
            }
            return max;
        }
        public int Min(int[,] a, int m, int n)
        {
            int min = a[0, 0];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (a[i, j] < min)
                        min = a[i, j];
                }
            }
            return min;
        }

        public int TongCacSoKhongPhaiLaSoNguyenTo(int[,] a, int m, int n)
        {
            int s = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (KTSNT(a[i,j]) == 0)
                        s += a[i, j];
                }
            }
            return s;
        }
        /*public int TimDongCoTongLonNhat(int[,] a, int m, int n)
        {
            int[] b = new int[50];
            int i = 0;
            int s = 0;
            do
            {
                for (int j = 0; j < n; j++)
                    s += a[i, j];
                b[i] = s;
                i++;
            }
            while (i < m);
            int max = b[0];
            for (int k = 0; k < m; k++)
            {
                if (b[k] > max)
                    max = b[k];
            }
            return max;
        }*/
        public int KTSNT(int a)
        {
            int i, ok = 1;
            if (a < 2) ok = 0;
            if (a == 2) ok = 1;
            if (a > 2)
            {
                for (i = 2; i * i <= a; i++)
                    if (a % i == 0) break;
                if (i * i <= a) ok = 0; else ok = 1;
            }
            return ok;
        }
    }
}
