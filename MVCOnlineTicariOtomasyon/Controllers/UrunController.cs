﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Siniflar;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c=new Context();
        public ActionResult Index()
        {
            var urunler = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1=deger1;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun p)
        {
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger=c.Uruns.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var deger= c.Uruns.Find(id);
            return View("UrunGetir",deger);
        }
        public ActionResult UrunGuncelle(Urun p)
        {
            var urun=c.Uruns.Find(p.UrunID);
            urun.Durum=p.Durum;
            urun.AlisFiyat = p.AlisFiyat;
            urun.SatisFiyat=p.SatisFiyat;
            urun.Stok=p.Stok;
            urun.UrunAD=p.UrunAD;
            urun.Marka = p.Marka;
            urun.Kategoriid = p.Kategoriid;
            urun.UrunGorsel = p.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunListesi()
        {
            var deger=c.Uruns.ToList();
            return View(deger);
        }
    }
}