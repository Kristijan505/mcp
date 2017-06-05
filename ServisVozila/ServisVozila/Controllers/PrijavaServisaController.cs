using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ServisVozila.Models;

namespace ServisVozila.Controllers
{
    public class PrijavaServisaController : Controller
    {
        private PrijavaServisaDbContext db = new PrijavaServisaDbContext();

        // GET: vozilo
        public ActionResult Index()
        {
            return View(db.PrServisa.ToList());
        }
        public ActionResult Admin()
        {
            return View(db.PrServisa.ToList());
        }
        // GET: vozilo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrijavaServisa PrijavaServisa = db.PrServisa.Find(id);
            if (PrijavaServisa == null)
            {
                return HttpNotFound();
            }
            return View(PrijavaServisa);
        }

        // GET: vozilo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vozilo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idkorisnika,ime_i_prezime,email,tel_broj,vrijeme_popravka,opis_servisa,markavozila,modelvozila")] PrijavaServisa PrijavaServisa)
        {
            // ovo je za validaciju na razini kontrolera
            // znaci ako je upisani datum manji od danasnjeg ne moze se stvriti zahtjev za servisom
            if(PrijavaServisa.datum_popravka <= DateTime.Now)
            {
                ModelState.AddModelError("datum_popravka","Datum popravka ne smije biti manji od danasnjeg datuma!");
            }


            if (ModelState.IsValid)
            {
                db.PrServisa.Add(PrijavaServisa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // tu mozda ne valja jer je bila klasa u zagradama a sad nije
            return View(PrijavaServisa);
        }

        // GET: vozilo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrijavaServisa PrijavaServisa = db.PrServisa.Find(id);
            if (PrijavaServisa == null)
            {
                return HttpNotFound();
            }
            return View(PrijavaServisa);
        }

        // POST: vozilo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idkorisnika,ime_i_prezime,email,tel_broj,vrijeme_popravka,opis_servisa,markavozila,modelvozila")] PrijavaServisa PrijavaServisa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(PrijavaServisa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(PrijavaServisa);
        }

        // GET: vozilo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrijavaServisa PrijavaServisa = db.PrServisa.Find(id);
            if (PrijavaServisa == null)
            {
                return HttpNotFound();
            }
            return View(PrijavaServisa);
        }

        // POST: vozilo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrijavaServisa PrijavaServisa = db.PrServisa.Find(id);
            db.PrServisa.Remove(PrijavaServisa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
