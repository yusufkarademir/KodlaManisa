using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KodlaManisa.Models.EntityFramework;

namespace KodlaManisa.Controllers
{
    public class AtolyeController : Controller
    {
       
        KodlaManisaEntities db = new KodlaManisaEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Atolyeler()
        {
            var atolyeler = db.tblAtolyeler.ToList();
            return View(atolyeler);
        }

        [HttpGet]
        public ActionResult AtolyeEkle()
        {
            List<SelectListItem> ilceler = (from i in db.tblIlceler.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.IlceAdi,
                                             Value = i.IlceID.ToString()
                                         }).ToList();
            ViewBag.ilce = ilceler;

            List<SelectListItem> atolyeTuru = (from i in db.tblAtolyeTuru.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.AtolyeTurAdi,
                                                Value = i.AtolyeTurID.ToString()
                                            }).ToList();
            ViewBag.atolyeTuru = atolyeTuru;

            return View();
        }

        [HttpPost]
        public ActionResult AtolyeEkle(tblAtolyeler p)
        {
            var ilce = db.tblIlceler.Where(m => m.IlceID == p.tblIlceler.IlceID).FirstOrDefault();
            var tur = db.tblAtolyeTuru.Where(m => m.AtolyeTurID == p.tblAtolyeTuru.AtolyeTurID).FirstOrDefault();
            p.tblIlceler = ilce;
            p.tblAtolyeTuru = tur;
            db.tblAtolyeler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Atolyeler");
        }

        public ActionResult AtolyeGuncelle(int id)
        {
            var atolye = db.tblAtolyeler.Find(id);

            List<SelectListItem> ilceler = (from i in db.tblIlceler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.IlceAdi,
                                                Value = i.IlceID.ToString()
                                            }).ToList();
            ViewBag.ilce = ilceler;

            List<SelectListItem> atolyeTuru = (from i in db.tblAtolyeTuru.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.AtolyeTurAdi,
                                                   Value = i.AtolyeTurID.ToString()
                                               }).ToList();
            ViewBag.atolyeTuru = atolyeTuru;
            return View("AtolyeGuncelle",atolye);
        }

        public ActionResult Guncelle(tblAtolyeler p)
        {           
            var atolye = db.tblAtolyeler.Find(p.AtolyeID);
            var ilce = db.tblIlceler.Where(m => m.IlceID == p.tblIlceler.IlceID).FirstOrDefault();
            var tur = db.tblAtolyeTuru.Where(m => m.AtolyeTurID == p.tblAtolyeTuru.AtolyeTurID).FirstOrDefault();
            atolye.tblIlceler = ilce;
            atolye.tblAtolyeTuru = tur;       
            atolye.AtolyeAdi = p.AtolyeAdi;
            atolye.AtolyeAdres = p.AtolyeAdres;
            db.SaveChanges();
            return RedirectToAction("Atolyeler","Atolye");
        }

        public ActionResult Sil(int id)
        {
            var atolye = db.tblAtolyeler.Find(id);
            db.tblAtolyeler.Remove(atolye);
            db.SaveChanges();
            return RedirectToAction("Atolyeler");
        }

        public ActionResult AtolyeDetay (int id)
        {
            var atolye = db.tblAtolyeler.Find(id);
            var malzeme = db.tblAtolyeMalzemeler.Where(m => m.AtolyeID == id).FirstOrDefault();
                      
            return View("AtolyeDetay", atolye);



        }


    }
}

