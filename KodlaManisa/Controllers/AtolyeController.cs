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
        // GET: Atolye
        KodlaManisaEntities db = new KodlaManisaEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AtolyeEkle()
        {
            List<SelectListItem> ilceler = (from i in db.tblIlcelers.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.IlceAdi,
                                             Value = i.IlceID.ToString()
                                         }).ToList();
            ViewBag.ilce = ilceler;

            List<SelectListItem> atolyeTuru = (from i in db.tblAtolyeTurus.ToList()
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
            var ilce = db.tblIlcelers.Where(m => m.IlceID == p.tblIlceler.IlceID).FirstOrDefault();
            var tur = db.tblAtolyeTurus.Where(m => m.AtolyeTurID == p.tblAtolyeTuru.AtolyeTurID).FirstOrDefault();
            p.tblIlceler = ilce;
            p.tblAtolyeTuru = tur;
            db.tblAtolyelers.Add(p);
            db.SaveChanges();
            return RedirectToAction("Atolyeler");
        }

        public ActionResult AtolyeGetir(int id)
        {
            var atolye = db.tblAtolyelers.Find(id);

            List<SelectListItem> ilceler = (from i in db.tblIlcelers.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.IlceAdi,
                                                Value = i.IlceID.ToString()
                                            }).ToList();
            ViewBag.ilce = ilceler;

            List<SelectListItem> atolyeTuru = (from i in db.tblAtolyeTurus.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.AtolyeTurAdi,
                                                   Value = i.AtolyeTurID.ToString()
                                               }).ToList();
            ViewBag.atolyeTuru = atolyeTuru;

            return View("AtolyeGetir",atolye);
        }

        public ActionResult Guncelle(tblAtolyeler p)
        {
           
            var atolye = db.tblAtolyelers.Find(p.AtolyeID); 
            atolye.AtolyeIlcesi = p.AtolyeIlcesi;
            atolye.AtolyeTuru = p.AtolyeTuru;
            atolye.AtolyeAdi = p.AtolyeAdi;
            atolye.AtolyeAdres = p.AtolyeAdres;
            db.SaveChanges();
            return RedirectToAction("Atolyeler","Atolye");
        }

        public ActionResult Sil(int id)
        {
            var atolye = db.tblAtolyelers.Find(id);
            db.tblAtolyelers.Remove(atolye);
            db.SaveChanges();
            return RedirectToAction("Atolyeler");
        }

        public ActionResult Atolyeler()
        {
            var atolyeler = db.tblAtolyelers.ToList();
            return View(atolyeler);
        }
    }
}

