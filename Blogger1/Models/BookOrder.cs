using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger1.Models
{
    public class BookOrder
    {
        public int BookID { get; set; }
        public Book Book { get; set; }


        public int OrderID { get; set; }
        public Order Order { get; set; }

    }
}
