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
    public class OzellikTipController : Controller
    {
        // GET: OzellikTip
        public ActionResult Index()
        {
            List<OzellikTip> data = Tools.Context.OzellikTip.ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Kategoriyalar = AllEntityORM.KategoriORM.Select();
            return View();
        }

        [HttpPost]
        public ActionResult Add(OzellikTip ozt)
        {
            ozt.IsActive = true;
            AllEntityORM.OzellikTipORM.Add(ozt);
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            OzellikTip ozt = Tools.Context.OzellikTip.Find(id);
            ozt.IsActive = false;
            Tools.Context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            OzellikTip data = AllEntityORM.OzellikTipORM.SelectById(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Update2(OzellikTip m)
        {
            OzellikTip b = Tools.Context.OzellikTip.Find(m.Id);
            b.Adi = m.Adi;
            b.Aciqlama = m.Aciqlama;
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