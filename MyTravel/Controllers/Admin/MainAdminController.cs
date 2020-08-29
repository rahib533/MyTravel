using MyTravel.App_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyTravel.Controllers.Admin
{
    [Authorize(Roles ="admin")]
    public class MainAdminController : Controller
    {
        // GET: MainAdmin
        public ActionResult Index()
        {
            MembershipUserCollection muc = Membership.GetAllUsers();
            return View(muc);
        }

        public ActionResult UserAdd()
        {
            return View();
        }


        [HttpPost]
        public ActionResult UserAdd(UserInfo ui)
        {
            MembershipCreateStatus veziyyet;
            string msg = "";
            Membership.CreateUser(ui.Adi, ui.Parol, ui.Email, ui.GizliSual, ui.GizliCavab, true, out veziyyet);
            switch (veziyyet)
            {
                case MembershipCreateStatus.Success:
                    break;
                case MembershipCreateStatus.InvalidUserName:
                    msg += " Uygun olmayan istifadeci adi";
                    break;
                case MembershipCreateStatus.InvalidPassword:
                    msg += " Uygun olmayan Shifre";
                    break;
                case MembershipCreateStatus.InvalidQuestion:
                    msg += " Uygun olmayan Gizli sual";
                    break;
                case MembershipCreateStatus.InvalidAnswer:
                    msg += " Uygun olmayan Gizli cavab";
                    break;
                case MembershipCreateStatus.InvalidEmail:
                    msg += " Uygun olmayan email";
                    break;
                case MembershipCreateStatus.DuplicateUserName:
                    msg += " Istifadeci adi tekrardir";
                    break;
                case MembershipCreateStatus.DuplicateEmail:
                    msg += " email tekrardir";
                    break;
                case MembershipCreateStatus.UserRejected:
                    msg += " Istifadeci blok xetasi";
                    break;
                case MembershipCreateStatus.InvalidProviderUserKey:
                    msg += " Uygun olmayan Istifadeci key xetasi";
                    break;
                case MembershipCreateStatus.DuplicateProviderUserKey:
                    msg += " Istifadeci keyi tekrardir";
                    break;
                case MembershipCreateStatus.ProviderError:
                    msg += " Provider Error";
                    break;
                default:
                    break;
            }

            ViewBag.Mesaj = msg;
            if (veziyyet == MembershipCreateStatus.Success)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Rollar()
        {
            List<string> rollar = Roles.GetAllRoles().ToList();
            return View(rollar);
        }

        public ActionResult RolAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RolAdd(string rol)
        {
            Roles.CreateRole(rol);
            return RedirectToAction("Rollar");
        }

        public ActionResult UserRol(string id)
        {
            MembershipUserCollection mu = Membership.FindUsersByName(id);
            ViewBag.Rollar = Roles.GetAllRoles();
            return View(mu);
        }


        [HttpPost]
        public ActionResult UserRol(UserInfo ui)
        {
            Roles.AddUserToRole(ui.Adi, ui.UserRol);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UserSil(string id)
        {
            if (id != null)
            {
                Membership.DeleteUser(id);
            }
            return RedirectToAction("Index");
        }
    }
}