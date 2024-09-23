using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextDay
{
    class NextDay
    {
        private int ngay, thang, nam;
        public void Nhap()
        {
            do
            {
                Console.Write("Nhap ngay: "); ngay = Int32.Parse(Console.ReadLine());
                Console.Write("Nhap thang: "); thang = Int32.Parse(Console.ReadLine());
                Console.Write("Nhap nam: "); nam = Int32.Parse(Console.ReadLine());
                if (thang < 1 || thang > 12)
                    Console.WriteLine("Thoi gian khong hop le. Nhap lai!");
                if (thang == 2)
                {
                    if (NamNhuan())
                    {
                        if (ngay < 1 || ngay > 29)
                            Console.WriteLine("Thoi gian khong hop le. Nhap lai!");
                    }
                    else
                    {
                        if (ngay < 1 || ngay > 28)
                            Console.WriteLine("Thoi gian khong hop le. Nhap lai!");
                    }
                }
                if (thang == 1 || thang == 3 || thang == 5 || thang == 7 || thang == 8 || thang == 10 || thang == 12)
                {
                    if (ngay < 1 || ngay > 31)
                        Console.WriteLine("Thoi gian khong hop le. Nhap lai!");
                }
                if (thang == 4 || thang == 6 || thang == 9 || thang == 11)
                {
                    if (ngay < 1 || ngay > 30)
                        Console.WriteLine("Thoi gian khong hop le. Nhap lai!");
                }
            }
            while ((thang < 1 || thang > 12)
                || (thang == 2 && NamNhuan() && (ngay < 1 || ngay > 29))
                || (thang==2 && (!(NamNhuan()) && (ngay < 1 || ngay > 28))
                || ((thang == 1 || thang == 3 || thang == 5 || thang == 7 || thang == 8 || thang == 10 || thang == 12) && (ngay < 1 || ngay > 31))
                || ((thang == 4 || thang == 6 || thang == 9 || thang == 11) && (ngay < 1 || ngay > 30))));
        }
        public void OutputNextDay()
        {
            if (ngay<28)
                Console.Write("Ngay tiep theo: {0}/{1}/{2}", ngay + 1, thang, nam);
            switch (ngay)
            {
                case 28:
                    {
                        if (thang == 2)
                        {
                            if (NamNhuan())
                                Console.Write("Ngay tiep theo: {0}/{1}/{2}", ngay + 1, thang, nam);
                            else
                                Console.Write("Ngay tiep theo: {0}/{1}/{2}", 1, thang + 1, nam);
                        }
                        if (thang != 2)
                            Console.Write("Ngay tiep theo: {0}/{1}/{2}", ngay + 1, thang, nam);
                    }
                    break;
                case 29:
                    {
                        if (thang == 2)
                            Console.Write("Ngay tiep theo: {0}/{1}/{2}", 1, thang + 1, nam);
                        else
                            Console.Write("Ngay tiep theo: {0}/{1}/{2}", ngay + 1, thang, nam);
                    }
                    break;
                case 30:
                    {
                        if (thang == 4 || thang == 6 || thang == 9 || thang == 11)
                            Console.Write("Ngay tiep theo: {0}/{1}/{2}", 1, thang + 1, nam);
                        else
                            Console.Write("Ngay tiep theo: {0}/{1}/{2}", ngay + 1, thang, nam);
                    }
                    break;
                case 31:
                    {
                        if (thang == 12)
                            Console.Write("Ngay tiep theo: {0}/{1}/{2}", 1, 1, nam + 1);
                        else
                            Console.Write("Ngay tiep theo: {0}/{1}/{2}", 1, thang + 1, nam);
                    }
                    break;
            }
        }
        bool NamNhuan()
        {
            return ((nam % 4 == 0 && nam % 100 != 0) || nam % 400 == 0);
        }
    }
}
