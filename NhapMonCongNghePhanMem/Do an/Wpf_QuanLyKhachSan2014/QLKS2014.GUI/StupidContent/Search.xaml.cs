
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
    /// cửa sổ tìm kiếm
    /// </summary>
    public partial class Search : UserControl
    {
        SearchByTime searchByTime;
        SearchByRoom searchByRoom;

        public Search()
        {
            InitializeComponent();
            Loaded += Search_Loaded;
        }

        void Search_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void listboxTypeSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbboxTypeSearch.SelectedIndex)
            {
                case 0:
                    searchByTime = new SearchByTime();
                    contentTypeSearch.Content = searchByTime;
                    break;
                case 1:
                    searchByRoom = new SearchByRoom();
                    contentTypeSearch.Content = searchByRoom;
                    break;
                default:
                    break;
            }
        }

    }
}
