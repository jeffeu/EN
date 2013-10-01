using EnlaceNoivas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnlaceNoivas.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/
        private ModelContext db = new ModelContext();
        public ActionResult SearchProvider(string searched)
        {
            var providers = db.Provider.Where(prov => (prov.Name.Contains(searched)));
            return View(providers);
        }
        public ActionResult Found(string searched)
        {
            var providers = db.Provider.Where(prov => (prov.Name.Contains(searched) || (prov.City.Contains(searched) || (prov.Street.Contains(searched))))).Distinct().Take(6);
            return Json(providers, JsonRequestBehavior.AllowGet);
        }

    }
}
