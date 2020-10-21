using Blogger1.Models;
using Blogger1.Services;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Blogger1.views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateAndUpdatePage : Page
    {
        public Book book { get; set; }
        public APIServices aPIServices;
        public CreateAndUpdatePage()
        {
            this.InitializeComponent();
            book = new Book();
            aPIServices = new APIServices();
        }

        private async void PostButton_Click(object sender, RoutedEventArgs e)
        {
            book.Title = TitleTextBlock.Text;
            book.Content = ContentTextBlock.Text;
            book.Picture = PictureTextBlock.Text;
            book.Published = long.Parse(Publishedtextblock.Text);
            var b = await aPIServices.AddBookAsync(book);
        }
    }
}
