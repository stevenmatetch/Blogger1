using Blogger1.Models;
using Blogger1.Services;
using Blogger1.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Blogger1.views
{
    public sealed partial class PutDialog : ContentDialog
    {
        public BookViewModel bookViewModel { get; set; }
        public APIServices APIServices;
        //public Book book { get; set; }

        public Book thisBook { get; set; }

        public PutDialog(Book b)
        {

            thisBook = b;
            bookViewModel = new BookViewModel();
            APIServices = new APIServices();
            this.InitializeComponent();
        }

        /* Skapa ny book */
        public PutDialog()
        {
            thisBook = new Book();
            thisBook.ID = 0;

            bookViewModel = new BookViewModel();
            APIServices = new APIServices();
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            
        }

        private async void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if(thisBook.ID > 0)
            {

                thisBook = await APIServices.PutBookAsync(thisBook);

            }
            else
            {

                thisBook = await APIServices.AddBookAsync(thisBook);

            }

            
          


        }
    }
}
