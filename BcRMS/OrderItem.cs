using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BcRMS
{
   public class OrderItem
    {
        public string Item { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
    }
}
