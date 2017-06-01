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
    public class korisnikController : Controller
    {
        private KorisnikDbContext db = new KorisnikDbContext();

        // GET: korisnik
        public ActionResult Index()
        {
            return View(db.Korisnici.ToList());
        }
        public ActionResult Admin()
        {
            return View(db.Korisnici.ToList());
        }
        // GET: korisnik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            korisnik korisnik = db.Korisnici.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // GET: korisnik/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: korisnik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost] // oznaka da će se nešto zapisati u bazu
        [ValidateAntiForgeryToken] // provjerava se identitet korisnika
        public ActionResult Create([Bind(Include = "idKorisnik,ime,prezime,telefon,adresa,mail,OIB,biljeska,lozinka,grad,posta,admin")] korisnik korisnik)
        {
            // u stranicu Create se referenciraju svi stupci.(idKorisnik....itd)
            if (ModelState.IsValid)
            {
                db.Korisnici.Add(korisnik); 
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(korisnik);
        }

        // GET: korisnik/Edit/5
        public ActionResult Edit(int? id) // za editanje korisnika
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            korisnik korisnik = db.Korisnici.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // POST: korisnik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idKorisnik,ime,prezime,telefon,adresa,mail,OIB,biljeska,lozinka,grad,posta,admin")] korisnik korisnik)
        {
            if (ModelState.IsValid) // da li su sva polja ispunjena(lozinka,id)
            {
                db.Entry(korisnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(korisnik);
        }

        // GET: korisnik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            korisnik korisnik = db.Korisnici.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }

        // POST: korisnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) // potvđeni delete,da li smo sigurni da želimo nešto obrisati
        {
            korisnik korisnik = db.Korisnici.Find(id);
            db.Korisnici.Remove(korisnik);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) // Dispose-služi za brisanje iz baze
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
