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
    public class MehsulOzellikController : Controller
    {
        // GET: MehsulOzellik
        public ActionResult Index()
        {
            List<Mehsul> data = Tools.Context.Mehsul.Where(x=>x.IsActive==true).ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult MehsulunOzelliyi(int id)
        {
            List<MehsulOzellik> data = Tools.Context.MehsulOzellik.Where(x => x.IsActive == true && x.MehsulID == id).ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Add(int id)
        {
            Mehsul data = Tools.Context.Mehsul.Find(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Add2(MehsulOzellik mo)
        {
            mo.IsActive = true;
            MehsulOzellik data = new MehsulOzellik();
            if (mo.OzellikDeyerID!=0)
            {
                data  = AllEntityORM.MehsulOzellikORM.Add(mo);
            }
            
            if (data==null)
            {
                return View(0);
            }
            return View(1);
        }

        public PartialViewResult MehsulPW(int? id)
        {
            List<Mehsul> data = Tools.Context.Mehsul.Where(x => x.KategoriyaID == id && x.IsActive == true).ToList();
            return PartialView(data);
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

        [HttpPost]
        public ActionResult Sil(int mehsulId, int tipId, int deyerId)
        {
            MehsulOzellik mo = Tools.Context.MehsulOzellik.FirstOrDefault(x => x.MehsulID == mehsulId && x.OzellikTipID == tipId && x.OzellikDeyerID == deyerId);
            mo.IsActive = false;
            AllEntityORM.MehsulOzellikORM.Update(mo);
            return RedirectToAction("Index");
        }
    }
}