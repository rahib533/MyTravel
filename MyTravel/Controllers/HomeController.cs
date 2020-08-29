using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTravel.Controllers
{
    using Entity;
    using MyTravel.MyEntityORM;
    using Repository;


    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Mehsul> data = Tools.Context.Mehsul.Where(x => x.IsActive == true).ToList();
            return View(data);
        }
        
        public PartialViewResult Slider()
        {
            List<Photos> data = Tools.Context.Photos.Where(x => x.BoyukYol.Contains("SlideSekil") == true && x.IsActive == true).ToList();
            return PartialView(data);
        }

        public ActionResult GetMehsul(int id)
        {
            List<Mehsul> data = Tools.Context.Mehsul.OrderByDescending(x => x.Id).Take(10).Where(x=>x.IsActive==true).ToList();
            List<Kategoriya> data2 = Tools.Context.Kategoriya.Where(x => x.IsActive == true).ToList();
            ViewBag.TopOn = data;
            ViewBag.Kategoriyalar = data2;
            Mehsul m = Tools.Context.Mehsul.Find(id);
            return View(m);
        }

        public ActionResult Haqqimizda()
        {
            return View();
        }

        public ActionResult Elaqe()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Messaj(Messaj m)
        {
            m.IsActive = true;
            m.IsRead = false;
           
            if ( m.Name==null || m.Phone==null || m.MessageText==null || m.Surname==null)
            {
                return View(0);
            }
            Messaj data = AllEntityORM.MessajORM.Add(m);
            if (data==null)
            {
                return View(0);
            }
            else
            {
                return View(1);
            }
        }

        public ActionResult Kategoriyalar()
        {
            List<Kategoriya> data = Tools.Context.Kategoriya.Where(x => x.IsActive == true).ToList();
            return View(data);
        }

        public ActionResult GetKategoriya(int id)
        {
            Kategoriya k = AllEntityORM.KategoriORM.SelectById(id);
            List<Mehsul> m = Tools.Context.Mehsul.Where(x => x.KategoriyaID == id && x.IsActive == true).OrderByDescending(x=>x.Id).ToList();
            List<Mehsul> ym = Tools.Context.Mehsul.OrderByDescending(x => x.Id).Take(10).Where(x => x.IsActive == true).ToList();
            ViewBag.Mehsullar = m;
            ViewBag.TopOn = ym;
            return View(k);
        }

        public ActionResult MehsulOzellik(int id)
        {
            Mehsul mmm = AllEntityORM.MehsulORM.SelectById(id);
            List<MehsulOzellik> mo = Tools.Context.MehsulOzellik.Where(x => x.MehsulID == id && x.IsActive == true).ToList();

            Dictionary<string, List<OzellikDeyer>> myDictionary = new Dictionary<string, List<OzellikDeyer>>();
            List<OzellikDeyer> OZD = new List<OzellikDeyer>();

            foreach (var item in mo)
            {
                OzellikTip OZT = AllEntityORM.OzellikTipORM.SelectById(item.OzellikTipID);
                OzellikDeyer OZD2 = AllEntityORM.OzellikDeyerORM.SelectById(item.OzellikDeyerID);

                if (myDictionary.Any(x=>x.Key==OZT.Adi))
                {
                    myDictionary[OZT.Adi].Add(OZD2);
                }
                else
                {
                    OZD.Add(OZD2);
                    myDictionary.Add(OZT.Adi, OZD);
                    OZD = new List<OzellikDeyer>();
                }
            }

            ViewBag.Dictionary = myDictionary;
            
            return View(mmm);
        }

        [HttpPost]
        public ActionResult Sifaris(Satis s, int[] OzellikDeyerID)
        {
            if (s.MehsulID!=0)
            {
                string str = "";
                foreach (int item in OzellikDeyerID)
                {
                    
                    str += AllEntityORM.OzellikDeyerORM.SelectById(item).OzellikTip.Adi + "-" + AllEntityORM.OzellikDeyerORM.SelectById(item).Adi + " |";
                }
                str.Remove(str.Length-1, 1);
                s.SatisOzellikleri = str;
                s.Qiymet = AllEntityORM.MehsulORM.SelectById(s.MehsulID).Qiymeti;
                s.IsActive = true;
                s.IsSaled = false;
                Satis ns = AllEntityORM.SatisORM.Add(s);
                if (ns==null)
                {
                    return View(0);
                }
                else
                {
                    return View(1);
                }
                
            }
            else
            {
                return View(0);
            }

        }
    }
}