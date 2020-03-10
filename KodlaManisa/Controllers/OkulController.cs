using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KodlaManisa.Models;
using KodlaManisa.ViewModels;
using KodlaManisa.Models.Database;


namespace KodlaManisa.Controllers
{
    public class OkulController : Controller
    {
        // GET: Okul
        KodlaManisaEntities db = new KodlaManisaEntities();

        public ActionResult Index()
        {
            var okullar = db.tblOkullar.ToList();
            return View(okullar);
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
                                                Value = i.ID.ToString()
                                            }).ToList();
            ViewBag.ilce = ilceler;

            List<SelectListItem> okulTuru = (from i in db.tblOkulTuru.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.OkulTuru,
                                                 Value = i.ID.ToString()
                                             }).ToList();
            ViewBag.okulTuru = okulTuru;

            return View();
        }

        [HttpPost]
        public ActionResult OkulEkle(tblOkullar p)
        {
            var ilce = db.tblIlceler.Where(m => m.ID == p.tblIlceler.ID).FirstOrDefault();
            var tur = db.tblOkulTuru.Where(m => m.ID == p.tblOkulTuru.ID).FirstOrDefault();
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
                                                Value = i.ID.ToString()
                                            }).ToList();
            ViewBag.ilce = ilceler;

            List<SelectListItem> okulTuru = (from i in db.tblOkulTuru.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.OkulTuru,
                                                 Value = i.ID.ToString()
                                             }).ToList();
            ViewBag.okulTuru = okulTuru;
            return View("OkulGuncelle", okul);
        }

        public ActionResult Guncelle(tblOkullar p)
        {
            var okul = db.tblOkullar.Find(p.ID);
            var ilce = db.tblIlceler.Where(m => m.ID == p.tblIlceler.ID).FirstOrDefault();
            var tur = db.tblOkulTuru.Where(m => m.ID == p.tblOkulTuru.ID).FirstOrDefault();            
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

        public ActionResult OkulDetay(int id)
        {
            //KodlaManisaEntities _db = new KodlaManisaEntities();
            OkulDetayViewModel vm = new OkulDetayViewModel();

            vm.Okul = db.tblOkullar
                .Where(i => i.ID == id)
                .Select(i => new OkulDataViewModel
                {
                    OkulAdi = i.OkulAdi,
                    OkulIlceAdi = i.tblIlceler.IlceAdi,
                    OkulTuru = i.tblOkulTuru.OkulTuru,
                    OkulMuduru = i.OkulMuduru,
                    BTSayisi = i.BTOgretmenSayisi.ToString(),
                    OkulAdresi = i.OkulAdres,
                    Eposta = i.OkulEposta,
                    OkulTel = i.OkulTel,
                    OkulFax = i.OkulFax,

                }).FirstOrDefault();

            vm.TTakimi = db.tblOkulTeknolojiTakimi
               .Where(i => i.ID == id)
               .Select(i => new TTakimiViewModel
               {
                   TakimAdi = i.TakimAdi.ToString(),
                   Okul_ID = i.ID,
                   OgretmenAdi = i.Ogretmen.OgretmenAdi + " " + i.Ogretmen.OgretmenSoyadi,
                   OgrenciSayisi = i.OgrenciSayisi,
                   KatildigiYarismaAdi = i.KatildigiYarismaAdi,
               }).FirstOrDefault();

            vm.OkulEkibi = db.tblOkulProjeEkibi
            .Where(i => i.ID == id)
            .Select(i => new OkulProjeEkibiViewModel
            {
                Yonetici = i.Yonetici,
                Ogretmen1 = i.Ogretmen1,
                Ogretmen2 = i.Ogretmen2,
            }).FirstOrDefault();


            vm.Malzemeler = db.tblOkulMalzemeler.Where(i => i.ID == id).ToList();
            



            //    .Join(_db.tblOgretmenler, a => a.OgretmenID, o => o.OgretmenID, (a, o) => new { a, o })
            //    .Where(i => i.a.AtolyeID == id)
            //    .Select(i => new AtolyeDetayViewModel.AtolyeDataViewModel
            //    {
            //        Adi = i.a.AtolyeAdi,
            //        CalismaSaati = i.a.AtolyeCalismaSaati,
            //        Adres = i.a.AtolyeAdres,
            //        OgretmenAdi = i.o.OgretmenAdi,
            //        OgretmenSoyadi = i.o.OgretmenSoyadi
            //    }).FirstOrDefault();

            //vm.Malzemeler = _db.tblAtolyeMalzemeler.Where(i => i.AtolyeID == id).ToList();
            //vm.Kurslar = _db.tblAtolyeKurslar.Where(i => i.AtolyeID == id).ToList();
            //vm.KursOgrencileri = _db.tblAtolyeKursOgrencileri.Where(i => i.tblAtolyeKurslar.AtolyeID == id).ToList();

            //var atolye = _db.tblAtolyeler.Find(id);
            //var malzeme = _db.tblAtolyeMalzemeler.Where(m => m.AtolyeID == id).FirstOrDefault();

            return View(vm);
        }

    }
}