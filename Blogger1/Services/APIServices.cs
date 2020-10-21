using Blogger1.Models;
using Blogger1.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
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
            bookViewModel.books = new ObservableCollection<Book>(bookViewModel.books.OrderBy(b => b.Published));
            return bookViewModel.books;

        }
        public async Task<Book> AddBookAsync(Book b)
        {
            using (HttpClient client = new HttpClient())
            {
                var book = JsonConvert.SerializeObject(b);
                HttpContent httpContent = new StringContent(book);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var result = await client.PostAsync(BooksUrl, httpContent);

                string p = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Book>(p);
            }

        }
        public async Task<Book> PutBookAsync(Book b)
        {
            using (HttpClient client = new HttpClient())
            {
                var book = JsonConvert.SerializeObject(b);
                HttpContent httpContent = new StringContent(book);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var result = await client.PutAsync(BooksUrl + "/" + b.ID.ToString(), httpContent);

                string p = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Book>(p);
            }

        }
        public async Task DeleteBookAsync(Book book)
        {
            var httpClient = new System.Net.Http.HttpClient();
            await httpClient.DeleteAsync(BooksUrl + book.ID);
        }
      
    }
}
