using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using alısveristakip.Models.entity;

namespace alısveristakip.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        AlisverisEntities db = new AlisverisEntities();
        public ActionResult Index()
        {
            var degerler = db.urun.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(urun p1)
        {
            var ktg = db.kategori.Where(m => m.KategoriID == p1.kategori.KategoriID).FirstOrDefault();
            p1.kategori = ktg;
            db.urun.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL(int id)
        {
            var urun = db.urun.Find(id);
            db.urun.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.urun.Find(id);

            List<SelectListItem> degerler = (from i in db.kategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;


            return View("UrunGetir", urun);

        }

        public ActionResult Guncelle(urun p)
        {
            var urun = db.urun.Find(p.Urun_ID);
            urun.UrunAd = p.UrunAd;
            urun.Marka = urun.Marka;
            urun.Stok = p.Stok;
            urun.Fiyat = p.Fiyat;
            //urun.UrunKategori = p.UrunKategori;
            var ktg = db.kategori.Where(m => m.KategoriID == p.kategori.KategoriID).FirstOrDefault();
            urun.UrunKategori = ktg.KategoriID;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}