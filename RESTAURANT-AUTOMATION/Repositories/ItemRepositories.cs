using RESTAURANT_AUTOMATION.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RESTAURANT_AUTOMATION.Repositories
{
    public class ItemRepositories
    {
        private RESTAURANTDBEntities objRESTAURANTDBEntities;
        public ItemRepositories()
        {
            objRESTAURANTDBEntities = new RESTAURANTDBEntities();
        }

        public IEnumerable<SelectListItem> GetAllItems()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objRESTAURANTDBEntities.ITEMS
                                  select new SelectListItem()
                                  {
                                      Text = obj.ITEMADI,
                                      Value = obj.ID.ToString(),
                                      Selected = false
                                  }).ToList();

            return objSelectListItems;
        }
    }
}