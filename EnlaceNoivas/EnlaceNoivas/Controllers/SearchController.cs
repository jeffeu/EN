﻿using EnlaceNoivas.Models;
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
        
        public ActionResult SearchProvider(int? page, string? searched)
        {
            if (searched.Equals(null))
            {
                searched = ViewBag.Searched;
            }
            else { 
                ViewBag.Searched = searched;
            }
            page = page.Equals(null) ? 1 : page;
            return View(getIndex(searched.ToString(),Convert.ToInt32(page)));
        }
        public ActionResult Found(string searched)
        {
            return Json(SearchQuery(searched).Take(5), JsonRequestBehavior.AllowGet);
        }
        public IQueryable<Provider> SearchQuery(string searched)
        {
            var providers = db.Provider.Where(prov => (prov.Name.Contains(searched) || (prov.City.Contains(searched) || (prov.Type.Contains(searched))))).Distinct().OrderBy(prov => prov.Name);
            ViewBag.ListSize = providers.Count()/resultMount;
            return providers;
        }
        public IQueryable<Provider> getIndex(string searched)
        {
            return getIndex(searched, 5, 0);
        }
        public IQueryable<Provider> getIndex(string searched, int page)
        {
            return getIndex(searched, resultMount, page);
        }
        public IQueryable<Provider> getIndex(string searched, int take, int page) {
            return SearchQuery(searched).Skip((page-1)*take).Take(take);
        }

    }
}
