using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.Entity;

namespace WebApp.Controllers
{
    public class SeriGovdeTipEslesmeController : Controller
    {
        // GET: SeriGovdeTipEslesme
        WebDBEntities db = new WebDBEntities();

        public ActionResult SeriGovdeTipler()
        {
            List<seriGovdeTipEslesme> rsrg = db.seriGovdeTipEslesme.ToList();

            return View(rsrg);
        }

        [HttpGet]
        public ActionResult SeriGovdeTipOlustur()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SeriGovdeTipEkle(seriGovdeTipEslesme sgt)
        {
            if (!ModelState.IsValid)
            {
                return View("SeriGovdeTipEkle");
            }
            timestamp ts = new timestamp();
            ts.create_time = DateTime.Now;
            ts.update_time = DateTime.Now;
            db.timestamp.Add(ts);
            db.SaveChanges();
            int tsId = db.Database.SqlQuery<int>("SELECT MAX(timestampID) AS LastID FROM timestamp").FirstOrDefault();
            sgt.timestampId = tsId;

            db.seriGovdeTipEslesme.Add(sgt);
            db.SaveChanges();
            return Redirect("SeriGovdeTipler");
        }

        public ActionResult SeriGovdeTipSil(int id)
        {
            db.seriGovdeTipEslesme.Remove(db.seriGovdeTipEslesme.Find(id));
            db.SaveChanges();
            return RedirectToAction("SeriGovdeTipler");
        }

        public ActionResult SeriGovdeTipGetir(int id)
        {
            seriGovdeTipEslesme sgt = db.seriGovdeTipEslesme.Where(x => x.id == id).FirstOrDefault();

            return View(sgt);
        }

        public ActionResult SeriGovdeTipGuncelle(seriGovdeTipEslesme sgte)
        {
            seriGovdeTipEslesme sgt = db.seriGovdeTipEslesme.Where(x => x.id == sgte.id).FirstOrDefault();
            sgt.seriId = sgte.seriId;
            sgt.govdeId = sgte.govdeId;
            sgt.tipId = sgte.tipId;
            sgt.reduktorTipAdi = sgte.reduktorTipAdi;

            timestamp ts = new timestamp();
            ts = db.timestamp.FirstOrDefault(x => x.timestampID == sgt.timestampId);
            ts.update_time = DateTime.Now;

            db.SaveChanges();

            /*var seriGovdeEs = db.reduktorSeriReduktorGovde.Find(rsrg.id);
            seriGovdeEs.seriGovdeAdi = rsrg.seriGovdeAdi;

            var seri = db.reduktorSeri.Where(s => s.id == rsrg.reduktorSeri.id).FirstOrDefault();
            var govde = db.reduktorGovde.Where(g => g.id == rsrg.reduktorGovde.id).FirstOrDefault();
            seriGovdeEs.reduktorSeri = seri;
            seriGovdeEs.reduktorGovde = govde;
            db.SaveChanges();*/
            return Redirect("SeriGovdeTipler");
        }
    }
}