using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKINTERNET.Public
{
    public class LichSuDichVuPublic
    {
        private string _MaLSDV;

        public string MaLSDV
        {
            get { return _MaLSDV; }
            set { _MaLSDV = value; }
        }
        private int _MaDV;

        public int MaDV
        {
            get { return _MaDV; }
            set { _MaDV = value; }
        }

        private DateTime _NgayTruyCap;

        public DateTime NgayTruyCap
        {
            get { return _NgayTruyCap; }
            set { _NgayTruyCap = value; }
        }

        private string _DiaChiTruyCap;

        public string DiaChiTruyCap
        {
            get { return _DiaChiTruyCap; }
            set { _DiaChiTruyCap = value; }
        }

        private int _LuuLuongSuDung;

        public int LuuLuongSuDung
        {
            get { return _LuuLuongSuDung; }
            set { _LuuLuongSuDung = value; }
        }

        private string _MaLLL;

        public string MaLLL
        {
            get { return _MaLLL; }
            set { _MaLLL = value; }
        }
       
    }
}
