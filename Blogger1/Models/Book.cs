using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Input;

namespace Blogger1.Models
{
   public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public long Published { get; set; }
        public string Picture { get; set; }

        public Book()
        {

        }
        public Book(string title, string content, long published, string picture)
        {
            Title = title;
            Content = content;
            Published = published;
            Picture = picture;

        }
        public string Time
        {
            get
            {
                
                return new DateTime(1970, 1, 1).AddSeconds(Published).ToString("yyyy-MM-dd HH:mm:ss");
            }

        }
       

        public DateTimeOffset PublishedDateTime
        {
            get
            {
                return new DateTime(1970, 1, 1).AddSeconds(Published);
            }
            set
            {
                Published = (long)(value.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            }
        }
         public TimeSpan time
        {
            get
            {
                return new TimeSpan(1970, 1, 1);
            }
            set
            {
                Published = (long)(value.Subtract(new TimeSpan(1970, 1, 1))).TotalSeconds;

            }



        }

        //public static long GetLongFromDateTime(DateTime tid)
        //{
        //    return (long)(tid.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

        //}

        //DateTime tid = DateTime.Now;


        //tid = Convert.ToDateTime(1599623320);
    }
}
