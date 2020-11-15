
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger1.Models
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int TotalPrice { get; set; }

        public int BookID { get; set; }

        public int UserID { get; set; }
        public int ExtraID { get; set; }
    }
}
