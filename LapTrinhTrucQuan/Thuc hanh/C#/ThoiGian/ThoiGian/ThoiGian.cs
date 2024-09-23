using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThoiGian
{
    class ThoiGian
    {
        int Ngay, Thang, Nam, Gio, Phut, Giay;
        public void ThoiGianHienHanh()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine("Hien tai: \t {0}/{1}/{2} {3}:{4}:{5}", now.Day, now.Month, now.Year, now.Hour, now.Minute, now.Second);
            Console.WriteLine("Hien tai: \t {0}/{1}/{2} {3}:{4}:{5}", Ngay, Thang, Nam, Gio, Phut, Giay);
        }
        public ThoiGian(System.DateTime dt)
        {
            Nam = dt.Year; Thang = dt.Month; Ngay = dt.Day;
            Gio = dt.Hour; Phut = dt.Minute;
            Giay = dt.Second;
        }
        public ThoiGian(int Year, int Month, int Date, int Hour, int Minute)
        {
            Nam = Year;Thang = Month;Ngay = Date;
            Gio = Hour;Phut = Minute;
        }
      }
}
