using EnlaceNoivas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnlaceNoivas.ViewModels;

namespace EnlaceNoivas.Controllers
{
    public class ProviderController : Controller
    {
        //
        // GET: /Provider/
        private ModelContext db = new ModelContext();
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Register(ProviderMV prov)
        {
            /*db.Provider.Add(prov.Provider);
            db.SaveChanges();*/
            return View("Create");
            if (ModelState.IsValid)
            {
                Provider provider = prov.Provider;
                provider.User = prov.User;
                db.Provider.Add(provider);
                db.SaveChanges();
                return RedirectToAction("SignIn", "User", new {UserOrEmail = prov.User.Username, Pass = prov.User.Pass});
            }
            else {
                return View("Create");
            }
        }
        public ActionResult Profile(string providerName) {
            providerName = providerName.Replace("_", " ");
            return View(db.Provider.Where(p => p.Name == providerName).FirstOrDefault());
        }

    }
}
