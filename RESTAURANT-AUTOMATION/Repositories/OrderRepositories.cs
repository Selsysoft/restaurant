using RESTAURANT_AUTOMATION.Models;
using RESTAURANT_AUTOMATION.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTAURANT_AUTOMATION.Repositories
{
    public class OrderRepositories
    {
        private RESTAURANTDBEntities objRestaurantDbEntities;
        public OrderRepositories()
        {
            objRestaurantDbEntities = new RESTAURANTDBEntities();
        }

        public bool AddOrder(OrdersViewModel objOrderViewModel)
        {
            ORDERS objOrder = new ORDERS();
            objOrder.MUSTERIID = objOrderViewModel.MUSTERIID;
            objOrder.FINALTOTAL = objOrderViewModel.FINALTOTAL;
            objOrder.ORDERDATE = DateTime.Now;
            objOrder.ORDERNUMBER = string.Format("{0:ddmmmyyyyhhmmss}",DateTime.Now);
            objOrder.ODEMESEKLIID = objOrderViewModel.ODEMESEKLIID;
            objRestaurantDbEntities.ORDERS.Add(objOrder);
            objRestaurantDbEntities.SaveChanges();
            int ORDERID = objOrder.ID;

            foreach(var item in objOrderViewModel.ListOfOrderDetailViewModel)
            {
                ORDERDETAILS objOrderDetail = new ORDERDETAILS();
                objOrderDetail.ORDERID = ORDERID;
                objOrderDetail.DISCOUNT = item.DISCOUNT;
                objOrderDetail.ITEMID = item.ITEMID;
                objOrderDetail.TOTAL = item.TOTAL;
                objOrderDetail.UNITPRICE = item.UNITPRICE;
                objOrderDetail.QUANTITY = item.QUANTITY;
                objRestaurantDbEntities.ORDERDETAILS.Add(objOrderDetail);
                objRestaurantDbEntities.SaveChanges();

                TRANSACTIONS objTransaction = new TRANSACTIONS();
                objTransaction.ITEMID = item.ITEMID;
                objTransaction.QUANTITY =(-1) * item.QUANTITY;
                objTransaction.TRANSACTIONDATE = DateTime.Now;
                objTransaction.TYPEID = 2;
                objRestaurantDbEntities.TRANSACTIONS.Add(objTransaction);
                objRestaurantDbEntities.SaveChanges();
            }
            
            return true;
        }
    }
}