using QuanLyKhachSan.ViewData;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace QuanLyKhachSan.ProcessData
{
    /// <summary>
    /// cai dat cac thong so cho chuong trinh
    /// them loai phong
    /// xoa loai phong
    /// them  loai khach
    /// xoa loai khach
    /// </summary>
    public class DataSetting
    {
        //tao chuoi ket noi du lieu
        public SqlCeConnection connectionData;
        public DataTypeRoom dataTypeRoom;
        public DataCustomer dataCustomer;
        /// <summary>
        /// khoi tao mot chuoi ket noi
        /// </summary>
        public DataSetting()
        {
            connectionData = new SqlCeConnection(Properties.Settings.Default.QUANLYKHACHSANConnectionString1);
            dataTypeRoom = new DataTypeRoom();
            dataCustomer = new DataCustomer();
        }

        /// <summary>
        /// hien thi danh sach cac loai phong
        /// </summary>
        /// <param name="listView">control hien thi ra man hinh</param>
        public void viewDataTypeRoom(ref ListView listView)
        {
            //xoa cac items cu
            listView.Items.Clear();
            try
            {
                ///mo ket noi
                connectionData.Open();
            }
            catch
            {
            }
            try
            {
                string cmdText = "SELECT * FROM LOAIPHONG";
                using (SqlCeCommand cmdViewData = new SqlCeCommand(cmdText, connectionData))
                {
                    SqlCeDataReader reader = cmdViewData.ExecuteReader();
                    int index = 1;
                    while (reader.Read())
                    {
                        ViewDataSettingTypeRoom item = new ViewDataSettingTypeRoom();
                        item.index = index;
                        item.idTypeRoom = int.Parse(reader["MaLoaiPhong"].ToString());
                        item.maxCustomer = int.Parse(reader["SoKhachToiDa"].ToString());
                        item.price = decimal.Parse(reader["DonGia"].ToString());
                        item.nameTypeRoom = reader["TenLoaiPhong"].ToString();
                        listView.Items.Add(item);
                        index++;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// hien thi loai khach len list view
        /// </summary>
        /// <param name="listView"></param>
        public void viewDataTypeCustomer(ref ListView listView)
        {
            //xoa cac items cu
            try
            {
                listView.Items.Clear();
            }
            catch
            { }
            try
            {
                ///mo ket noi
                connectionData.Open();
            }
            catch
            {
            }
            string cmdText = "SELECT * FROM LOAIKHACH";
            int index = 0;
            using (SqlCeCommand cmdGetValue = new SqlCeCommand(cmdText, connectionData))
            {
                SqlCeDataReader reader = cmdGetValue.ExecuteReader();
                while (reader.Read())
                {
                    index++;
                    ViewDataSettingTypeCustomer item = new ViewDataSettingTypeCustomer();
                    item.index = index;
                    item.id = (int)reader["MaLoaiKhach"];
                    item.name = reader["TenLoaiKhach"].ToString();
                    item.rateSurcharge =float.Parse(reader["TiLePhuThu"].ToString());
                    listView.Items.Add(item);
                }
            }
            connectionData.Close();
        }
    }
}
