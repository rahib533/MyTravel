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
    public class KategoriyaController : Controller
    {
        // GET: Kategoriya
        public ActionResult Index()
        {
            return View(Tools.Context.Kategoriya.ToList());
        }

        [HttpGet]
        public ActionResult KategoriyaAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriyaAdd(Kategoriya k)
        {
            k.IsActive = true;
            AllEntityORM.KategoriORM.Add(k);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult PhotoAdd(int id)
        {
            Kategoriya data = AllEntityORM.KategoriORM.SelectById(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult PhotosAdd(int id, HttpPostedFileBase fileUpload)
        {
            if (fileUpload != null)
            {
                Image img = Image.FromStream(fileUpload.InputStream);

                Bitmap bm = new Bitmap(img, Tools.MehsulBoyuk);
                Bitmap bm2 = new Bitmap(img, Tools.MehsulOrta);
                Bitmap bm3 = new Bitmap(img, Tools.MehsulKicik);

                string way = "/Content/KategoriyaSekil/BoyukYol/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);
                string way2 = "/Content/KategoriyaSekil/OrtaYol/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);
                string way3 = "/Content/KategoriyaSekil/KicikYol/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);

                bm.Save(Server.MapPath(way));
                bm2.Save(Server.MapPath(way2));
                bm3.Save(Server.MapPath(way3));

                Photos p = new Photos();
                p.BoyukYol = way;
                p.OrtaYol = way2;
                p.KicikYol = way3;
                p.KategoriyaID = id;
                p.IsActive = true;
                if (!Tools.Context.Photos.Any(x => x.Main == true && x.KategoriyaID==id))
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
            List<Photos> data = Tools.Context.Photos.Where(x => x.KategoriyaID == id).ToList();
            ViewBag.Kategoriya = AllEntityORM.KategoriORM.SelectById(id);
            return View(data);
        }

        public ActionResult Sil(int id)
        {
            Kategoriya k = Tools.Context.Kategoriya.Find(id);
            k.IsActive = false;
            AllEntityORM.KategoriORM.Update(k);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Kategoriya data = AllEntityORM.KategoriORM.SelectById(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Update2(Kategoriya m)
        {
            Kategoriya b = Tools.Context.Kategoriya.Find(m.Id);
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
    