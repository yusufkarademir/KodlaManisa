using KodlaManisa.Models;
using KodlaManisa.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                                                Value = i.ID.ToString()
                                            }).ToList();
            ViewBag.ilce = ilceler;

            //List<SelectListItem> okullar = (from i in db.tblOkullar.ToList()
            //                                select new SelectListItem
            //                                {
            //                                    Text = i.OkulAdi,
            //                                    Value = i.ID.ToString()
            //                                }).ToList();
            //ViewBag.okul = okullar;

            List<SelectListItem> ogretmenler = (from i in db.tblOgretmenler.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.OgretmenAdi,
                                                    Value = i.ID.ToString()
                                                }).ToList();
            ViewBag.ogretmen = ogretmenler;

            List<SelectListItem> siniflar = (from i in db.tblOkulSiniflar.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.SinifAdi,
                                                 Value = i.ID.ToString()
                                             }).ToList();
            ViewBag.sinif = siniflar;

            return View();
        }
        [HttpPost]
        public ActionResult OgrenciEkle(tblOgrenciler p)
        {
            var ogretmen = db.tblOgretmenler.Where(m => m.ID == p.Ogretmen.ID).FirstOrDefault();
            var sinif = db.tblOkulSiniflar.Where(m => m.ID == p.OkulSinif.ID).FirstOrDefault();
            p.Ogretmen = ogretmen;
            p.OkulSinif = sinif;
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
                                                Value = i.ID.ToString()
                                            }).ToList();
            ViewBag.ilce = ilceler;

            List<SelectListItem> okullar = (from i in db.tblOkullar.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.OkulAdi,
                                                Value = i.ID.ToString()
                                            }).ToList();
            ViewBag.okul = okullar;

            List<SelectListItem> ogretmenler = (from i in db.tblOgretmenler.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.OgretmenAdi,
                                                    Value = i.ID.ToString()
                                                }).ToList();
            ViewBag.ogretmen = ogretmenler;

            List<SelectListItem> siniflar = (from i in db.tblOkulSiniflar.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.SinifAdi,
                                                 Value = i.ID.ToString()
                                             }).ToList();
            ViewBag.sinif = siniflar;

            return View("OgrenciGuncelle", ogrenci);
        }

        public ActionResult Guncelle(tblOgrenciler p)
        {
            var ogrenci = db.tblOgrenciler.Find(p.ID);
            var sinif = db.tblOkulSiniflar.Where(m => m.ID == p.OkulSinif.ID).FirstOrDefault();
            var ogretmen = db.tblOgretmenler.Where(m => m.ID == p.Ogretmen.ID).FirstOrDefault();
            ogrenci.OgrenciTC = p.OgrenciTC;
            ogrenci.OgrenciAdi = p.OgrenciAdi;
            ogrenci.OgrenciSoyadi = p.OgrenciSoyadi;
            ogrenci.OgrenciNo = p.OgrenciNo;
            ogrenci.OgenciTelefon = p.OgenciTelefon;
            ogrenci.OgrenciEposta = p.OgrenciEposta;
            ogrenci.OgrenciVeli = p.OgrenciVeli;
            ogrenci.OgrenciVeliTelefon = p.OgrenciVeliTelefon;
            ogrenci.OgrenciVeliEposta = p.OgrenciVeliEposta;

            ogrenci.Ogretmen = ogretmen;
            ogrenci.OkulSinif = sinif;
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

        public ActionResult OgrenciDetay(int? id)
        {
            var ogrenci = db.tblOgrenciler.Find(id);
            return View(ogrenci);
        }

        [HttpGet]
        public ActionResult OgrenciYonlendir()
        {
            //int ogretmenId = 1;

            //int soruId = 1;
            // buraya, atölyeye öğrenci yönlendirecek öğretmenin sadece kendi eklediği (okulundaki kendi öğrencileri) gelecek şekilde filtreleme kodu gelecek.
            //db.tblOgrenciler.Where(i => i.OgrenciOgretmenID == ogretmenId).ToList();

            //db.tblOrtaokulSorular.Where(i => i.SoruID == soruId && i. ).SelectMany(i=> i.tblOkullar.tblOgretmenler).ToList();

            var ogrenciler = db.tblOgrenciler.ToList();
            return View(ogrenciler);
        }


        public ActionResult AtolyeOgrenciKaydet(int id)
        {
            var ogrenci = db.tblOgrenciler.Find(id);

            //var atolyeOgrenci = db.tblAtolyeKursOgrencileri.Add();
            //    atolyeOgrenci.OgrenciID = id;
            //    atolyeOgrenci.KursID = null;
            //    atolyeOgrenci.OgrenciNot = null;
            //    atolyeOgrenci.OgretmenGorusu = null;
            //    db.SaveChanges();
            return View();
        }

    }
}