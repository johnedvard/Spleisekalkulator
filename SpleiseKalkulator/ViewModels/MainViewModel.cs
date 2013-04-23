using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using SpleiseKalkulator.Resources;
using Microsoft.Phone.UserData;
using System.Windows.Media.Imaging;

namespace SpleiseKalkulator.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public void setHeader(string value)
        {
           
        }
        /// <summary>
        /// Sample property that returns a localized string
        /// </summary>
        public string LocalizedSampleProperty
        {
            get
            {
                return AppResources.SampleProperty;
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data
            this.Items.Add(new ItemViewModel() { ProfilePicture = "/Assets/renata_profil.jpg", LineOne = "Hallo", LineTwo = "her er linje tre", LineThree = "jaja, linje tre" });
            this.Items.Add(new ItemViewModel() { ProfilePicture = "/Assets/renata_profil.jpg", LineOne = "Hallo", LineTwo = "her er linje tre", LineThree = "jaja, linje tre" });
            this.Items.Add(new ItemViewModel() { ProfilePicture = "/Assets/renata_profil.jpg", LineOne = "Hallo", LineTwo = "her er linje tre", LineThree = "jaja, linje tre" });

           

            this.IsDataLoaded = true;
        }

        public void AddPerson(string profilePictureSource, string name)
        {
           this.Items.Add(new ItemViewModel() { ProfilePicture = "/Assets/renata_profil.jpg", LineOne = "asdasd", LineTwo = "her asdasd linje tre", LineThree = "jaja, asdasdasd tre" });
        }
        public void AddPerson(Contact contact)
        {
            ItemViewModel a = new ItemViewModel();
            BitmapImage img = new BitmapImage();
            System.IO.Stream imageStream = contact.GetPicture();
         
            img.SetSource(imageStream);
            a.P = img;
            
            this.Items.Add(a);
           

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