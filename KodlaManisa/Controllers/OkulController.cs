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
            var okullar = db.tblOkullar.ToList();
            return View(okullar);
        }

        [HttpGet]
        public ActionResult OkulEkle()
        {
            List<SelectListItem> ilceler = (from i in db.tblIlceler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.IlceAdi,
                                                Value = i.IlceID.ToString()
                                            }).ToList();
            ViewBag.ilce = ilceler;

            List<SelectListItem> okulTuru = (from i in db.tblOkulTuru.ToList()
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
            var ilce = db.tblIlceler.Where(m => m.IlceID == p.tblIlceler.IlceID).FirstOrDefault();
            var tur = db.tblOkulTuru.Where(m => m.OkulTuruID == p.tblOkulTuru.OkulTuruID).FirstOrDefault();
            p.tblIlceler = ilce;
            p.tblOkulTuru = tur;
            db.tblOkullar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Okullar");
        }

        public ActionResult OkulGuncelle(int id)
        {
            var okul = db.tblOkullar.Find(id);

            List<SelectListItem> ilceler = (from i in db.tblIlceler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.IlceAdi,
                                                Value = i.IlceID.ToString()
                                            }).ToList();
            ViewBag.ilce = ilceler;

            List<SelectListItem> okulTuru = (from i in db.tblOkulTuru.ToList()
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
            var okul = db.tblOkullar.Find(p.OkulID);
            var ilce = db.tblIlceler.Where(m => m.IlceID == p.tblIlceler.IlceID).FirstOrDefault();
            var tur = db.tblOkulTuru.Where(m => m.OkulTuruID == p.tblOkulTuru.OkulTuruID).FirstOrDefault();
            okul.OkulKodu = p.OkulKodu;
            okul.tblIlceler = ilce;
            okul.tblOkulTuru = tur;
            okul.OkulAdi = p.OkulAdi;
            okul.OkulMuduru = p.OkulMuduru;
            okul.OkulTel = p.OkulTel;
            okul.OkulAdres = p.OkulAdres;
            db.SaveChanges();
            return RedirectToAction("Okullar", "Okul");
        }

        public ActionResult Sil(int id)
        {
            var okul = db.tblOkullar.Find(id);
            db.tblOkullar.Remove(okul);
            db.SaveChanges();
            return RedirectToAction("Okullar");
        }

    }
}