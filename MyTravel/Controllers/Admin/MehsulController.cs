using MyTravel.App_Classes;
using MyTravel.Entity;
using MyTravel.MyEntityORM;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTravel.Controllers.Admin
{
    [Authorize]
    public class MehsulController : Controller
    {
        // GET: Mehsul
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult IndexPW()
        {
            return PartialView(Tools.Context.Mehsul.ToList());
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Kategoriyalar = Tools.Context.Kategoriya.Where(x=>x.IsActive==true).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Add(Mehsul m)
        {
            m.IsActive = true;
            AllEntityORM.MehsulORM.Add(m);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult PhotoAdd(int id)
        {
            Mehsul m = AllEntityORM.MehsulORM.SelectById(id);
            return View(m);
        }

        [HttpPost]
        public ActionResult PhotosAdd(int id, HttpPostedFileBase fileUpload)
        {
            //int a = -1;
            if (fileUpload!=null)
            {
                Image img = Image.FromStream(fileUpload.InputStream);

                Bitmap bm = new Bitmap(img, Tools.MehsulBoyuk);
                Bitmap bm2 = new Bitmap(img, Tools.MehsulOrta);
                Bitmap bm3 = new Bitmap(img, Tools.MehsulKicik);

                string way = "/Content/MehsulSekil/BoyukYol/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);
                string way2 = "/Content/MehsulSekil/OrtaYol/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);
                string way3 = "/Content/MehsulSekil/KicikYol/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);

                bm.Save(Server.MapPath(way));
                bm2.Save(Server.MapPath(way2));
                bm3.Save(Server.MapPath(way3));

                Photos p = new Photos();
                p.BoyukYol = way;
                p.OrtaYol = way2;
                p.KicikYol = way3;
                p.IsActive = true;
                p.MehsulID = id;
                if (!Tools.Context.Photos.Any(x=>x.Main==true && x.MehsulID==id))
                {
                    p.Main = true;
                }
                else
                {
                    p.Main = false;
                }

                AllEntityORM.PhotoORM.Add(p);

                return View(1);
            }
            return View(0);
        }

        [HttpGet]
        public ActionResult Sekil(int id)
        {
            Mehsul m = Tools.Context.Mehsul.Find(id);
            List<Photos> data = Tools.Context.Photos.Where(x => x.MehsulID == id && x.IsActive==true).ToList();
            ViewBag.Mehsul = m;
            return View(data);
        }

        public ActionResult Sil(int id)
        {
            Mehsul m = Tools.Context.Mehsul.Find(id);
            m.IsActive = false;
            Tools.Context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Mehsul data = AllEntityORM.MehsulORM.SelectById(id);
            ViewBag.Kategoriyalar = Tools.Context.Kategoriya.Where(x => x.IsActive == true).ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult Update2(Mehsul m)
        {
            Mehsul b = Tools.Context.Mehsul.Find(m.Id);
            b.Adi = m.Adi;
            b.Aciqlama = m.Aciqlama;
            b.Endirimi = m.Endirimi;
            b.Haqqinda = m.Haqqinda;
            b.Qiymeti = m.Qiymeti;
            b.Tarixi = m.Tarixi;
            b.IsActive = true;
            int a = Tools.Context.SaveChanges();
            
            if (a==0)
            {
                return View(0);
            }
            return View(1);
        }

        public ActionResult SekilSil(int id)
        {
            Photos p = Tools.Context.Photos.Find(id);
            p.IsActive = false;
            int a = Tools.Context.SaveChanges();

            if (a == 0)
            {
                return View(0);
            }
            return View(1);
        }
    }
}