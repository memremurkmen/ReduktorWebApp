using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.Entity;

namespace WebApp.Controllers
{
    public class TipController : Controller
    {
        WebDBEntities db = new WebDBEntities();

        public ActionResult Tipler()
        {
            List<reduktorTip> rt = db.reduktorTip.ToList();
            return View(rt);
        }

        [HttpGet]
        public ActionResult TipEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TipEkle(reduktorTip rt)
        {
            if (!ModelState.IsValid)
            {
                return View("TipEkle");
            }
            timestamp ts = new timestamp();
            ts.create_time = DateTime.Now;
            ts.update_time = DateTime.Now;
            db.timestamp.Add(ts);
            db.SaveChanges();
            int tsId = db.Database.SqlQuery<int>("SELECT MAX(timestampID) AS LastID FROM timestamp").FirstOrDefault();
            rt.timestampId = tsId;

            db.reduktorTip.Add(rt);
            db.SaveChanges();
            return View();
        }

        public ActionResult TipSil(int id)
        {
            db.reduktorTip.Remove(db.reduktorTip.Find(id));
            db.SaveChanges();
            return RedirectToAction("Tipler");
        }

        public ActionResult TipGetir(int id)
        {
            return View("TipGetir", db.reduktorTip.Find(id));
        }

        public ActionResult TipGuncelle(reduktorTip rt)
        {
            var tip = db.reduktorTip.Find(rt.id);
            tip.tipAdi = rt.tipAdi;

            timestamp ts = new timestamp();
            ts = db.timestamp.FirstOrDefault(x => x.timestampID == tip.timestampId);
            ts.update_time = DateTime.Now;

            db.SaveChanges();
            return RedirectToAction("Tipler");
        }
    }
}