using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDKINTERNET.Public
{
    public class HoaDonThanhToanPublic
    {
        private string _MaHDTT;

        public string MaHDTT
        {
            get { return _MaHDTT; }
            set { _MaHDTT = value; }
        }
        private int _MaDV;

        public int MaDV
        {
            get { return _MaDV; }
            set { _MaDV = value; }
        }
        private int _TinhTrangThanhToan;

        public int TinhTrangThanhToan
        {
            get { return _TinhTrangThanhToan; }
            set { _TinhTrangThanhToan = value; }
        }
        private int _CuocPhi;

        public int CuocPhi
        {
            get { return _CuocPhi; }
            set { _CuocPhi = value; }
        }
        private DateTime _CuocTuNgay;

        public DateTime CuocTuNgay
        {
            get { return _CuocTuNgay; }
            set { _CuocTuNgay = value; }
        }
        private DateTime _CuocDenNgay;

        public DateTime CuocDenNgay
        {
            get { return _CuocDenNgay; }
            set { _CuocDenNgay = value; }
        }

    }
}
