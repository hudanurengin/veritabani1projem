using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using alısveristakip.Models.entity;

namespace alısveristakip.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        AlisverisEntities db = new AlisverisEntities();
        public ActionResult Index()
        {
            var degerler = db.kullanici.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
            
        }

        [HttpPost]
        public ActionResult YeniMusteri(kullanici p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.kullanici.Add(p1);
            db.SaveChanges();
            return View();
            
        }
        public ActionResult SIL(int id)
        {
            var musteri = db.kullanici.Find(id);
            db.kullanici.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGetir(int id)
        {
            var mus = db.kullanici.Find(id);
            return View("MusteriGetir",mus);
        }
        public ActionResult Guncelle(kullanici p1)
        {
            var musteri = db.kullanici.Find(p1.KullanıcıID);
            musteri.Ad = p1.Ad;
            musteri.Soyad = p1.Soyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}