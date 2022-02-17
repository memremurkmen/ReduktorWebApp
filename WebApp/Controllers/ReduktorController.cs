using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.Entity;

namespace WebApp.Controllers
{
    public class ReduktorController : Controller
    {
        // GET: Reduktor
        WebDBEntities db = new WebDBEntities();

        public ActionResult Reduktorler()
        {
            List<reduktor> r = db.reduktor.ToList();

            return View(r);
        }

        [HttpGet]
        public ActionResult ReduktorOlustur()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ReduktorEkle(reduktor r)
        {
            if (!ModelState.IsValid)
            {
                return View("ReduktorEkle");
            }
            timestamp ts = new timestamp();
            ts.create_time = DateTime.Now;
            ts.update_time = DateTime.Now;
            db.timestamp.Add(ts);
            db.SaveChanges();
            int tsId = db.Database.SqlQuery<int>("SELECT MAX(timestampID) AS LastID FROM timestamp").FirstOrDefault();
            r.timestampId = tsId;

            db.reduktor.Add(r);
            db.SaveChanges();
            return Redirect("Reduktorler");
        }

        public ActionResult ReduktorSil(int id)
        {
            db.reduktor.Remove(db.reduktor.Find(id));
            db.SaveChanges();
            return RedirectToAction("Reduktorler");
        }

        public ActionResult ReduktorGetir(int id)
        {
            reduktor r = db.reduktor.Where(x => x.id == id).FirstOrDefault();

            return View(r);
        }

        public ActionResult ReduktorGuncelle(reduktor r)
        {
            reduktor red = db.reduktor.Where(x => x.id == r.id).FirstOrDefault();
            red.serigovdeTipEsId = r.serigovdeTipEsId;
            red.reduktorAdi = r.reduktorAdi;
            red.motorGucu = r.motorGucu;
            red.frekans = r.frekans;
            red.cikisDevri = r.cikisDevri;
            red.cikisMomenti = r.cikisMomenti;
            red.servisFaktoru = r.servisFaktoru;

            timestamp ts = new timestamp();
            ts = db.timestamp.FirstOrDefault(x => x.timestampID == red.timestampId);
            ts.update_time = DateTime.Now;

            db.SaveChanges();

            /*var seriGovdeEs = db.reduktorSeriReduktorGovde.Find(rsrg.id);
            seriGovdeEs.seriGovdeAdi = rsrg.seriGovdeAdi;

            var seri = db.reduktorSeri.Where(s => s.id == rsrg.reduktorSeri.id).FirstOrDefault();
            var govde = db.reduktorGovde.Where(g => g.id == rsrg.reduktorGovde.id).FirstOrDefault();
            seriGovdeEs.reduktorSeri = seri;
            seriGovdeEs.reduktorGovde = govde;
            db.SaveChanges();*/
            return Redirect("Reduktorler");
        }
    }
}