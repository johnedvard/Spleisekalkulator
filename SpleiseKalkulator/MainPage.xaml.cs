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
        

        private Contact currentContact = null;
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
            if(currentContact != DataContainer.contact){
                currentContact = DataContainer.contact;
                App.ViewModel.AddPerson(currentContact);
                
            }
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }

            
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
           
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

        private void Button_Click_OweMe(object sender, RoutedEventArgs e)
        {
            ViewModels.ItemViewModel data = (sender as Button).DataContext as ViewModels.ItemViewModel;
            DataContainer.UPic = data.P;
            DataContainer.IPic =  null;
            this.NavigationService.Navigate(new Uri(iouNotePage, UriKind.Relative));
        }

            
        
        private void Button_Click_IOwe(object sender, RoutedEventArgs e)
        {

            ViewModels.ItemViewModel data = (sender as Button).DataContext as ViewModels.ItemViewModel; ;
            DataContainer.UPic = null;
            DataContainer.IPic = data.P;
            
            this.NavigationService.Navigate(new Uri(iouNotePage, UriKind.Relative));
            
        }
    }
}