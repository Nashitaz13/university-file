using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyKhachSanEntity
{
    public class EC_BaoCaoDoanhThu
    {
        private string _maBaoCao;

        public string MaBaoCao
        {
            get { return _maBaoCao; }
            set { _maBaoCao = value; }
        }
        private string _tenBaoCao;

        public string TenBaoCao
        {
            get { return _tenBaoCao; }
            set { _tenBaoCao = value; }
        }
        private DateTime _ngayLap;

        public DateTime NgayLap
        {
            get { return _ngayLap; }
            set { _ngayLap = value; }
        }
        private int _thangBaoCao;

        public int ThangBaoCao
        {
            get { return _thangBaoCao; }
            set { _thangBaoCao = value; }
        }

    }
}
