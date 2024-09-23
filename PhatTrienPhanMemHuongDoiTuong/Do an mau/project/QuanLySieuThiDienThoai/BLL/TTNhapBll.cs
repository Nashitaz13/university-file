using QuanLySieuThiDienThoai.DAO;
using QuanLySieuThiDienThoai.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThiDienThoai.BLL
{
    class TTNhapBll
    {
        private static TTNhapDao data = new TTNhapDao();
        public List<TTNhap> layTTNhap()
        {
            return data.layTTNhap();
        }
    }
}
