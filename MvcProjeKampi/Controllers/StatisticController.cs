using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticController : Controller
    {
        Context context = new Context();
        // GET: Statistic
        public ActionResult Index()
        {
            //Toplam kategori
            ViewBag.ToplamKategori = context.Categories.Count();
             

            ViewBag.YazilimBasliklari = context.Headings.Count(x => x.Category.CategoryName == "Yazılım");


            ViewBag.IcindeAHarfiOlanYazarlar = context.Writers
                .Where(x => x.WriterName.ToLower().Contains("a"))
                .Count();


            ViewBag.EnFazlaBaslikKategori = context.Headings.GroupBy(x => x.Category.CategoryName).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault();



            var kategoriTrue = context.Categories.Count(x => x.CategoryStatus == true);
            var kategoriFalse = context.Categories.Count(x => x.CategoryStatus == false);

            ViewBag.Status= kategoriTrue - kategoriFalse;
        

            return View();

        }
    }
}