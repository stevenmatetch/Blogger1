using Blogger1.Models;
using Blogger1.Services;
using Blogger1.ViewModels;
using Blogger1.views;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Blogger1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public BookViewModel bookViewModel { get; set; }
        public APIServices APIServices { get; set; }
        public Book selectedBook { get; set; }

        public MainPage()

        {

            bookViewModel = new BookViewModel();
            APIServices = new APIServices();

            this.InitializeComponent();
            GetAllbooks();
        }
        public async void GetAllbooks()
        {
            //BooksGridView.ItemsSource= await APIServices.GetBooksAsync();
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //var select = BooksGridView.SelectedItems;
            //foreach (Book book in select)
            //{
            //    bookViewModel.RemoveBook(book);
            //    await APIServices.DeleteBookAsync(book);
            //}
        }

        private async void PutButton_Click(object sender, RoutedEventArgs e)
        {
            PutAndPostDialog c = new PutAndPostDialog(selectedBook);

            c.Closed += C_Closed;

            var res = await c.ShowAsync();

        }

        private async void C_Closed(ContentDialog sender, ContentDialogClosedEventArgs args)
        {
            if (args.Result == ContentDialogResult.Secondary)
            {
                //BooksGridView.ItemsSource = await APIServices.GetBooksAsync();
            }
        }

        private async void PostButton_Click(object sender, RoutedEventArgs e)
        {
            PutAndPostDialog c = new PutAndPostDialog();
            c.Closed += C_Closed;
            var res = await c.ShowAsync();
        }

        private void DeleteRoomButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteExtraButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
