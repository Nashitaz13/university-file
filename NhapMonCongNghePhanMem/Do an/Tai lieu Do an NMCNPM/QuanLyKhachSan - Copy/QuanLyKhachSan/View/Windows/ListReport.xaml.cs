using QuanLyKhachSan.ProcessData;
using QuanLyKhachSan.ViewData;
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

namespace QuanLyKhachSan.View.Windows
{
    /// <summary>
    /// Interaction logic for ListReport.xaml
    /// </summary>
    public partial class ListReport : Window
    {
        DataReport dataReport;
        public ListReport()
        {
            InitializeComponent();
            Loaded += ListReport_Loaded;
        }

        void ListReport_Loaded(object sender, RoutedEventArgs e)
        {
            dataReport = new DataReport();
            dataReport.viewData(ref this.listReport);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                viewDetail();
        }

        private void listReport_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            viewDetail();
        }

        private void viewDetail()
        {
            try
            {
                ViewDataReport item = (ViewDataReport)this.listReport.SelectedItem;
                ListDetailReport detailReport = new ListDetailReport(item.idReport);
                //detailReport.idReport = item.idReport;
                detailReport.Show();
            }
            catch
            { }
            
        }
    }
}
