﻿using Blogger1.Models;
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
         

            //DateTime tid = DateTime.Now;


            //tid = Convert.ToDateTime(1599623320);

            //books.Add(new Book("steven", "kapitl 1 , kapitel 2 ", 1599623320, "/Assets/LV.jpg"));
            //books.Add(new Book("Matetcho", "kapitl 1 , kapitel 2 ", 1599623320, "/Assets/LV.jpg"));
        }
        internal void RemoveBook(Book book)
        {
            books.Remove(book);
        }
    }
}
