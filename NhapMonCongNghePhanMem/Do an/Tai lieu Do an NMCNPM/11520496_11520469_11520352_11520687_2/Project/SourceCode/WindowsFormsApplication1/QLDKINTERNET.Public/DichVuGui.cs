using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QLDKINTERNET.GUI
{
    class DichVuGui : INotifyPropertyChanged
    {
        int _stt;

        public int Stt
        {
            get { return _stt; }
            set
            {
                _stt = value;
                OnPropertyChanged("Stt");
            }
        }
        String _diaChiCaiDat;

        public String DiaChiCaiDat
        {
            get { return _diaChiCaiDat; }
            set { _diaChiCaiDat = value; OnPropertyChanged("DiaChiCaiDat"); }
        }
        String _diaChiGoiHoaDon;

        public String DiaChiGoiHoaDon
        {
            get { return _diaChiGoiHoaDon; }
            set { _diaChiGoiHoaDon = value; OnPropertyChanged("DiaChiGoiHoaDon"); }
        }
        String _goiCuoc;

        public String GoiCuoc
        {
            get { return _goiCuoc; }
            set { _goiCuoc = value; OnPropertyChanged("GoiCuoc"); }
        }
        String _cachThucCaiDat;

        public String CachThucCaiDat
        {
            get { return _cachThucCaiDat; }
            set { _cachThucCaiDat = value; OnPropertyChanged("CachThucCaiDat"); }
        }
        String _modem;

        public String Modem
        {
            get { return _modem; }
            set { _modem = value; OnPropertyChanged("Modem"); }
        }
        String _soLuongAccount;

        public String SoLuongAccount
        {
            get { return _soLuongAccount; }
            set { _soLuongAccount = value; OnPropertyChanged("SoLuongAccount"); }
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
