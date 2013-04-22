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

namespace SpleiseKalkulator
{
    public partial class MainPage : PhoneApplicationPage
    {
        private string addContactsPage = "/AddContactPage.xaml";
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
    }
}