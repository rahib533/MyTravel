using MyTravel.App_Classes;
using MyTravel.Entity;
using MyTravel.MyEntityORM;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTravel.Controllers.Admin
{
    [Authorize]
    public class PhotoController : Controller
    {
        // GET: Photo
        public ActionResult Index()
        {
            List<Photos> data = Tools.Context.Photos.Where(x => x.IsActive==true && x.BoyukYol.Contains("SlideSekil")).ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add2(HttpPostedFileBase fileUpload)
        {
            if (fileUpload != null)
            {
                Image img = Image.FromStream(fileUpload.InputStream);

                Bitmap bm = new Bitmap(img, Tools.Slider);

                string way = "/Content/SlideSekil/BoyukYol/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);

                bm.Save(Server.MapPath(way));


                Photos p = new Photos();
                p.BoyukYol = way;
                p.IsActive = true;


                AllEntityORM.PhotoORM.Add(p);

                return View(1);
            }
            return View(0);
        }

        public ActionResult Sil(int id)
        {
            Photos p = Tools.Context.Photos.Find(id);
            p.IsActive = false;
            int a = Tools.Context.SaveChanges();

            if (a==0)
            {
                return View(0);
            }
            return View(1);
        }
    }
}