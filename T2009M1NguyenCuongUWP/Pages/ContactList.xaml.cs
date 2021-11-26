using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using T2009M1NguyenCuongUWP.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace T2009M1NguyenCuongUWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContactList : Page
    {
        private ContactModel contactModel = new ContactModel();
        public ContactList()
        {
            this.InitializeComponent();
            this.Loaded += ContactList_Loaded;
        }

        private void ContactList_Loaded(object sender, RoutedEventArgs e)
        {
            MyListView.ItemsSource = contactModel.FindAll();
        }

        private void HyperlinkButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Pages.ContactForm));

        }

        private void Search(object sender, RoutedEventArgs e)
        {
            var result = contactModel.SearchByKeyword(txtKeyword.Text);
            MyListView.ItemsSource = result;           
        }
    }
}
