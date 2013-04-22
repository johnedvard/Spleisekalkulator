using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace SpleiseKalkulator.ViewModels
{
   public class AddContactItemViewModel : INotifyPropertyChanged
    {

        private string _contactPicture;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string ContactPicture
        {
            get
            {
                return _contactPicture;
            }
            set
            {
                if (value != _contactPicture)
                {
                    _contactPicture = value;
                    NotifyPropertyChanged("ContactPicture");
                }
            }
        }

        private string _contactName;
        public string ContactName
        {
            get
            {
                return _contactName;
            }
            set
            {
                if (value != _contactName)
                {
                    _contactName = value;
                    NotifyPropertyChanged("ContactName");
                }
            }
        }

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
