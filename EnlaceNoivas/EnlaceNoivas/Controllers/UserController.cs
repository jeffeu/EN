using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnlaceNoivas.ViewModels;
using EnlaceNoivas.Models;
using System.Web.Security;
using Mvc.Mailer;

namespace EnlaceNoivas.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        private ModelContext db = new ModelContext();
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult SignIn(string UserOrEmail, string Pass) 
        {
            //selecionando o usuário q tiver nome de usuario ou email = ao indicado
            var current_user = db.User.Where(user => (user.Username == UserOrEmail || user.Email == UserOrEmail) && user.Pass == Pass).FirstOrDefault();
            //checando se foi retornado algo
            if (current_user != (null))
            {
                    //logando o usuario
                TempData["AuthError"] = null;
                    FormsAuthentication.SetAuthCookie(UserOrEmail, false);
            }
            else
            {
                TempData["AuthError"] = "seu nome de usuário, e-mail ou senha não são válidos";
            }
            return RedirectToAction("Index", "Home");
            
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Register(CoupleUser CoupleUser) {
            if (ModelState.IsValid)
            {   
                    CoupleUser.Couple.User = CoupleUser.User;
                    db.Couple.Add(CoupleUser.Couple);
                    db.SaveChanges();
                    var email = new MvcMailMessage { Subject = "Confirmação de Email"};
                    email.To.Add(CoupleUser.User.Email);
                    email.ViewName = "Welcome";
                    email.Send();
                    return RedirectToAction("SignIn", "User", CoupleUser.User);
            }
            else
            {
                return View("Create", CoupleUser.User);
            }
        }
        public ActionResult List(){
            return View(db.User);
        }
    }
}
