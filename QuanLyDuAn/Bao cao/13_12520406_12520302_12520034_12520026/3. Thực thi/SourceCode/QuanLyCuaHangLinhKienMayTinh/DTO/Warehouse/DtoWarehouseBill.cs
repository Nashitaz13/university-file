using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Warehouse
{
    public class DtoWarehouseBill
    {
        private string _maPhieuNhapKho;
        private DateTime _ngayLapPhieu;
        private string _maNguoiLapPhieu;
        private string _ghiChu;

        public string GhiChu
        {
            get { return _ghiChu; }
            set
            {
                if (value.Length < 100)
                    _ghiChu = value;
            }
        }

        public string MaNguoiLapPhieu
        {
            get { return _maNguoiLapPhieu; }
            set
            {
                if (value.Length < 10)
                    _maNguoiLapPhieu = value;
            }
        }

        public DateTime NgayLapPhieu
        {
            get { return _ngayLapPhieu; }
            set { _ngayLapPhieu = value; }
        }

        public string MaPhieuNhapKho
        {
            get { return _maPhieuNhapKho; }
            set { if (value.Length < 10) _maPhieuNhapKho = value; }
        }
    }
}
