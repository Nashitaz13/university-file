using QuanLySieuThiDienThoai.DAO;
using QuanLySieuThiDienThoai.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThiDienThoai.BLL
{
    class TTXuatBll
    {
        private static TTXuatDao data = new TTXuatDao();
        public List<TTXuat> layTTXuat()
        {
            return data.layTTXuat();
        }
    }
}
