using RESTAURANT_AUTOMATION.Models;
using RESTAURANT_AUTOMATION.Repositories;
using RESTAURANT_AUTOMATION.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RESTAURANT_AUTOMATION.Controllers
{
    public class HomeController : Controller
    {
        private RESTAURANTDBEntities objRESTAURANTDBEntities;
        public HomeController()
        {
            objRESTAURANTDBEntities = new RESTAURANTDBEntities();
        }

        // GET: Home
        public ActionResult Index()
        {
            MusteriRepositories objMusteriRepositories = new MusteriRepositories();
            ItemRepositories objItemRepositories = new ItemRepositories();
            OdemeSekliRepositories objOdemeSekliRepositories = new OdemeSekliRepositories();

            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
             (objMusteriRepositories.GetAllMusteriler(), objItemRepositories.GetAllItems(), objOdemeSekliRepositories.GetAllOdemeSekli());


            return View(objMultipleModels);
        }
        [HttpGet]
        public JsonResult getItemUnitPrice(int itemId)
        {
            decimal UnitPrice = objRESTAURANTDBEntities.ITEMS.Single(model => model.ID == itemId).ITEMTUTAR;
            return Json(UnitPrice, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Index(OrdersViewModel objOrdersViewModel)
        {
            OrderRepositories objOrderRepositories = new OrderRepositories();
            objOrderRepositories.AddOrder(objOrdersViewModel);
            return Json("Your Order has been Succesfully Placed.", JsonRequestBehavior.AllowGet);
        }
    }
}