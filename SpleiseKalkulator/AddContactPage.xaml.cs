﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.UserData;


namespace SpleiseKalkulator.ViewModels
{
    public partial class AddContactPage : PhoneApplicationPage
    {

        FilterKind contactFilterKind = FilterKind.None;


        public AddContactPage()
        {
          InitializeComponent();

          
          

        }
        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            SearchContacts();
        }
        private void SearchContacts()
        {

            Contacts cons = new Contacts();

            cons.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(Contacts_SearchCompleted);

            cons.SearchAsync(String.Empty, contactFilterKind, "Contacts Test #1");
        }

        private void Contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            try
            {
                ContactResultsData.DataContext = e.Results;

            }
            catch (Exception)
            {
                //We can't get a picture of the contact.
            }

        }
        private void LongListSelector_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
         
        }

      

        private void ContactResultsData_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Contact c = (sender as ListBox).SelectedValue as Contact;
            if (!App.ViewModel.AddPerson(c))
            {
                MessageBox.Show(c.DisplayName+" is already added, please select another person or press the back button to go back");
                
            }
            else
            {
                App.ViewModel.HelpText = "Press the \"+\" button to add people you wish to borrow money from or lend money to.";
                App.ViewModel.saveData();

                NavigationService.GoBack();
            }
        }
      

    }


    public class ContactPictureConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Contact c = value as Contact;
            if (c == null) return null;

            System.IO.Stream imageStream = c.GetPicture();
            if (null != imageStream)
            {
                return Microsoft.Phone.PictureDecoder.DecodeJpeg(imageStream);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}