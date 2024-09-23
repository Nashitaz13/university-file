using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QLDKINTERNET.GUI
{
    class DichVuGui : INotifyPropertyChanged
    {
        String _diaChiCaiDat;

        public String DiaChiCaiDat
        {
            get { return _diaChiCaiDat; }
            set { _diaChiCaiDat = value; OnPropertyChanged("DiaChiCaiDat"); }
        }
        String _diaChiHoaDon;

        public String DiaChiHoaDon
        {
            get { return _diaChiHoaDon; }
            set { _diaChiHoaDon = value; OnPropertyChanged("DiaChiGoiHoaDon"); }
        }
        String _tenGoiCuoc;

        public String TenGoiCuoc
        {
            get { return _tenGoiCuoc; }
            set { _tenGoiCuoc = value; OnPropertyChanged("TenGoiCuoc"); }
        }
        String _tenKieuCaiDat;

        public String TenKieuCaiDat
        {
            get { return _tenKieuCaiDat; }
            set { _tenKieuCaiDat = value; OnPropertyChanged("TenKieuCaiDat"); }
        }
        String _tenModem;

        public String TenModem
        {
            get { return _tenModem; }
            set { _tenModem = value; OnPropertyChanged("TenModem"); }
        }
        
        int _soLuongTaiKhoan;
        public int SoLuongTaiKhoan
        {
            get { return _soLuongTaiKhoan; }
            set { _soLuongTaiKhoan = value; OnPropertyChanged("SoLuongTaiKhoan"); }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Private Helpers

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
