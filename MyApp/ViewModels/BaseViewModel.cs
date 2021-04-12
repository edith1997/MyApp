using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged  //heredar de inotify
    {

        //heredar de inotify
        //public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        // {
        //    if (PropertyChanged != null)
        //   {
        // PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        // }
        // }
        public event PropertyChangedEventHandler PropertyChanged;
        public bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }
    }
}
