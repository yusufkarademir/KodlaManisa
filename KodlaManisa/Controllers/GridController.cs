using KodlaManisa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KodlaManisa.Controllers
{
    public class GridController : Controller
    {
        KodlaManisaEntities db = new KodlaManisaEntities();
        // GET: Grid
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Listele()
        {
            var model = db.tblOkullar.ToList();
            return View(model);
        }
    }
}