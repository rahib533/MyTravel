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
    public class OzellikDeyerController : Controller
    {
        // GET: OzellikDeyer
        public ActionResult Index()
        {
            List<OzellikDeyer> data = Tools.Context.OzellikDeyer.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Kategoriyalar = Tools.Context.Kategoriya.Where(x=>x.IsActive==true).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Add(OzellikDeyer ozd)
        {
            ozd.IsActive = true;
            AllEntityORM.OzellikDeyerORM.Add(ozd);
            return RedirectToAction("Index");
        }

        public PartialViewResult OzellikTipPW(int? id)
        {
            List<OzellikTip> data = Tools.Context.OzellikTip.Where(x => x.KategoriyaID == id && x.IsActive==true).ToList();
            return PartialView(data);
        }

        public PartialViewResult OzellikDeyerPW(int? id)
        {
            List<OzellikDeyer> data = Tools.Context.OzellikDeyer.Where(x => x.OzellikTipID == id && x.IsActive==true).ToList();
            return PartialView(data);
        }

        public ActionResult Sil(int id)
        {
            OzellikDeyer ozd = Tools.Context.OzellikDeyer.Find(id);
            ozd.IsActive = false;
            Tools.Context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            OzellikDeyer data = AllEntityORM.OzellikDeyerORM.SelectById(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Update2(OzellikDeyer m)
        {
            OzellikDeyer b = Tools.Context.OzellikDeyer.Find(m.Id);
            b.Adi = m.Adi;
            b.Aciqlama = m.Aciqlama;
            b.OzellikTipID = m.OzellikTipID;
            b.IsActive = true;
            int a = Tools.Context.SaveChanges();

            if (a == 0)
            {
                return View(0);
            }
            return View(1);
        }
    }
}