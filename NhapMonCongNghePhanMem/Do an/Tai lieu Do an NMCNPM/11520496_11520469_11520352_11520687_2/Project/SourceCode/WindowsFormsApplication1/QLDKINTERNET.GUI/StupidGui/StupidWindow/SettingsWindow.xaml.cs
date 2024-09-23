using QLDKINTERNET.BLL;
using QLDKINTERNET.GUI.StupidUtils;
using QLDKINTERNET.Public;
using System;
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
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace QLDKINTERNET.GUI.StupidGui.StupidWindow
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(SettingsWindow_Loaded);
        }

        private void SettingsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _initialize_gbModem();
            _initialize_gbKieuCaiDat();
            _initialize_gbGoiCuoc();
           
        }

        private void _initialize_gbGoiCuoc()
        {
            //clear data
            lvGoiCuoc.Items.Clear();

            //init lv
            GoiCuocBLL goiCuocBll = new GoiCuocBLL();
            DataTable dtGoiCuoc = goiCuocBll.GoiCuoc_SelectAll();
            List<GoiCuocPublic> lGoiCuocPublic;
            lGoiCuocPublic = new List<GoiCuocPublic>(
               (from dRow in dtGoiCuoc.AsEnumerable()
                select (UtilsGui.dataRowToGoiCuocPublic(dRow)))
               );

            List<GoiCuocPublic>.Enumerator etor = lGoiCuocPublic.GetEnumerator();
            int i = 0;
            while (etor.MoveNext())
            {
                GoiCuocGui goiCuoc = new GoiCuocGui();
                goiCuoc.Index = ++i;
                goiCuoc.MaGoiCuoc = etor.Current.MaGoiCuoc;
                goiCuoc.TenGoiCuoc = etor.Current.TenGoiCuoc;
                goiCuoc.GiaTronGoi = etor.Current.GiaTronGoi;
                lvGoiCuoc.Items.Add(goiCuoc);
            }

        }

        private void _initialize_gbKieuCaiDat()
        {
            //clear data
            lvKieuCaiDat.Items.Clear();

            // init lv
            KieuCaiDatBLL kieuCaiDatBll = new KieuCaiDatBLL();
            DataTable dtKieuCaiDat = kieuCaiDatBll.SelectKieuCaiDat();
            List<KieuCaiDatPublic> lKieuCaiDatPublic;
            lKieuCaiDatPublic = new List<KieuCaiDatPublic>(
               (from dRow in dtKieuCaiDat.AsEnumerable()
                select (UtilsGui.dataRowToKieuCaiDatPublic(dRow)))
               );

            List<KieuCaiDatPublic>.Enumerator etor = lKieuCaiDatPublic.GetEnumerator();
            int i = 0;
            while (etor.MoveNext())
            {
                KieuCaiDatGui kieuCaiDat = new KieuCaiDatGui();
                kieuCaiDat.Index = ++i;
                kieuCaiDat.MaKieuCaiDat = etor.Current.MaKieuCaiDat;
                kieuCaiDat.TenKieuCaiDat = etor.Current.TenKieuCaiDat;
                kieuCaiDat.GiaKieuCaiDat = etor.Current.GiaKieuCaiDat;
                lvKieuCaiDat.Items.Add(kieuCaiDat);
            }
        }

        private void _initialize_gbModem()
        {
            // clear lvModem
            lvModem.Items.Clear();

            // init lvModem
            ModemBLL modemBll = new ModemBLL();
            DataTable dtModem = modemBll.Modem_SelectAll();
            List<ModemPublic> lModemPublic;
            lModemPublic = new List<ModemPublic>(
               (from dRow in dtModem.AsEnumerable()
                select (UtilsGui.dataRowToModemPublic(dRow)))
               );

            List<ModemPublic>.Enumerator etor = lModemPublic.GetEnumerator();
            int i = 0;
            while (etor.MoveNext())
            {
                ModemGui modem = new ModemGui();
                modem.Index = ++i;
                modem.MaModem = etor.Current.MaModem;
                modem.TenModem = etor.Current.TenModem;
                modem.GiaModem = etor.Current.GiaModem;
                lvModem.Items.Add(modem);
            }
        }

        private void lvModem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                // Get selected item
                ModemGui modem = lvModem.SelectedItem as ModemGui;
                
                // Delete data in sql
                //ModemPublic modemPl = modem;
                //ModemBLL modemBll = new ModemBLL();
                //modemBll.

                // Delete dta in view
                lvModem.Items.RemoveAt(lvModem.SelectedIndex);

                // Reload view
                _initialize_gbModem();
            }
        }

        private void gbModemSetting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnThemModem_Click(sender, e);
        }

        private void txtbGiaModem_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnThemModem_Click(object sender, RoutedEventArgs e)
        {
            ModemPublic modem = new ModemPublic();
            modem.TenModem = txtbTenModem.Text;
            modem.MaModem = txtbTenModem.Text;
            modem.GiaModem = int.Parse(txtbGiaModem.Text);
            ModemBLL modemBll = new ModemBLL();
            modemBll.ThemModem(modem);

            _initialize_gbModem();
        }


        private void gbKieuCaiDat_KeyDow(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnThemKieuCaiDat_Click(sender, e);
        }

        private void txtbGiaKieuCaiDat_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnThemKieuCaiDat_Click(object sender, RoutedEventArgs e)
        {
            // tao kieu cai dat
            KieuCaiDatPublic kieuCaiDat = new KieuCaiDatPublic();
            kieuCaiDat.TenKieuCaiDat = txtbTenKieuCaiDat.Text;
            kieuCaiDat.MaKieuCaiDat = txtbTenKieuCaiDat.Text;
            kieuCaiDat.GiaKieuCaiDat = int.Parse(txtbGiaKieuCaiDat.Text);

            // luu len sql
            KieuCaiDatBLL kieuCaiDatBll = new KieuCaiDatBLL();
            kieuCaiDatBll.ThemKieuCaiDat(kieuCaiDat);

            // Cap nhat len giao dien
            _initialize_gbKieuCaiDat();
        }


        private void lvKieuCaiDat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                // Get selected item
                KieuCaiDatGui kieuCaiDat = lvKieuCaiDat.SelectedItem as KieuCaiDatGui;

                // Delete data in sql
                //KieuCaiDatPublic kieuCaiDatPl = kieuCaiDat;
                //KieuCaiDatBLL kieuCaiDatBll = new KieuCaiDatBLL();
                //kieuCaiDatBll.

                // Delete dta in view
                lvKieuCaiDat.Items.RemoveAt(lvKieuCaiDat.SelectedIndex);

                // Reload view
                _initialize_gbKieuCaiDat();
            }
        }

        private void gbGoiCuoc_KeyDow(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnThemGoiCuoc_Click(sender, e);
        }

        private void btnThemGoiCuoc_Click(object sender, RoutedEventArgs e)
        {
            // tao kieu cai dat
            GoiCuocPublic goiCuoc = new GoiCuocPublic();
            goiCuoc.TenGoiCuoc = txtbTenGoiCuoc.Text;
            goiCuoc.MaGoiCuoc = txtbTenGoiCuoc.Text;
            goiCuoc.GiaTronGoi = int.Parse(txtbGiaTronGoi.Text);

            // luu len sql
            GoiCuocBLL goiCuocBll = new GoiCuocBLL();
            goiCuocBll.ThemGoiCuoc(goiCuoc);

            // Cap nhat len giao dien
            _initialize_gbGoiCuoc();
        }

        private void lvGoiCuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                // Get selected item
                GoiCuocGui goiCuoc = lvGoiCuoc.SelectedItem as GoiCuocGui;

                // Delete data in sql
                //GoiCuocPublic goiCuocPl = goiCuoc;
                //GoiCuocBLL goiCuocBll = new GoiCuocBLL();
                //goiCuocBll.

                // Delete dta in view
                lvGoiCuoc.Items.RemoveAt(lvGoiCuoc.SelectedIndex);

                // Reload view
                _initialize_gbGoiCuoc();
            }
        }

        private void txtbGiaTronGoi_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
