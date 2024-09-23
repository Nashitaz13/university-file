using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS2014.PUBLIC
{
    public class BaoCaoDoanhThuPublic
    {
        private int _maBaoCao;

        public int MaBaoCao
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
