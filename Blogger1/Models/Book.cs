﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger1.Models
{
   public class Book
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public long Published { get; set; }
        public string Image { get; set; }

        //public Book()
        //{

        //}
        public Book(string title, string content, long published, string image)
        {
            Title = title;
            Content = content;
            Published = published;
            Image = image;

        }
    }
}