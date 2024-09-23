using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyKhachSanEntity
{
    public class EC_ThamSo
    {
        private string _maThamSo;

        public string MaThamSo
        {
            get { return _maThamSo; }
            set { _maThamSo = value; }
        }
        private string _tenThamSo;

        public string TenThamSo
        {
            get { return _tenThamSo; }
            set { _tenThamSo = value; }
        }
        private string _giaTri;

        public string GiaTri
        {
            get { return _giaTri; }
            set { _giaTri = value; }
        }
    }
}
