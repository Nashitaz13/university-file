using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mang1Chieu
{
    class Mang1Chieu
    {
        public void Xuat(int[] a, int n)
        {
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                a[i] = r.Next(0, 100);
                Console.Write("{0} ", a[i]);
            }
        }
        public int TongSoLe(int[] a, int n)
        {
            int s = 0;
            for (int i = 0; i < n; i++)
            {
                if (a[i] % 2 != 0)
                    s += a[i];
            }
            return s;
        }
        public void DemSNT(int[] a, int n)
        {
            int d = 0;
            for (int i = 0; i < n; i++)
            {
                if (KTSNT(a[i])==1)
                {
                    Console.Write("{0} ", a[i]);
                    d++;
                }
            }
            if (d == 0)
                Console.Write("\nKhong co so nguyen to nao!");
            Console.Write("\nTong so so nguyen to: {0}", d);

        }
        public int SCP(int[] a, int n)
        {
            int x = 0;
            int[] scp = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (KTSCP(a[i]))
                {
                    scp[x] = a[i];
                    x++;
                }
            }
            int min = scp[0];
            for (int i = 0; i < x; i++)
            {
                if (scp[i] < min)
                    min = scp[i];
            }
            return min;
        }
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
        public bool KTSCP(int a)
        {
            return ((int)Math.Sqrt(a) * (int)Math.Sqrt(a) == a) ;
        }
    }
}
