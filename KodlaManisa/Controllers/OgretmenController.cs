using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KodlaManisa.Models;
using KodlaManisa.Models.Database;
using KodlaManisa.ViewModels;

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
            var ogretmenler = db.tblOgretmenler.ToList();

            //List<SelectListItem> Okullar = (from i in db.tblOkullar.ToList()
            //                                select new SelectListItem
            //                                {
            //                                    Text = i.OkulAdi,s
            //                                    Value = i.ID.ToString()
            //                                }).ToList();
           
            //ViewBag.okul = Okullar;
            return View(ogretmenler);
        }

        [HttpGet]
        public ActionResult OgretmenEkle()
        {
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
            return View();
        }
        [HttpPost]
        public ActionResult OgretmenEkle(tblOgretmenler p)
        {
            //var ilce = db.tblIlceler.Where(m => m.ID == p.OkulOgretmenler.).FirstOrDefault();
            //var okul = db.tblOkullar.Where(m => m.ID == p.OkulOgretmenler).FirstOrDefault();
            //p.OkulOgretmenler = ilce;
            //p.OkulOgretmenler = okul;
            //db.tblOgretmenler.Add(p);
            //db.SaveChanges();
            return RedirectToAction("Ogretmenler");
        }

        public ActionResult OgretmenGuncelle(int id)
        {
            var ogretmen = db.tblOgretmenler.Find(id);

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

            return View("OgretmenGuncelle", ogretmen);
        }
        public ActionResult Guncelle(tblOgretmenler p)
        {
            var ogretmen = db.tblOgretmenler.Find(p.ID);
            //var ilce = db.tblIlceler.Where(m => m.ID == p.OkulOgretmenler.).FirstOrDefault();
            //var okul = db.tblOkullar.Where(m => m.ID == p.tblOkullar.ID).FirstOrDefault();
            //ogretmen.tblIlceler = ilce;
            //ogretmen.tblOkullar = okul;
            //ogretmen.OgretmenAdi = p.OgretmenAdi;
            //ogretmen.OgretmenSoyadi = p.OgretmenSoyadi;
            //ogretmen.OgretmenBrans = p.OgretmenBrans;
            //ogretmen.OgretmenMezuniyet = p.OgretmenMezuniyet;
            //ogretmen.OgretmenTel = p.OgretmenTel;
            //ogretmen.OgretmenEposta = p.OgretmenEposta;
            //db.SaveChanges();
            return RedirectToAction("Ogretmenler", "Ogretmen");
        }

        public ActionResult Sil(int id)
        {
            var ogretmen = db.tblOgretmenler.Find(id);
            db.tblOgretmenler.Remove(ogretmen);
            db.SaveChanges();
            return RedirectToAction("Ogretmenler");
        }
        public ActionResult Bilgilerim(int id = 376)
        {
            var ogretmen = db.tblOgretmenler.Find(id);
            ViewBag.ogretmen = ogretmen;

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

            return View("Bilgilerim", ogretmen);
        }

        public ActionResult SifreDegistir()
        {
            return View();
        }

        public ActionResult OkulBilgileri()
        {
            return View();
        }

        public ActionResult OgretmenDetay(int id)
        {

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //var ogretmen = db.tblOgretmenler.Find(id);
            //if (ogretmen == null)
            //{
            //    return HttpNotFound();
            //}
            var tuple = new Tuple<tblOgretmenler, tblOgretmenGorevleri, tblOgretmenDYKBilgileri, tblOkulOgretmenler>(new tblOgretmenler(), new tblOgretmenGorevleri(), new tblOgretmenDYKBilgileri(), new tblOkulOgretmenler());

            return View(tuple);

        }


    }
}