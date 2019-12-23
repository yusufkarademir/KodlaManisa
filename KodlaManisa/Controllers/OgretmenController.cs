using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KodlaManisa.Models.EntityFramework;

namespace KodlaManisa.Controllers
{
    public class OgretmenController : Controller
    {
        // GET: Ogretmen
        KodlaManisaEntities db = new KodlaManisaEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ogretmenler()
        {
            var ogretmenler = db.tblOgretmenlers.ToList();
            return View(ogretmenler);
        }

        public ActionResult OgretmenEkle()
        {
            return View();
        }

        public ActionResult Bilgilerim()
        {
            return View();
        }

        public ActionResult OkulBilgileri()
        {
            return View();
        }

    }
}