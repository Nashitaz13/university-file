
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLKS2014.GUI.StupidContent
{
    /// <summary>
    ///màn hình báo cáo
    /// </summary>
    public partial class Report : UserControl
    {
        //DataReport dataReport;
        public Report()
        {
            InitializeComponent();
            Loaded += Report_Loaded;
        }

        void Report_Loaded(object sender, RoutedEventArgs e)
        {
            //dataReport = new DataReport();
            //this.lbDateBuild.Content = DateTime.Now.ToString();
        }

        private void btnBuildReport_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    if (string.IsNullOrEmpty(this.tbName.Text))
            //        return;
            //    dataReport.addNewReport(DateTime.Now, this.tbName.Text, ref this.lstRoomReport);
            //    MessageBox.Show("Lưu lại thành công", "Lưu dữ liệu", MessageBoxButton.OK);
            //}
            //catch
            //{
            //    MessageBox.Show("Thao tcá bị lỗi", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}

        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Enter)
            //{
            //    try
            //    {
            //        if (string.IsNullOrEmpty(this.tbName.Text))
            //            return;
            //        dataReport.addNewReport(DateTime.Now, this.tbName.Text, ref this.lstRoomReport);
            //    }
            //    catch
            //    { }
            //}
        }
    }
}
