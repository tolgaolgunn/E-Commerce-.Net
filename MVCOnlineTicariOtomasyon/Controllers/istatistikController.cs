using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Siniflar;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik
        Context c= new Context();
        public ActionResult Index()
        {
            var totalCurrent = c.Caris.Count();
            ViewBag.d1 = totalCurrent;
            var product=c.Uruns.Count();
            ViewBag.d2 = product;
            var staff=c.Personels.Count();
            ViewBag.d3 = staff;
            var category=c.Kategoris.Count();
            ViewBag.d4 = category;
            var totalStock = c.Uruns.Sum(x => x.Stok);
            ViewBag.d5 = totalStock;
            var brand = (from x in c.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = brand;
            var critical=c.Uruns.Count(x=>x.Stok<=20).ToString();
            ViewBag.d7 = critical;
            var expensive = (from x in c.Uruns orderby x.SatisFiyat descending select x.UrunAD).FirstOrDefault();
            ViewBag.d8 = expensive;
            var cheap=(from x in c.Uruns orderby x.SatisFiyat ascending select x.UrunAD).FirstOrDefault();
            ViewBag.d9 = cheap;
            var fridge=c.Uruns.Count(x=> x.UrunAD== "Buzdolabı").ToString();
            ViewBag.d10 = fridge;
            var laptop = c.Uruns.Count(x => x.UrunAD == "Laptop").ToString();
            ViewBag.d11 = laptop;
            var mostFound = c.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = mostFound;
            var bestSelling=c.Uruns.Where(u=>u.UrunID==(c.SatisHarekets.GroupBy(x=>x.Urunid).OrderByDescending(z=>z.Count()).Select(y=>y.Key).FirstOrDefault())).Select(k=>k.UrunAD).FirstOrDefault().ToString();
            ViewBag.d13 = bestSelling;
            var safeBox=c.SatisHarekets.Sum(x=>x.ToplamTutar).ToString();
            ViewBag.d14 = safeBox;


            DateTime today=DateTime.Today;
            var salesToday=c.SatisHarekets.Count(x=>x.Tarih==today).ToString();
            ViewBag.d15 = salesToday;
            var todayCase = c.SatisHarekets.Where(x => x.Tarih == today).Sum(y => y.ToplamTutar).ToString();
            ViewBag.d16 = todayCase;
            return View();
        }
    }
}