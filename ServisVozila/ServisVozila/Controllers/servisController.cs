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
    public class servisController : Controller
    {
        private ServisDbContext db = new ServisDbContext();

        // GET: servis
        public ActionResult Index()
        {
            return View(db.Servisi.ToList());
        }
        public ActionResult Admin()
        {
            return View(db.Servisi.ToList());
        }
        // GET: servis/Details/5
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
                return RedirectToAction("Index");
            }

            return View(servis);
        }

        // GET: servis/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: servis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idServis,idKorisnik,idVozilo,datum,opisPosla,cijena,napomena,obavljen")] servis servis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servis);
        }

        // GET: servis/Delete/5
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            servis servis = db.Servisi.Find(id);
            db.Servisi.Remove(servis);
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
