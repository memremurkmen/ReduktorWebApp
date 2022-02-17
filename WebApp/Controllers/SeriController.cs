using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.Entity;

namespace WebApp.Controllers
{
    public class SeriController : Controller
    {
        WebDBEntities db = new WebDBEntities();

        public ActionResult Seriler()
        {
            List<reduktorSeri> rs = db.reduktorSeri.ToList();
            return View(rs);
        }

        [HttpGet]
        public ActionResult SeriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SeriEkle(reduktorSeri rs)
        {
            if (!ModelState.IsValid)
            {
                return View("SeriEkle");
            }
            timestamp ts = new timestamp();
            ts.create_time = DateTime.Now;
            ts.update_time = DateTime.Now;
            db.timestamp.Add(ts);
            db.SaveChanges();
            int tsId = db.Database.SqlQuery<int>("SELECT MAX(timestampID) AS LastID FROM timestamp").FirstOrDefault();
            rs.timestampId = tsId;
            db.reduktorSeri.Add(rs);
            db.SaveChanges();
            return View();
        }

        public ActionResult SeriSil(int id)
        {
            db.reduktorSeri.Remove(db.reduktorSeri.Find(id));
            db.SaveChanges();
            return RedirectToAction("Seriler");
        }

        public ActionResult SeriGetir(int id)
        {
            return View("SeriGetir", db.reduktorSeri.Find(id));
        }

        public ActionResult SeriGuncelle(reduktorSeri rs)
        {
            var seri = db.reduktorSeri.Find(rs.id);
            seri.seriAdi = rs.seriAdi;

            timestamp ts = new timestamp();
            ts = db.timestamp.FirstOrDefault(x => x.timestampID == seri.timestampId);
            ts.update_time = DateTime.Now;

            db.SaveChanges();
            return RedirectToAction("Seriler");
        }
    }
}