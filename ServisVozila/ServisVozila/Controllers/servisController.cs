using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ServisVozila.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;

namespace ServisVozila.Controllers
{
    public class servisController : Controller
    {
        private ServisDbContext db = new ServisDbContext();

        // GET: servis
        public ActionResult Index()
        {
            ViewBag.tKorisnik = User.Identity.GetUserId();
            return View(db.Servisi.ToList());
        }

        [Authorize(Roles = "admin")]
        public ActionResult Admin()
        {
            return View(db.Servisi.ToList());
        }
        // GET: servis/Details/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servis servis = db.Servisi.Find(id);
            if (servis == null)
            {
                return HttpNotFound();
            }
            return View(servis);
        }
        // GET: servis/Create
        public ActionResult Create()
        {
            ServisDbContext db = new ServisDbContext();
            ApplicationDbContext db2 = new ApplicationDbContext();
            var korisnici = db2.Users.Select(s => new { Text = s.Email, Value = s.Id }).ToList();
            ViewBag.korisnici = new SelectList(korisnici, "Value", "Text");
            var auti = db.Vozila.Select(s => new { Text = s.marka + " " + s.model + " " + s.boja, Value = s.idVozilo }).ToList();
            ViewBag.auti = new SelectList(auti, "Value", "Text");
            var tKorisnik = User.Identity.GetUserId();
            var autiKor = db.Vozila.Where(s=>s.idKorisnik==tKorisnik).Select(s => new { Text = s.marka + " " + s.model + " " + s.boja, Value = s.idVozilo }).ToList();
            ViewBag.autiKor = new SelectList(autiKor, "Value", "Text");
            return View();
        }

        // POST: servis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idServis,idKorisnik,idVozilo,datum,opisPosla,cijena,napomena,obavljen,naziv")] servis servis)
        {
            if (ModelState.IsValid)
            {
                db.Servisi.Add(servis);
                db.SaveChanges();
                if (User.IsInRole("admin"))
                {
                    return RedirectToAction("Admin");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            return View(servis);
        }

        // GET: servis/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            ServisDbContext db = new ServisDbContext();
            ApplicationDbContext db2 = new ApplicationDbContext();
            //ViewBag.auti = db.Servisi.Distinct().ToList();
            var korisnici = db2.Users.Select(s => new { Text = s.Email, Value = s.Id }).ToList();
            ViewBag.korisnici = new SelectList(korisnici, "Value", "Text");
            var auti = db.Vozila.Select(s => new { Text = s.marka + " " + s.model + " " + s.boja, Value = s.idVozilo }).ToList();
            ViewBag.auti = new SelectList(auti, "Value", "Text");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servis servis = db.Servisi.Find(id);
            if (servis == null)
            {
                return HttpNotFound();
            }
            return View(servis);
        }

        // POST: servis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "idServis,idKorisnik,idVozilo,datum,opisPosla,cijena,napomena,obavljen")] servis servis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Admin");
            }
            return View(servis);
        }

        // GET: servis/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servis servis = db.Servisi.Find(id);
            if (servis == null)
            {
                return HttpNotFound();
            }
            return View(servis);
        }

        // POST: servis/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            servis servis = db.Servisi.Find(id);
            db.Servisi.Remove(servis);
            db.SaveChanges();
            return RedirectToAction("Admin");
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
