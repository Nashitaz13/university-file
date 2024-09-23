using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Warehouses
{
    public class DtoWarehouse
    {
        private string _maKho;
        private string _tenKho;
        private bool _trangThai;
        private DateTime _ngayTao;
        private string _ghiChu;

        public string GhiChu
        {
            get { return _ghiChu; }
            set { _ghiChu = value; }
        }

        public string MaKho
        {
            get { return _maKho; }
            set { if (value.Length <=10) 
                    _maKho = value; }
        }

        public string TenKho
        {
            get { return _tenKho; }
            set
            {
                if (value.Length <= 100)
                    _tenKho = value;
            }
        }

        public bool TrangThai
        {
            get { return _trangThai; }
            set { _trangThai = value; }
        }

        public DateTime NgayTao
        {
            get { return _ngayTao; }
            set { _ngayTao = value; }
        }
    }
}
