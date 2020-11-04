using RESTAURANT_AUTOMATION.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RESTAURANT_AUTOMATION.Repositories
{
    public class MusteriRepositories
    {
        private RESTAURANTDBEntities objRESTAURANTDBEntities;
        public MusteriRepositories()
        {
            objRESTAURANTDBEntities = new RESTAURANTDBEntities();
        }

        public IEnumerable<SelectListItem> GetAllMusteriler()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objRESTAURANTDBEntities.MUSTERILER
                                  select new SelectListItem()
                                  {
                                      Text = obj.MUSTERIADI,
                                      Value = obj.ID.ToString(),
                                      Selected = true
                                  }).ToList();

            return objSelectListItems;
        }
    }
}