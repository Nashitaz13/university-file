using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanSo
{   
    class PhanSo
    {
        private int tu;
        private int mau;

        public PhanSo(int t, int m)
        {
            tu = t;
            mau = m;
            RutGon();
        }
        public PhanSo(int t)
        {
            tu = t;
            mau = 1;
            RutGon();
        }
        //Hàm ẩn PhanSo -> Int
        public static implicit operator PhanSo(int theInt)
        {
            return new PhanSo(theInt);
        }
        //public static explicit operator int(PhanSo a)
        //{
        //    return a.tu / a.mau;
        //}
        public void Nhap()
        {
            do
            {
                Console.Write("Nhap phan so: \nNhap tu: ");
                tu = Int32.Parse(Console.ReadLine());
                Console.Write("Nhap mau: ");
                mau = Int32.Parse(Console.ReadLine());
                if (mau == 0)
                    Console.Write("Nhap lai!");
            }
            while (mau == 0);
        }
        public void Xuat()
        {
            if (mau == 1)
                Console.Write("{0}", tu);
            else
                Console.Write("{0}/{1}", tu, mau);
        }
        public static bool operator == (PhanSo a, PhanSo b)
        {
            return (a.tu == b.tu && a.mau == b.mau);
        }
        public static bool operator !=(PhanSo a, PhanSo b)
        {
            return !(a == b);
        }
        public static bool operator >(PhanSo a, PhanSo b)
        {
            if ((1.0*a.tu / a.mau) > (1.0*b.tu / b.mau))
                return true;
            else
                return false;
        }
        public static bool operator <(PhanSo a, PhanSo b)
        {
            if ((1.0 * a.tu / a.mau) < (1.0 * b.tu / b.mau))
                return true;
            else
                return false;
        }
        public static PhanSo operator + (PhanSo a, PhanSo b)
        {

            return new PhanSo(a.tu * b.mau + b.tu * a.mau , a.mau * b.mau);
        }
        public static PhanSo operator - (PhanSo a, PhanSo b)
        {

            return new PhanSo(a.tu * b.mau - b.tu * a.mau, a.mau * b.mau);
        }
        public static PhanSo operator *(PhanSo a, PhanSo b)
        {

            return new PhanSo(a.tu * b.tu, a.mau * b.mau);
        }
        public static PhanSo operator / (PhanSo a, PhanSo b)
        {

            return new PhanSo(a.tu * b.mau, a.mau * b.tu);
        }
        public override string ToString()
        {
            string s = tu.ToString() + "/" + mau.ToString();
            return s;
        }
        public int UCLN(int a, int b)
        {
            int r;
            if (a < 0)
                a = -a;
            if (b < 0)
                b = -b;
            while (a * b != 0)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            r = a + b;
            return r;
        }
        public void RutGon()
        {
            int UocChung = UCLN(tu, mau);
            tu /= UocChung;
            mau /= UocChung;
        }
    }
}
