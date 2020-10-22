using Blogger1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger1.ViewModels
{
    public class BookViewModel
    {
        public ObservableCollection<Book> books { get; set; }
        public Book book { get; set; }
        public Book selectedBook { get; set; }

        public BookViewModel()
        {
            books = new ObservableCollection<Book>();
         

           
        }
        internal void RemoveBook(Book book)
        {
            books.Remove(book);
        }
    }
}
