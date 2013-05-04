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
    }
}