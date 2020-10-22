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
                } catch
                {
                    return "/Assets/Book.png"; ;
                }

            }
        }

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

                // Tiden som ska visas i TimePicker är från midnatt fram till aktuellt klockslag.

                return PublishedDateTime - PublishedDateTime.Date;

                //return new TimeSpan(1970, 1, 1);
            }
            set
            {

                DateTime nyttdatum = PublishedDateTime.Date.Add(value);
                Published = (long)(nyttdatum.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;


                //// Nu ska vi räkna om value från TimePicker till UNIX-tiden som är en long

                //// Steg 1. Räkna ut hur många sekunder man har valt i TimePicker

                //int sek = (int)value.TotalSeconds;

                //// Steg 2. Ta bort nuvarande klockslag från datumet som redan är sparat i Published

                //DateTime nuvarandedatum = new DateTime(1970, 1, 1).AddSeconds(Published).Date;

                //// Steg 3. Räkna ut hur många sekunder från 1970-01-01 som har gått fram till det valda datumet (alltså utan klockslaget)

                //long sek2 = (long)(nuvarandedatum.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;


                //// Steg 4. Plussa ihop dem för att få det nya värdet, totalt antal sekunder från 1970 fram till valt datum + antalet sekunder från midnatt till vald tid
                //Published = (long)sek + sek2;


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
