using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using T2009M1NguyenCuongUWP.Data;
using T2009M1NguyenCuongUWP.Entities;
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
    public sealed partial class ContactForm : Page
    {
        private ContactModel contactModel = new ContactModel();
        public ContactForm()
        {
            this.InitializeComponent();
            this.Loaded += ContactForm_Loaded;
        }

        private void ContactForm_Loaded(object sender, RoutedEventArgs e)
        {
            DatabaseContact.UpDatabase();
        }

        private async void Add_Contact(object sender, RoutedEventArgs e)
        {
            var contact = new Contact()
            {
                Name = txtName.Text,
                PhoneNumber = txtPhoneNumber.Text
            };
            var result = contactModel.Save(contact);
            ContentDialog contentDialog = new ContentDialog();
            if (result)
            {
                contentDialog.Title = "Action success";
                contentDialog.Content = $"Add contact success!";
                contentDialog.PrimaryButtonText = "Okie";
                await contentDialog.ShowAsync();
                this.Frame.Navigate(typeof(Pages.ContactList));
            }
            else
            {
                contentDialog.Title = "Action Fail";
                contentDialog.Content = $"Add contact Fail!";
                contentDialog.PrimaryButtonText = "Okie";
                await contentDialog.ShowAsync();
            }
        }
    }
}
