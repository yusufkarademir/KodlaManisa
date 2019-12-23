using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KodlaManisa.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Duyurular()
        {
            return View();
        }
        public ActionResult Raporlar()
        {
            return View();
        }
        public ActionResult Anketler()
        {
            return View();
        }
        public ActionResult EtkinlikTakvimi()
        {
            return View();
        }
        public ActionResult Galeri()
        {
            return View();
        }
        public ActionResult Grafikler()
        {
            return View();
        }
        public ActionResult Formlar()
        {
            return View();
        }
        public ActionResult Tablolar()
        {
            return View();
        }
    }
}