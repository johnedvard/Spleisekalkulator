using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpleiseKalkulator.Resources;
using Microsoft.Phone.UserData;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SpleiseKalkulator.ViewModels
{
    public class IOUNoteViewModel : INotifyPropertyChanged
    {

        private BitmapImage ipic;
        private BitmapImage upic;

        public BitmapImage IPic
        {
            get
            {
                return ipic;
            }
            set 
            {
                if(ipic != value)
                {
                    ipic = value;
                    if (value == null)
                    {
                        /*
                        Uri u = new Uri(@"Assets/AppBar/add.png", UriKind.Relative);
                        BitmapImage bi = new BitmapImage(u);
                        ipic = bi;
                         */
                    }
                    NotifyPropertyChanged("IPic");

                }
                       
            }

        }
        public BitmapImage UPic
        {
            get
            {
                    return upic;

            }
            set
            {
                if(value != upic){
                    upic = value;
                    if(value == null){
                        /*
                        Uri u = new Uri(@"Assets/AppBar/add.png", UriKind.Relative);
                        BitmapImage bi = new BitmapImage(u);
                        upic = bi;
                         */
                    }
                    NotifyPropertyChanged("UPic");
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
