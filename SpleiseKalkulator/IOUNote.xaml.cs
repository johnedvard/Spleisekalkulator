using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace SpleiseKalkulator
{
    public partial class IOUNote : PhoneApplicationPage
    {
        public IOUNote()
        {
            InitializeComponent();
            DataContext = App.IOUNoteViewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
                App.IOUNoteViewModel.IPic = DataContainer.IPic;   
                App.IOUNoteViewModel.UPic = DataContainer.UPic;
  
        }

        private void ok_Click_1(object sender, RoutedEventArgs e)
        {
            if (Money.Text.Equals("")) Money.Text = "0";
            DataContainer.itemViewModel.Amount += Convert.ToDouble(Money.Text)*DataContainer.multiplier;
            NavigationService.GoBack();
        }
    }
}