
using QLKS2014.BLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    /// màn hình danh sách phòng
    /// </summary>
    public partial class ListRoom : UserControl
    {
        //them phong moi
        UpdateRoom updateListRoom;

        public ListRoom()
        {
            InitializeComponent();
            Loaded += ListRoom_Loaded;
        }

        void ListRoom_Loaded(object sender, RoutedEventArgs e)
        {
            _initialize();
            
        }

        private void _initialize()
        {
            updateListRoom = new UpdateRoom();
            contentUpdateRoom.Content = updateListRoom;
        }

        private void addRoom()
        {
            Visibility current = contentUpdateRoom.Visibility;
            if(current == Visibility.Visible)
                contentUpdateRoom.Visibility = Visibility.Collapsed;
            else
                contentUpdateRoom.Visibility = Visibility.Visible;
        }

        public void showAddingRoom(bool show_)
        {
            if (show_)
            {
                contentUpdateRoom.Visibility = Visibility.Visible;
            }
            else
                addRoom();
        }


        public void refresh()
        {
            //listRoom.Items.Clear();
            //try
            //{
            //    if (this.updateListRoom.ready == true)
            //        dataListRoom.testRoomExits(updateListRoom.name,
            //        updateListRoom.typeRoom,
            //        updateListRoom.price,
            //        updateListRoom.note);
            //    this.updateListRoom.ready = false;
            //}
            //catch
            //{
            //}
            //dataListRoom.viewListRoom(ref listRoom);
        }

        private void dgRoom_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers == ModifierKeys.Shift) && e.Key == Key.Delete)
            {
                MessageBoxResult result = MessageBox.Show("Bạn có muốn xóa phòng này không?","Nhắc Nhở", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    DataGrid dgData = sender as DataGrid;
                    _deleteRooms(dgData);
                }
                return;
            }
        }



        private void _deleteRooms(DataGrid dgData)
        {
            IList selectedItems = dgData.SelectedItems;
            if (selectedItems == null)
                return;
            int size = selectedItems.Count;
            for(int i = size-1; i >=0;i--)
            {
                DataRowView item = selectedItems[i] as DataRowView;
                item.Delete();
            }
            
        }



        private void dgRoom_Drop(object sender, DragEventArgs e)
        {
            int i = 0;
        }

        private void dgRoom_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        
    }
}
