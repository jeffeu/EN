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
        private int resultMount = 3;
        private ModelContext db = new ModelContext();
        public ActionResult SearchProvider(int page, string searched)
        {
            ViewBag.Searched = searched;
            var resultQuery = getIndex(searched, page);
            if (resultQuery.Count() < 1)
                return View("SearchNotFound");
            else
                return View(resultQuery);
        }
        [HttpPost]
        public ActionResult SearchProvider(string searched)
        {

            ViewBag.Searched = searched;
            var resultQuery = getIndex(searched, 1);
            if (resultQuery.Count() < 1)
                return View("SearchNotFound");
            else
                return View(resultQuery);
        }

        public ActionResult SearchNouFound() {
            return View();
        }

        public ActionResult Found(string searched)
        {
            return Json(SearchQuery(searched).Take(5), JsonRequestBehavior.AllowGet);
        }
        private IQueryable<Provider> SearchQuery(string searched)
        {
            var providers = db.Provider.Where(prov => (prov.Name.Contains(searched) || (prov.City.Contains(searched) || (prov.Type.Contains(searched))))).Distinct().OrderBy(prov => prov.Name);
            ViewBag.ListSize = providers.Count() / resultMount + ((providers.Count() % resultMount!=0)? 1:0);
            return providers;
        }
        private IQueryable<Provider> getIndex(string searched)
        {
            return getIndex(searched, 5, 0);
        }
        private IQueryable<Provider> getIndex(string searched, int page)
        {
            return getIndex(searched, resultMount, page);
        }
        private IQueryable<Provider> getIndex(string searched, int take, int page) {
            return SearchQuery(searched).Skip((page-1)*take).Take(take);
        }

    }
}
