using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using alısveristakip.Models.entity;

namespace alısveristakip.Controllers
{
    public class KategoriController : Controller
    {
        AlisverisEntities db = new AlisverisEntities();
        // GET: Kategori
        public ActionResult Index()
        {
            var degerler = db.kategori.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
          
            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(kategori p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.kategori.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var kategori = db.kategori.Find(id);
            db.kategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.kategori.Find(id);
            return View("KategoriGetir",ktgr);
        }

        public ActionResult Guncelle(kategori p1)
        {
            var ktg = db.kategori.Find(p1.KategoriID);
            ktg.KategoriAd = p1.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}