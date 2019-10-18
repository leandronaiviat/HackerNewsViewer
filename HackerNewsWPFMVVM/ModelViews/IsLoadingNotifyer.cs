using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace HackerNewsWPFMVVM.ModelViews
{
    public class IsLoadingNotifyer : INotifyPropertyChanged
    {

        private bool _IsLoading;
        public bool IsLoading
        {
            get
            {
                return _IsLoading;
            }
            set
            {
                _IsLoading = value;
                OnPropertyChanged(nameof(_IsLoading));
            }
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //private void OnPropertyChanged(string propertyName)
        //{
        //    Debug.WriteLine("NEW VALUE SETED {0}", propertyName);
        //    PropertyChanged?.Invoke(this,
        //        new PropertyChangedEventArgs(propertyName));
        //}



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                Debug.WriteLine("NEW VALUE SETED {0}", propertyName);
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
