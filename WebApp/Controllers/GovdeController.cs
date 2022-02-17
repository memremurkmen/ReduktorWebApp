
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.Entity;

namespace WebApp.Controllers
{
    public class GovdeController : Controller
    {
        WebDBEntities db = new WebDBEntities();

        // GET: Govde
        public ActionResult Govdeler()
        {
            List<reduktorGovde> rg = db.reduktorGovde.ToList();
            return View(rg);
        }

        [HttpGet]
        public ActionResult GovdeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GovdeEkle(reduktorGovde rg)
        {
            if (!ModelState.IsValid)
            {
                return View("GovdeEkle");
            }
            timestamp ts = new timestamp();
            ts.create_time = DateTime.Now;
            ts.update_time = DateTime.Now;
            db.timestamp.Add(ts);
            db.SaveChanges();
            int tsId = db.Database.SqlQuery<int>("SELECT MAX(timestampID) AS LastID FROM timestamp").FirstOrDefault();
            rg.timestampId = tsId;
            db.reduktorGovde.Add(rg);
            db.SaveChanges();
            return View();
        }

        public ActionResult GovdeSil(int id)
        {
            db.reduktorGovde.Remove(db.reduktorGovde.Find(id));
            db.SaveChanges();
            return RedirectToAction("Govdeler");
        }

        public ActionResult GovdeGetir(int id)
        {
            return View("GovdeGetir", db.reduktorGovde.Find(id));
        }

        public ActionResult GovdeGuncelle(reduktorGovde rg)
        {
            var govde = db.reduktorGovde.Find(rg.id);
            govde.govdeAdi = rg.govdeAdi;

            timestamp ts = new timestamp();
            ts = db.timestamp.FirstOrDefault(x => x.timestampID == govde.timestampId);
            ts.update_time = DateTime.Now;

            db.SaveChanges();
            return RedirectToAction("Govdeler");
        }
    }
}