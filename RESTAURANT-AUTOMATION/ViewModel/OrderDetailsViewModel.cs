using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTAURANT_AUTOMATION.ViewModel
{
    public class OrderDetailsViewModel
    {
        public int ORDERDETAILID { get; set; }
        public int ORDERID { get; set; }
        public int ITEMID { get; set; }
        public decimal UNITPRICE { get; set; }
        public decimal QUANTITY { get; set; }
        public decimal DISCOUNT { get; set; }
        public decimal TOTAL { get; set; }

    }
}