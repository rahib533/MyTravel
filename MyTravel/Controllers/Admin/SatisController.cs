using MyTravel.App_Classes;
using MyTravel.Entity;
using MyTravel.MyEntityORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTravel.Controllers.Admin
{
    [Authorize]
    public class SatisController : Controller
    {
        // GET: Satis
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sifaris()
        {
            List<Satis> data = Tools.Context.Satis.Where(x => x.IsSaled == false && x.IsActive == true).OrderByDescending(x => x.Id).ToList();
            return View(data);
        }

        public ActionResult Satilan()
        {
            List<Satis> data = Tools.Context.Satis.Where(x => x.IsSaled == true && x.IsActive == true).OrderByDescending(x => x.Id).ToList();
            return View(data);
        }

        public ActionResult SifarisTesdiqle(int id)
        {
            Satis s = Tools.Context.Satis.Find(id);
            s.IsSaled = true;
            int a = Tools.Context.SaveChanges();
            if (a==0)
            {
                return View(0);
            }
            else
            {
                return View(1);
            }
            
        }

        public ActionResult SifarisSil(int id)
        {
            Satis s = Tools.Context.Satis.Find(id);
            s.IsActive = false;
            s.IsSaled = false;
            int a = Tools.Context.SaveChanges();
            if (a == 0)
            {
                return View(0);
            }
            else
            {
                return View(1);
            }
        }

        public ActionResult SatisSil(int id)
        {
            Satis s = Tools.Context.Satis.Find(id);
            s.IsActive = false;
            s.IsSaled = false;
            int a = Tools.Context.SaveChanges();
            if (a == 0)
            {
                return View(0);
            }
            else
            {
                return View(1);
            }
        }
    }
}