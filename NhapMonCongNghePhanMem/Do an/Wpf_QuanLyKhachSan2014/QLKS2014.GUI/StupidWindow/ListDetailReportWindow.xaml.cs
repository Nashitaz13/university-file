
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QLKS2014.GUI.StupidWindow
{
    /// <summary>
    /// Interaction logic for ListDetailReport.xaml
    /// </summary>
    public partial class ListDetailReportWindow : Window
    {
        public int idReport;

        public ListDetailReportWindow(int idReport_)
        {
            InitializeComponent();
            idReport = idReport_;
            //getValue();
            Loaded += ListDetailReport_Loaded;
        }

        void ListDetailReport_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void getValue()
        {
            //SqlCeConnection connectionData = new SqlCeConnection(Properties.Settings.Default.QUANLYKHACHSANConnectionString1);
            //connectionData.Open();
            //string cmdText = "SELECT * FROM CHITIETBAOCAODOANHTHU WHERE MaBaoCao = " + idReport;
            //SqlCeCommand cmdGetValue = new SqlCeCommand(cmdText, connectionData);
            //SqlCeDataReader reader = cmdGetValue.ExecuteReader();
            //while (reader.Read())
            //{
            //    try
            //    {
            //        ViewDetailReport item = new ViewDetailReport();
            //        item.nameTypeRoom = DataListRoom.getNameTypeRoom(reader["MaLoaiPhong"].ToString());
            //        item.totalMoney = (decimal)reader["DoanhThu"];
            //        item.percent = float.Parse(reader["TyLe"].ToString());
            //        this.listDetailReport.Items.Add(item);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.ToString());
            //    }
            //}
            //connectionData.Close();
        }

        private void dgReportDetail_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dgReportDetail_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }
    }
}
