using Blogger1.Models;
using Blogger1.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Blogger1.Services
{
    public class APIServices
    {
        static HttpClient httpClient = new HttpClient();
        private static string BooksUrl = "https://localhost:44389/api/books";
        public async Task<ObservableCollection<Book>> GetBooksAsync()
        {
            BookViewModel bookViewModel = new BookViewModel();
            var jsonGetBook = await httpClient.GetStringAsync(BooksUrl);
            bookViewModel.books = JsonConvert.DeserializeObject<ObservableCollection<Book>>(jsonGetBook);
            return bookViewModel.books;

        }
        public async Task DeleteTestAsync(Book book)
        {
            var httpClient = new System.Net.Http.HttpClient();
            await httpClient.DeleteAsync(BooksUrl + book.ID);
        }
        //public async void  PostBooks(StudentsResults results)
        //{
        //    var result = JsonConvert.SerializeObject(results);
        //    HttpContent httpContent = new StringContent(result);
        //    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //    var responseStatus = await httpClient.PostAsync(PostStudentsResultsUrl, httpContent);
        //}

        //public async Task<int> PostBooks(List<UserBooking> rooms)
        //{
        //    //var json = JsonConvert.SerializeObject(rooms);
        //    //HttpContent content = new StringContent(json);
        //    //content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        //    //var data = await httpClient.PostAsync(new Uri(BookedRoomsUrl), content);
        //    //return 1;

    }
}
