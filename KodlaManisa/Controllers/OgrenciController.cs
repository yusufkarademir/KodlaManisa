using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KodlaManisa.Models.EntityFramework;

namespace KodlaManisa.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        KodlaManisaEntities db = new KodlaManisaEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ogrenciler()
        {
            var ogrenciler = db.tblOgrencilers.ToList();
            return View(ogrenciler);
        }

        public ActionResult OgrenciEkle()
        {
            return View();
        }
    }
}