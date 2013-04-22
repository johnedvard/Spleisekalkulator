using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.UserData;

namespace SpleiseKalkulator.ViewModels
{
    public partial class AddContactPage : PhoneApplicationPage
    {
        public AddContactPage()
        {
            InitializeComponent();

            //search contacts
            Contacts cons = new Contacts();
            cons.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(Contacts_SearchCompleted);
            cons.SearchAsync(String.Empty, FilterKind.None, "Contacts Test #1");

        }

        private void Contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            MessageBox.Show(e.Results.Count().ToString());
        }
    }
}