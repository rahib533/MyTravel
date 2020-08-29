using MyTravel.App_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyTravel.Controllers.User
{
    [Authorize]
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult UserLogin(UserInfo ui)
        {
            bool sonuc = Membership.ValidateUser(ui.Adi, ui.Parol);
            if (sonuc)
            {
                FormsAuthentication.RedirectFromLoginPage(ui.Adi, false);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View("Index");
            }
        }



        public ActionResult UserLogout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}