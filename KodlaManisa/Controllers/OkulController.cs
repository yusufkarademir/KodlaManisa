using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KodlaManisa.Models.EntityFramework;

namespace KodlaManisa.Controllers
{
    public class OkulController : Controller
    {
        // GET: Okul
        KodlaManisaEntities db = new KodlaManisaEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Okullar()
        {
            var okullar = db.tblOkullars.ToList();
            return View(okullar);
        }
        [HttpGet]
        public ActionResult OkulEkle()
        {
            List<SelectListItem> ilceler = (from i in db.tblIlcelers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.IlceAdi,
                                                Value = i.IlceID.ToString()
                                            }).ToList();
            ViewBag.ilce = ilceler;

            List<SelectListItem> okulTuru = (from i in db.tblOkulTurus.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.OkulTuru,
                                                   Value = i.OkulTuruID.ToString()
                                               }).ToList();
            ViewBag.okulTuru = okulTuru;

            return View();
        }

        [HttpPost]
        public ActionResult OkulEkle(tblOkullar p)
        {
            var ilce = db.tblIlcelers.Where(m => m.IlceID == p.tblIlceler.IlceID).FirstOrDefault();
            var tur = db.tblOkulTurus.Where(m => m.OkulTuruID == p.tblOkulTuru.OkulTuruID).FirstOrDefault();
            p.tblIlceler = ilce;
            p.tblOkulTuru = tur;
            db.tblOkullars.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult OkulGuncelle(int id)
        {
            var okul = db.tblOkullars.Find(id);

            List<SelectListItem> ilceler = (from i in db.tblIlcelers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.IlceAdi,
                                                Value = i.IlceID.ToString()
                                            }).ToList();
            ViewBag.ilce = ilceler;

            List<SelectListItem> okulTuru = (from i in db.tblOkulTurus.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.OkulTuru,
                                                 Value = i.OkulTuruID.ToString()
                                             }).ToList();
            ViewBag.okulTuru = okulTuru;

            return View("OkulGuncelle",okul);
        }

        public ActionResult Guncelle(tblOkullar p)
        {
            var okul = db.tblOkullars.Find(p.OkulID);
            okul.OkulKodu = p.OkulKodu;
            okul.OkulIlceAdi = p.OkulIlceAdi;
            okul.OkulTuru = p.OkulTuru;
            okul.OkulAdi = p.OkulAdi;
            okul.OkulAdres = p.OkulAdres;
            db.SaveChanges();
            return RedirectToAction("Okullar", "Okul");
        }
    }
}