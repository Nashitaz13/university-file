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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLyKhachSan.View.ContentView
{
    /// <summary>
    /// màn hình danh sách phòng
    /// </summary>
    public partial class ListRoom : UserControl
    {
        //them phong moi
        UpdateRoom updateListRoom;
        DataListRoom dataListRoom;
        public ListRoom()
        {
            InitializeComponent();
            Loaded += ListRoom_Loaded;
        }

        void ListRoom_Loaded(object sender, RoutedEventArgs e)
        {
            updateListRoom = new UpdateRoom();
            dataListRoom = new DataListRoom();
            dataListRoom.viewListRoom(ref this.listRoom);
        }

        public void addRoom()
        {
            contentEditRoom.Visibility = System.Windows.Visibility.Visible;
            contentEditRoom.Content = updateListRoom;
        }

        private void listRoom_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                try
                {
                    ViewDataRoom ite = (ViewDataRoom)listRoom.SelectedItem;
                    listRoom.Items.Remove(listRoom.SelectedItem);
                    dataListRoom.deleteRoom(ite.id);
                    MessageBox.Show("Xóa thành công", "Error", MessageBoxButton.OK);
                }
                catch
                {
                    MessageBox.Show("Thao tác bị lỗi", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void refresh()
        {
            listRoom.Items.Clear();
            try
            {
                if (this.updateListRoom.ready == true)
                    dataListRoom.testRoomExits(updateListRoom.name,
                    updateListRoom.typeRoom,
                    updateListRoom.price,
                    updateListRoom.note);
                this.updateListRoom.ready = false;
            }
            catch
            { 
            }
            dataListRoom.viewListRoom(ref listRoom);
        }
    }
}
