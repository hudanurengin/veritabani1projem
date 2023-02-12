using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using alısveristakip.Models.entity;

namespace alısveristakip.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        AlisverisEntities db = new AlisverisEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            return View();

        }
        [HttpPost]
        public ActionResult YeniSatis(satis p)
        {
            db.satis.Add(p);
            db.SaveChanges();
            return View("Index");
        }
    }
}