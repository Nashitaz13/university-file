using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS2014.PUBLIC
{
    public class ChiTietBaoCaoDoanhThuPublic
    {
        private int _maChiTietBaoCaoDoanhThu;

        public int MaChiTietBaoCaoDoanhThu
        {
            get { return _maChiTietBaoCaoDoanhThu; }
            set { _maChiTietBaoCaoDoanhThu = value; }
        }
        private int _maBaoCao;

        public int MaBaoCao
        {
            get { return _maBaoCao; }
            set { _maBaoCao = value; }
        }
        private int _maLoaiPhong;

        public int MaLoaiPhong
        {
            get { return _maLoaiPhong; }
            set { _maLoaiPhong = value; }
        }
        private float _tyLe;

        public float TyLe
        {
            get { return _tyLe; }
            set { _tyLe = value; }
        }
        private decimal _doanhThu;

        public decimal DoanhThu
        {
            get { return _doanhThu; }
            set { _doanhThu = value; }
        }
    }
}
