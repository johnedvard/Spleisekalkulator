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
            DataContainer.IPic =  null;
            DataContainer.itemViewModel = data;
            DataContainer.multiplier = 1;
            this.NavigationService.Navigate(new Uri(iouNotePage, UriKind.Relative));
        }

            
        
        private void Button_Click_Minus(object sender, RoutedEventArgs e)
        {

            ViewModels.ItemViewModel data = (sender as Button).DataContext as ViewModels.ItemViewModel;
            DataContainer.UPic = null;
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
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.ToString());
                       
                    }
                        
                    
                   
                    
                    
                    
                }
              
            }
            App.ViewModel.HelpText = "press the \"+\" button to add people you owe or owe you.";

           
        }
    }
}