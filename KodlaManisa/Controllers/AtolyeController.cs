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
                                                Value = i.ID.ToString()
                                            }).ToList();
            ViewBag.ilce = ilceler;

            List<SelectListItem> atolyeTuru = (from i in db.tblAtolyeTuru.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.AtolyeTurAdi,
                                                   Value = i.ID.ToString()
                                               }).ToList();
            ViewBag.atolyeTuru = atolyeTuru;

            return View();
        }

        [HttpPost]
        public ActionResult AtolyeEkle(tblAtolyeler p)
        {
            var ilce = db.tblIlceler.Where(m => m.ID == p.Ilce.ID).FirstOrDefault();
            var tur = db.tblAtolyeTuru.Where(m => m.ID == p.AtolyeTuru.ID).FirstOrDefault();
            p.Ilce = ilce;
            p.AtolyeTuru= tur;
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
                                                Value = i.ID.ToString()
                                            }).ToList();
            ViewBag.ilce = ilceler;

            List<SelectListItem> atolyeTuru = (from i in db.tblAtolyeTuru.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.AtolyeTurAdi,
                                                   Value = i.ID.ToString()
                                               }).ToList();
            ViewBag.atolyeTuru = atolyeTuru;
            return View("AtolyeGuncelle", atolye);
        }

        public ActionResult Guncelle(tblAtolyeler p)
        {
            var atolye = db.tblAtolyeler.Find(p.ID);
            var ilce = db.tblIlceler.Where(m => m.ID == p.Ilce.ID).FirstOrDefault();
            var tur = db.tblAtolyeTuru.Where(m => m.ID == p.AtolyeTuru.ID).FirstOrDefault();
            atolye.Ilce = ilce;
            atolye.AtolyeTuru= tur;
            atolye.AtolyeAdi = p.AtolyeAdi;
            atolye.AtolyeAdres = p.AtolyeAdres;
            db.SaveChanges();
            return RedirectToAction("Atolyeler", "Atolye");
        }

        public ActionResult Sil(int id)
        {
            var atolye = db.tblAtolyeler.Find(id);
            db.tblAtolyeler.Remove(atolye);
            db.SaveChanges();
            return RedirectToAction("Atolyeler");
        }

      
       
        [HttpGet]
        public ActionResult AtolyeDetay(int id)
        {
            AtolyeDetayViewModel vm = new AtolyeDetayViewModel();
          

            vm.Atolye = db.tblAtolyeler
                .Where(i => i.ID == id)
                .Select(i => new AtolyeDetayViewModel.AtolyeDataViewModel
                {
                    Adi = i.AtolyeAdi,
                    CalismaSaati = i.AtolyeCalismaSaati,
                    Adres = i.AtolyeAdres,
                    OgretmenAdi = i.Ogretmen.OgretmenAdi,
                    OgretmenSoyadi = i.Ogretmen.OgretmenSoyadi,
                }).FirstOrDefault();

            vm.Fotograflar = db.tblAtolyeFotograf
                .Where(i => i.ID == id)
                .Select(i => new AtolyeDetayViewModel.AtolyeFotograflariViewModel
                {
                    FotografLink = i.FotografLink,
                    Atolye_ID = i.Atolye.ID,                    
                }).FirstOrDefault();
            
           
            vm.Malzemeler = db.tblAtolyeMalzemeler.Where(i => i.ID == id).ToList();
            vm.Kurslar = db.tblAtolyeKurslar.Where(i => i.ID == id).ToList();
            vm.KursOgrencileri = db.tblAtolyeKursOgrencileri.Where(i => i.AtolyeKurs.Atolye.ID== id).ToList();

            //var atolye = _db.tblAtolyeler.Find(id);
            //var malzeme = _db.tblAtolyeMalzemeler.Where(m => m.AtolyeID == id).FirstOrDefault();
           
            return View(vm);
        }

    }
}

