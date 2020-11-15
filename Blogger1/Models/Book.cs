using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Input;
using Windows.UI.Xaml.Media.Imaging;

namespace Blogger1.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public long Published { get; set; }
        public string Picture { get; set; }
        public int Price { get; set; }

        public string GetPicture
        {
            get
            {
                if (Picture == null || Picture == "") return "/Assets/Book.png";

                try
                {
                    BitmapImage bitmapImage =
                     new BitmapImage(new Uri("ms-appx:///[project-name]" + Picture));
                    return Picture;
                }
                catch
                {
                    return "/Assets/Book.png"; ;
                }

            }
        }

        public Book()
        {

        }
        public Book(string title, string content, long published, string picture, int price)
        {
            Title = title;
            Content = content;
            Published = published;
            Picture = picture;
            Price = price;

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



                return PublishedDateTime - PublishedDateTime.Date;

            }
            set
            {

                DateTime nyttdatum = PublishedDateTime.Date.Add(value);
                Published = (long)(nyttdatum.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;





            }



        }


    }
}
