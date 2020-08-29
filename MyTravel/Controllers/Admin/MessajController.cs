using MyTravel.App_Classes;
using MyTravel.Entity;
using MyTravel.MyEntityORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MyTravel.Controllers.Admin
{
    [Authorize]
    public class MessajController : Controller
    {
        // GET: Messaj
        public ActionResult Index()
        {
            List<Messaj> msg = Tools.Context.Messaj.OrderByDescending(x=>x.Id).ToList();
            return View(msg);
        }

        public ActionResult YeniMesaj()
        {
            List<Messaj> msg = Tools.Context.Messaj.Where(x=>x.IsRead==false && x.IsActive==true).OrderByDescending(x => x.Id).ToList();
            return View(msg);
        }

        public ActionResult Oxunan()
        {
            List<Messaj> msg = Tools.Context.Messaj.Where(x => x.IsRead == true && x.IsActive == true).OrderByDescending(x => x.Id).ToList();
            return View(msg);
        }

        public ActionResult Sil(int id)
        {
            Messaj m = Tools.Context.Messaj.Find(id);
            m.IsActive = false;
            m.IsRead = true;
            int sonuc = Tools.Context.SaveChanges(); ;
            if (sonuc!=0)
            {
                return View(1);
            }
            else
            {
                return View(0);
            }
        }

        public ActionResult Oxundu(int id)
        {
            Messaj m = Tools.Context.Messaj.Find(id);
            m.IsRead = true;
            int sonuc = Tools.Context.SaveChanges(); ;
            if (sonuc != 0)
            {
                return View(1);
            }
            else
            {
                return View(0);
            }
        }
    }
}