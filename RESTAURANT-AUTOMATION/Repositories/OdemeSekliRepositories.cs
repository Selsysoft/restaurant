using RESTAURANT_AUTOMATION.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RESTAURANT_AUTOMATION.Repositories
{
    public class OdemeSekliRepositories
    {
        private RESTAURANTDBEntities objRESTAURANTDBEntities;
        public OdemeSekliRepositories()
        {
            objRESTAURANTDBEntities = new RESTAURANTDBEntities();
        }

        public IEnumerable<SelectListItem> GetAllOdemeSekli()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objRESTAURANTDBEntities.ODEMESEKLI
                                  select new SelectListItem()
                                  {
                                      Text = obj.ODEMESEKLIADI,
                                      Value = obj.ID.ToString(),
                                      Selected = true
                                  }).ToList();

            return objSelectListItems;
        }
    }
}