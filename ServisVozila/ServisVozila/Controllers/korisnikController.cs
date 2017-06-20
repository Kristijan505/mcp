using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ServisVozila.Models;
using Microsoft.AspNet.Identity;

namespace ServisVozila.Controllers
{
    public class korisnikController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: korisnik
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
        [Authorize(Roles = "admin")]
        public ActionResult Admin()
        {
            return View(db.Users.ToList());
        }
        [Authorize(Roles = "admin")]
        // GET: korisnik/Details/5
        public ActionResult Details(string id)
        {
            ApplicationUser korisnik = db.Users.Find(id);
            return View(korisnik);
        }
        [Authorize(Roles = "admin")]
        // GET: korisnik/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "admin")]
        // POST: korisnik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost] // oznaka da će se nešto zapisati u bazu
        [ValidateAntiForgeryToken] // provjerava se identitet korisnika
        public ActionResult Create([Bind(Include = "Email,PasswordHash")] ApplicationUser korisnik)
        {
            // u stranicu Create se referenciraju svi stupci.(idKorisnik....itd)
            if (ModelState.IsValid)
            {
                korisnik.Id = Guid.NewGuid().ToString();
                korisnik.UserName = korisnik.Email;
                korisnik.EmailConfirmed = false;
                PasswordHasher hash = new PasswordHasher();
                korisnik.PasswordHash = hash.HashPassword(korisnik.PasswordHash);
                korisnik.SecurityStamp = Guid.NewGuid().ToString();
                korisnik.PhoneNumber = null;
                korisnik.PhoneNumberConfirmed = false;
                korisnik.TwoFactorEnabled = false;
                korisnik.LockoutEndDateUtc = null;
                korisnik.LockoutEnabled = true;
                korisnik.AccessFailedCount = 0;
                db.Users.Add(korisnik); 
                db.SaveChanges();
                return RedirectToAction("Admin");
            }

            return View(korisnik);
        }
        [Authorize(Roles = "admin")]
        // GET: korisnik/Edit/5
        public ActionResult Edit(string id) // za editanje korisnika
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser korisnik = db.Users.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }
        [Authorize(Roles = "admin")]
        // POST: korisnik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Ovo sranje ne radi
        //
        //
        //
        //
        //
        //
        //
        //
        //
        //
        public ActionResult Edit([Bind(Include = "Id,UserName,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount")] ApplicationUser korisnik)
        {
            if (ModelState.IsValid) // da li su sva polja ispunjena(lozinka,id)
            {
                db.Entry(korisnik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Admin");
            }
            return View(korisnik);
        }
        [Authorize(Roles = "admin")]
        // GET: korisnik/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser korisnik = db.Users.Find(id);
            if (korisnik == null)
            {
                return HttpNotFound();
            }
            return View(korisnik);
        }
        [Authorize(Roles = "admin")]
        // POST: korisnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id) // potvđeni delete,da li smo sigurni da želimo nešto obrisati
        {
            ApplicationUser korisnik = db.Users.Find(id);
            db.Users.Remove(korisnik);
            db.SaveChanges();
            return RedirectToAction("Admin");
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
