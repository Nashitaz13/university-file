using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyKhachSanEntity
{
    public class EC_ChiTietBaoCaoDoanhThu
    {
        private string _maChiTietBCDT;

        public string MaChiTietBCDT
        {
            get { return _maChiTietBCDT; }
            set { _maChiTietBCDT = value; }
        }
        private string _maBaoCao;

        public string MaBaoCao
        {
            get { return _maBaoCao; }
            set { _maBaoCao = value; }
        }
        private string _maLoaiPhong;

        public string MaLoaiPhong
        {
            get { return _maLoaiPhong; }
            set { _maLoaiPhong = value; }
        }
        private decimal _doanhThu;

        public decimal DoanhThu
        {
            get { return _doanhThu; }
            set { _doanhThu = value; }
        }
        private float _tyLe;

        public float TyLe
        {
            get { return _tyLe; }
            set { _tyLe = value; }
        }
    }
}
