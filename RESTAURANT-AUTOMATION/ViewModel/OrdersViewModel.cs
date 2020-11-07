using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTAURANT_AUTOMATION.ViewModel
{
    public class OrdersViewModel
    {
        public int ID { get; set; }
        public int ODEMESEKLIID { get; set; }
        public int MUSTERIID { get; set; }
        public string ORDERNUMBER { get; set; }
        public DateTime ORDERDATE { get; set; }
        public decimal FINALTOTAL { get; set; }

        public IEnumerable<OrderDetailsViewModel> ListOfOrderDetailViewModel { get; set; }
    }
}