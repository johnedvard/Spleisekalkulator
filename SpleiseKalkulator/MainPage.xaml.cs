using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.UserData;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Tasks;


// color template gotten from http://www.colourlovers.com/palette/855571/Clouds_Over_Castle 
namespace SpleiseKalkulator
{

    
    public partial class MainPage : PhoneApplicationPage
    {
        

        private string addContactsPage = "/AddContactPage.xaml";
        private string iouNotePage = "/IOUNote.xaml";

       

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
         

            
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {

            App.ViewModel.saveData();
            base.OnBackKeyPress(e);

        }
      

        private void AddPerson_Click(object sender, EventArgs e)
        {
            //App.ViewModel.AddPerson("asd", "asd");
            
       
            // navigate to the page where you can select a contact
            // Make sure to only attempt navigation if we have defined a next page.
            if (!String.IsNullOrWhiteSpace(addContactsPage))
            {
                this.NavigationService.Navigate(new Uri(addContactsPage, UriKind.Relative));
            }

        }
     


        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {

        }

        private void LongListSelector_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            ViewModels.ItemViewModel data = (sender as Button).DataContext as ViewModels.ItemViewModel;
            DataContainer.UPic = data.ProfileBitMap;
            DataContainer.IPic = App.ViewModel.PicOfMyself;
            DataContainer.itemViewModel = data;
            DataContainer.multiplier = 1;
            this.NavigationService.Navigate(new Uri(iouNotePage, UriKind.Relative));
        }

            
        
        private void Button_Click_Minus(object sender, RoutedEventArgs e)
        {

            ViewModels.ItemViewModel data = (sender as Button).DataContext as ViewModels.ItemViewModel;
            DataContainer.UPic = App.ViewModel.PicOfMyself;
            DataContainer.IPic = data.ProfileBitMap;
            DataContainer.itemViewModel = data;
            DataContainer.multiplier = -1;
            this.NavigationService.Navigate(new Uri(iouNotePage, UriKind.Relative));
            
        }

        private void StackPanel_Hold_1(object sender, System.Windows.Input.GestureEventArgs e)
        {

            ViewModels.ItemViewModel data = (sender as StackPanel).DataContext as ViewModels.ItemViewModel;


            MessageBoxResult result = MessageBox.Show("Would you like to remove: " + data.LineOne +"?", "Remove: " + data.LineOne, MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                if ( data != null && App.ViewModel.Items.Contains(data))
                {
                    try
                    {
                        App.ViewModel.Items.Remove(data);
                        App.ViewModel.saveData();
                        App.ViewModel.UpdateBgColors();
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.ToString());
                       
                    }
                }
              
            }
            App.ViewModel.HelpText = "Press the \"+\" button to add people you wish to borrow money from or lend money to.";
        }

        private void StackPanel_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PhotoChooserTask photo = new PhotoChooserTask();
            photo.Completed += new EventHandler<PhotoResult>(photoChooserTask_Completed);
            
            photo.ShowCamera = true;
            photo.Show();
        }

        void photoChooserTask_Completed(object sender, PhotoResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                BitmapImage img = new BitmapImage();
                System.IO.Stream imageStream = e.ChosenPhoto;
                if (imageStream == null)
                {
                    img.SetSource(App.GetResourceStream(new Uri(@"Assets/AppBar/questionmark.png", UriKind.Relative)).Stream);

                }
                else
                    img.SetSource(imageStream);
                App.ViewModel.PicOfMyself = img;
                App.ViewModel.SaveToJpeg(imageStream, "PicOfMyself.jpg");


                //Code to display the photo on the page in an image control named myImage.
                //System.Windows.Media.Imaging.BitmapImage bmp = new System.Windows.Media.Imaging.BitmapImage();
                //bmp.SetSource(e.ChosenPhoto);
                //myImage.Source = bmp;
            }
        }
    }
}