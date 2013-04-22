using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using SpleiseKalkulator.Resources;

namespace SpleiseKalkulator.ViewModels
{
    public class AddContactViewModel : INotifyPropertyChanged
    {
        public AddContactViewModel()
        {
            this.Items = new ObservableCollection<AddContactItemViewModel>();
        }


        public ObservableCollection<AddContactItemViewModel> Items { get; private set; }

       
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
