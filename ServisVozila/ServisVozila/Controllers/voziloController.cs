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
    [Authorize]
    public class voziloController : Controller
    {
        private VoziloDbContext db = new VoziloDbContext();

        // GET: vozilo
        public ActionResult Index()
        {
            ViewBag.tKorisnik = User.Identity.GetUserId();
            return View(db.Vozila.ToList());
        }
        [Authorize(Roles = "admin")]
        public ActionResult Admin()
        {
            var result = (from c in db.Vozila
                          select new voziloDTO
                          {
                             marka = c.marka,
                             model = c.model,
                             zapremina = c.zapremina,
                             godinaProiz = c.godinaProiz,
                             boja = c.boja,
                             regBroj = c.regBroj
                          }).ToList();


            return View(result); //return View(db.Vozila.ToList());
        }
        // GET: vozilo/Details/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vozilo vozilo = db.Vozila.Find(id);
            if (vozilo == null)
            {
                return HttpNotFound();
            }
            return View(vozilo);
        }

        // GET: vozilo/Create
        public ActionResult Create()
        {
            ViewBag.tKorisnik = User.Identity.GetUserId();
            ApplicationDbContext db2 = new ApplicationDbContext();
            var korisnici = db2.Users.Select(s => new { Text = s.Email, Value = s.Id }).ToList();
            ViewBag.korisnici = new SelectList(korisnici, "Value", "Text");
            return View();
        }

        // POST: vozilo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVozilo,idKorisnik,marka,model,godinaProiz,boja,zapremina,nosivost,godinaReg,regBroj")] vozilo vozilo)
        {
            if (ModelState.IsValid)
            {
                db.Vozila.Add(vozilo);
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

            return View(vozilo);
        }

        // GET: vozilo/Edit/5
        public ActionResult Edit(int? id)
        {
            ApplicationDbContext db2 = new ApplicationDbContext();
            var korisnici = db2.Users.Select(s => new { Text = s.Email, Value = s.Id }).ToList();
            ViewBag.korisnici = new SelectList(korisnici, "Value", "Text");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vozilo vozilo = db.Vozila.Find(id);
            if (vozilo == null)
            {
                return HttpNotFound();
            }
            return View(vozilo);
        }

        // POST: vozilo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVozilo,idKorisnik,marka,model,godinaProiz,boja,zapremina,nosivost,godinaReg,regBroj")] vozilo vozilo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vozilo).State = EntityState.Modified;
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
            return View(vozilo);
        }

        // GET: vozilo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vozilo vozilo = db.Vozila.Find(id);
            if (vozilo == null)
            {
                return HttpNotFound();
            }
            return View(vozilo);
        }

        // POST: vozilo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vozilo vozilo = db.Vozila.Find(id);
            db.Vozila.Remove(vozilo);
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
