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

        public object FotografLink { get; private set; }
        public object KursYili { get; private set; }

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
                .Where(i => i.Atolye.ID == id)
                .Select(i => new AtolyeDetayViewModel.AtolyeFotograflariViewModel
                {
                    FotografLink = i.FotografLink,
                    Atolye_ID = i.Atolye.ID,                    
                }).FirstOrDefault();
                       
            vm.Malzemeler = db.tblAtolyeMalzemeler.Where(i => i.Atolye.ID == id).ToList();
            vm.Kurslar = db.tblAtolyeKurslar.Where(i => i.Atolye.ID == id).ToList();
            vm.KursOgrencileri = db.tblAtolyeKursOgrencileri.Where(i => i.AtolyeKurs.Atolye.ID== id).ToList();
            vm.YonlendirilenOgrenciler = db.TblAtolyeYonlendirilenOgrenciler.Where(i => i.Atolye.ID == id).ToList();
            //vm.OgrenciOkul = db.tblOkulOgrenciler.Where(i=>i.Ogrenci.ID==tblAtolyeKursOgrencileri.)

            return View(vm);
        }

        public ActionResult AtolyeKurslar(int id)
        {
            //Hangi Atölyenin AtolyeDetay Sayfasından tıklandıysa sadece o atolyeye ait Kurslar gelmeli..
            AtolyeDetayViewModel vm = new AtolyeDetayViewModel();


            vm.Atolye = db.tblAtolyeler
                .Where(i => i.ID == id)
                .Select(i => new AtolyeDetayViewModel.AtolyeDataViewModel
                {
                    ID = i.ID,
                    Adi = i.AtolyeAdi,
                    CalismaSaati = i.AtolyeCalismaSaati,
                    Adres = i.AtolyeAdres,
                    OgretmenAdi = i.Ogretmen.OgretmenAdi,
                    OgretmenSoyadi = i.Ogretmen.OgretmenSoyadi,
                }).FirstOrDefault();
            vm.Kurslar = db.tblAtolyeKurslar.Where(i => i.Atolye.ID == id).ToList();
            ViewBag.AtolyeID = vm.Atolye.ID;

            return View(vm);

        }


        [HttpGet]
        public ActionResult KursEkle()
        {

            IEnumerable<SelectListItem> atolye = (from i in db.tblAtolyeler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.AtolyeAdi,
                                                 Value = i.ID.ToString()
                                             }).ToList();
            ViewBag.atolye = atolye;

            List<SelectListItem> ogretmen = (from i in db.tblOgretmenler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.OgretmenAdi + " " + i.OgretmenSoyadi,
                                                 Value = i.ID.ToString()
                                             }).ToList();
            ViewBag.ogretmen = ogretmen;

            return View();
        }


        [HttpPost]
        public ActionResult KursEkle(tblAtolyeKurslar p)
        {
            //Yorum satırlarını kaldırınca hata üretiyor
            //var ogretmen = db.tblOgretmenler.Where(m => m.ID == p.Ogretmen.ID).FirstOrDefault();
            //var atolye = db.tblAtolyeler.Where(m => m.ID == p.Atolye.ID).FirstOrDefault();
            //p.Ogretmen = ogretmen;
            //p.Atolye = atolye;
            //db.tblAtolyeKurslar.Add(p);
            //db.SaveChanges();
            return RedirectToAction("KursEkle");
        }

        public ActionResult KursOgrencileri(int id)
       
        {
            List<tblAtolyeKursOgrencileri> Ogrenciler = db.tblAtolyeKursOgrencileri.Where(i => i.AtolyeKurs.ID == id).ToList();
            

            return View(Ogrenciler);
        }

        public ActionResult KursDuzenle(int id)
        {
            var Kurs = db.tblAtolyeKurslar.Find(id);

            List<SelectListItem> ogrenciler = (from i in db.tblAtolyeKursOgrencileri.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.Ogrenci.OgrenciAdi + i.Ogrenci.OgrenciSoyadi,                                               
                                                Value = i.ID.ToString()
                                            }).ToList();
            ViewBag.ogrenciler = ogrenciler;

            List<SelectListItem> ogretmen = (from i in db.tblOgretmenler.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.OgretmenAdi +" "+i.OgretmenSoyadi,
                                                   Value = i.ID.ToString()
                                               }).ToList();
            ViewBag.ogretmen = ogretmen;


            return View("KursDuzenle", Kurs);
        }

        public ActionResult KursGuncelle(tblAtolyeKurslar p)
        {
            var Kurs = db.tblAtolyeKurslar.Find(p.ID);
            var ogrenciler = db.tblAtolyeKursOgrencileri.Where(m =>m.AtolyeKurs.ID == Kurs.ID).FirstOrDefault();
            var ogretmen = db.tblAtolyeKurslar.Where(m => m.Ogretmen.ID == p.Ogretmen.ID).FirstOrDefault();

            Kurs.KursTuru = p.KursTuru;            
            Kurs.KursGrubu = p.KursGrubu;
            Kurs.KursSeviyesi = p.KursSeviyesi;
            Kurs.KursDönemi = p.KursDönemi;
            Kurs.KursYili = p.KursYili;
            Kurs.Ogretmen = p.Ogretmen;
            Kurs.GrupGunu = p.GrupGunu;
            Kurs.GrupSaati = p.GrupSaati;
            
            db.SaveChanges();
            return RedirectToAction("AtolyeDetay", "Atolye");
        }

        [HttpGet]
        public ActionResult MalzemeEkle(int id)
        {
            
            List<tblAtolyeMalzemeler> malzemeler = db.tblAtolyeMalzemeler.Where(i => i.Atolye.ID == id).ToList();
            IEnumerable<SelectListItem> atolye = (from i in db.tblAtolyeler.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = i.AtolyeAdi,
                                                      Value = i.ID.ToString()
                                                  }).ToList();
            ViewBag.atolye = atolye;

            return View();
        }
        [HttpPost]
        public ActionResult MalzemeEkle(tblAtolyeMalzemeler p)
        {

            //Yorum satırlarını kaldırınca hata üretiyor
            //var malzeme = db.tblAtolyeMalzemeler.Where(i => i.Atolye.ID == p.Atolye.ID).FirstOrDefault();
            //var atolye = db.tblAtolyeler.Where(m => m.ID == p.Atolye.ID).FirstOrDefault();
            //p.MalzemeAdi = malzeme.MalzemeAdi;
            //p.MalzemeAdedi = malzeme.MalzemeAdedi;
            //p.MalzemeDurumu = malzeme.MalzemeDurumu;
            //p.MalzemeTeminSekli = malzeme.MalzemeTeminSekli;
            //p.TeminTarihi = malzeme.TeminTarihi;
            //p.Atolye = atolye;
            //db.tblAtolyeMalzemeler.Add(p);
            //db.SaveChanges();


            return RedirectToAction("MalzemeEkle");

           
        }


    }
}

