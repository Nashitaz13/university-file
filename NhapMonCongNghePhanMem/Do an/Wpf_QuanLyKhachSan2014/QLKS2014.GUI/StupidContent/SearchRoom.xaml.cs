
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
    public partial class SearchRoom : UserControl
    {
        SearchByTime searchByTime;
        SearchByRoomType searchByRoom;

        public SearchRoom()
        {
            InitializeComponent();
            Loaded += Search_Loaded;
        }

        void Search_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void cbbSearchType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbbSearchType.SelectedIndex)
            {
                case 0:
                    searchByTime = new SearchByTime();
                    ccSearchType.Content = searchByTime;
                    break;
                case 1:
                    searchByRoom = new SearchByRoomType();
                    ccSearchType.Content = searchByRoom;
                    break;
                default:
                    break;
            }
        }

    }
}
