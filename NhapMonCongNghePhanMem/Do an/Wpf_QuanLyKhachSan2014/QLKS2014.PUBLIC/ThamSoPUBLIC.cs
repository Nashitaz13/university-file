using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS2014.PUBLIC
{
    public class ThamSoPublic
    {
        private int _maThamSo;

        public int MaThamSo
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
        private float _giaTri;

        public float GiaTri
        {
            get { return _giaTri; }
            set { _giaTri = value; }
        }
    }
}
