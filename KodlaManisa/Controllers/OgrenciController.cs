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
            var ogrenciler = db.tblOgrenciler.ToList();
            return View(ogrenciler);
        }
        [HttpGet]
        public ActionResult OgrenciEkle()
        {
            List<SelectListItem> ilceler = (from i in db.tblIlceler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.IlceAdi,
                                                Value = i.IlceID.ToString()
                                            }).ToList();
            ViewBag.ilce = ilceler;

            List<SelectListItem> okullar = (from i in db.tblOkullar.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.OkulAdi,
                                                Value = i.OkulID.ToString()
                                            }).ToList();
            ViewBag.okul = okullar;

            List<SelectListItem> ogretmenler = (from i in db.tblOgretmenler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.OgretmenAdi,
                                                Value = i.OgretmenID.ToString()
                                            }).ToList();
            ViewBag.ogretmen= ogretmenler;

            List<SelectListItem> siniflar = (from i in db.tblOkulSiniflar.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.SinifAdi,
                                                    Value = i.SinifID.ToString()
                                                }).ToList();
            ViewBag.sinif = siniflar;

            return View();
        }
        [HttpPost]
        public ActionResult OgrenciEkle(tblOgrenciler p)
        {
            var ilce = db.tblIlceler.Where(m => m.IlceID == p.tblIlceler.IlceID).FirstOrDefault();
            var okul = db.tblOkullar.Where(m => m.OkulID == p.tblOkullar.OkulID).FirstOrDefault();
            var ogretmen = db.tblOgretmenler.Where(m => m.OgretmenID == p.tblOgretmenler.OgretmenID).FirstOrDefault();
            var sinif = db.tblOkulSiniflar.Where(m => m.SinifID == p.tblOkulSiniflar.SinifID).FirstOrDefault();
            p.tblIlceler = ilce;
            p.tblOkullar = okul;
            p.tblOgretmenler = ogretmen;
            p.tblOkulSiniflar = sinif;
            db.tblOgrenciler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Ogrenciler");
        }


        public ActionResult OgrenciGuncelle(int id)
        {

            var ogrenci = db.tblOgrenciler.Find(id);

            List<SelectListItem> ilceler = (from i in db.tblIlceler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.IlceAdi,
                                                Value = i.IlceID.ToString()
                                            }).ToList();
            ViewBag.ilce = ilceler;

            List<SelectListItem> okullar = (from i in db.tblOkullar.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.OkulAdi,
                                                Value = i.OkulID.ToString()
                                            }).ToList();
            ViewBag.okul = okullar;

            List<SelectListItem> ogretmenler = (from i in db.tblOgretmenler.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.OgretmenAdi,
                                                    Value = i.OgretmenID.ToString()
                                                }).ToList();
            ViewBag.ogretmen = ogretmenler;

            List<SelectListItem> siniflar = (from i in db.tblOkulSiniflar.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.SinifAdi,
                                                 Value = i.SinifID.ToString()
                                             }).ToList();
            ViewBag.sinif = siniflar;

            return View("OgrenciGuncelle", ogrenci);
        }

        public ActionResult Guncelle(tblOgrenciler p)
        {
            var ogrenci = db.tblOgrenciler.Find(p.OgrenciID);
            var ilce = db.tblIlceler.Where(m => m.IlceID == p.tblIlceler.IlceID).FirstOrDefault();
            var okul = db.tblOkullar.Where(m => m.OkulID == p.tblOkullar.OkulID).FirstOrDefault();
            var sinif = db.tblOkulSiniflar.Where(m => m.SinifID == p.tblOkulSiniflar.SinifID).FirstOrDefault();
            var ogretmen = db.tblOgretmenler.Where(m => m.OgretmenID == p.tblOgretmenler.OgretmenID).FirstOrDefault();
            ogrenci.OgrenciTC = p.OgrenciTC;
            ogrenci.OgrenciAdi = p.OgrenciAdi;
            ogrenci.OgrenciSoyadi = p.OgrenciSoyadi;
            ogrenci.OgrenciNo = p.OgrenciNo;
            ogrenci.OgenciTelefon = p.OgenciTelefon;
            ogrenci.OgrenciEposta = p.OgrenciEposta;
            ogrenci.OgrenciVeli = p.OgrenciVeli;
            ogrenci.OgrenciVeliTelefon = p.OgrenciVeliTelefon;
            ogrenci.OgrenciVeliEposta = p.OgrenciVeliEposta;
            db.SaveChanges();
            return RedirectToAction("Ogrenciler", "Ogrenci");



        }

        public ActionResult Sil(int id)
        {
            var ogrenci = db.tblOgrenciler.Find(id);
            db.tblOgrenciler.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Ogrenciler");
            
        }

    }
}