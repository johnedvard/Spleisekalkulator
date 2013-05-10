using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using SpleiseKalkulator.Resources;
using Microsoft.Phone.UserData;
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;
using System.Collections.Generic;

using System.IO;
using System.Windows.Resources;
using Microsoft.Xna.Framework.Media;
using Microsoft.Phone.Tasks;


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

        private string helpText = "press the \"+\" button to add people you owe or owe you.";
        public string HelpText
        {
            get
            {
                if (Items.Count > 0)
                {
                    return "";
                }
                return helpText;
            }
            set
            {
                    helpText = value;
                    NotifyPropertyChanged("HelpText");
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
            //this.Items.Add(new ItemViewModel() { ProfilePicture = "/Assets/renata_profil.jpg", LineOne = "Hallo", LineTwo = "her er linje tre", LineThree = "jaja, linje tre" });
            //this.Items.Add(new ItemViewModel() { ProfilePicture = "/Assets/renata_profil.jpg", LineOne = "Hallo", LineTwo = "her er linje tre", LineThree = "jaja, linje tre" });
            //this.Items.Add(new ItemViewModel() { ProfilePicture = "/Assets/renata_profil.jpg", LineOne = "Hallo", LineTwo = "her er linje tre", LineThree = "jaja, linje tre" });

            IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
            List<ItemViewModel> liste;
            
            
                appSettings.TryGetValue("john", out liste);
                if (liste == null) // empty list?
                {
                    liste = new List<ItemViewModel>();
                    appSettings.Add("john", liste);
                }
                else
                {
                    foreach(ItemViewModel i in liste)
                    {
                        BitmapImage bi = LoadImageFromIsolatedStorage(i.LineOne + ".jpg");
                        
                        if(bi == null)
                        {
                            bi = new BitmapImage();
                            bi.SetSource(App.GetResourceStream(new Uri(@"Assets/AppBar/questionmark.png", UriKind.Relative)).Stream);
                        }
                        i.ProfileBitMap = bi;
                        Items.Add(i);
                    }
                }
            
  
            this.IsDataLoaded = true;
        }

       public void saveData()
       {
           IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
           List<ItemViewModel> liste = new List<ItemViewModel>();
           foreach(ItemViewModel i in Items)
           {

               liste.Add(i); 
           }
           
           appSettings["john"] = liste;
           appSettings["renata"] = "kuuult";
           
           appSettings.Save();
       }


       private void SaveToJpeg(Stream stream, string strImageName)
       {
           using (IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication())
           {
               if (iso.FileExists(strImageName))
               {
                   iso.DeleteFile(strImageName);
               }


               using (IsolatedStorageFileStream isostream = iso.CreateFile(strImageName))
               {
                   BitmapImage bitmap = new BitmapImage();
                   if(stream == null)
                   {
                       bitmap.SetSource(App.GetResourceStream(new Uri(@"Assets/AppBar/questionmark.png", UriKind.Relative)).Stream);
                   }
                   else
                   {
                       bitmap.SetSource(stream);
                   }
                   
                   WriteableBitmap wb = new WriteableBitmap(bitmap);
                   // Encode WriteableBitmap object to a JPEG stream. 
                   Extensions.SaveJpeg(wb, isostream, wb.PixelWidth, wb.PixelHeight, 0, 85);
                   isostream.Close();
               }
           }
       }
       /// <summary> 
       /// Sample code for loading image from IsolatedStorage 
       /// </summary>  
       private BitmapImage LoadImageFromIsolatedStorage(string strImageName)
       {
           // The image will be read from isolated storage into the following byte array 
           byte[] data;


           // Read the entire image in one go into a byte array 
           try
           {
               using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
               {
                   // Open the file - error handling omitted for brevity 
                   // Note: If the image does not exist in isolated storage the following exception will be generated: 
                   // System.IO.IsolatedStorage.IsolatedStorageException was unhandled  
                   // Message=Operation not permitted on IsolatedStorageFileStream  
                   using (IsolatedStorageFileStream isfs = isf.OpenFile(strImageName, FileMode.Open, FileAccess.Read))
                   {
                       // Allocate an array large enough for the entire file 
                       data = new byte[isfs.Length];
                       // Read the entire file and then close it 
                       isfs.Read(data, 0, data.Length);
                       isfs.Close();
                   }
               }


               // Create memory stream and bitmap 
               MemoryStream ms = new MemoryStream(data);
               BitmapImage bi = new BitmapImage();
               // Set bitmap source to memory stream 
               bi.SetSource(ms);
               return bi;
              
           }
           catch (Exception e)
           {
               // handle the exception 
              
           }
           return null;
          
       }

        public bool AddPerson(Contact contact)
        {
            ItemViewModel a = new ItemViewModel();
            
            BitmapImage img = new BitmapImage();
            System.IO.Stream imageStream = contact.GetPicture();
           
            if (imageStream == null)
            {
                img.SetSource(App.GetResourceStream(new Uri(@"Assets/AppBar/questionmark.png", UriKind.Relative)).Stream);
              
            }
            else
                img.SetSource(imageStream);
            a.ProfileBitMap = img;
            a.LineOne = contact.DisplayName;
            SaveToJpeg(imageStream, contact.DisplayName + ".jpg");

            // set name to be displayed in GUI
            string name = contact.DisplayName;
            if(name.Length >= 9){
                name = name.Substring(0,9);
            }
            a.Name = name;
            a.Amount = 0;
            a.LineTwo = "I am in dept to";
            // check if the item exists.
            foreach(ItemViewModel item in Items)
            {
                if (item.LineOne.Equals(a.LineOne))
                {
                    return false;
                }
            }
            this.Items.Add(a);
            return true;

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