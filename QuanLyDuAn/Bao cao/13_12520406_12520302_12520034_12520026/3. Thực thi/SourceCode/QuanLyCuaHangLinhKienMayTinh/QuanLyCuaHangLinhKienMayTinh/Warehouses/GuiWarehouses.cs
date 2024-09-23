using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.Warehouses;
using CommonLayer;
using DTO.Warehouses;

namespace QuanLyCuaHangLinhKienMayTinh.Warehouses
{
    public partial class GuiWarehouses : Form
    {
        // properties
        private BalWarehouses _balWarehouses;

        public GuiWarehouses()
        {
            InitializeComponent();
            _balWarehouses = new BalWarehouses();

        }

        private async void Warehouses_Load(object sender, EventArgs e)
        {
            await FillDataTable();

        }

        private async Task FillDataTable()
        {
            int index = 0;
            foreach (DataRow row in _balWarehouses.GetListWarehouses().Rows)
            {
                DtoWarehouse data = new DtoWarehouse();
                data.MaKho = row[0].ToString();
                data.TenKho = row[1].ToString();
                data.TrangThai = CommonFunction.IntToBool(row[2].ToString());
                data.NgayTao = DateTime.Parse(row[3].ToString());
                data.GhiChu = row[4].ToString();
                dgList.Rows.Add(data.MaKho, data.TenKho, data.TrangThai, data.NgayTao, data.GhiChu);
                index++;
            }
        }

        private void Clear()
        {
            dgList.Rows.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GuiAddWarehouse addW = GuiAddWarehouse.GetInstance();
            addW.Closing += AddW_Closing;
            addW.ShowDialog();
        }

        private async void AddW_Closing(object sender, CancelEventArgs e)
        {
            Clear();
            await FillDataTable();
        }
    }
}

