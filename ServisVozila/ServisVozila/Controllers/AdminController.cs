using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ServisVozila.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServisVozila.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ContentResult DodajRolu (string id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                IdentityResult result;
                var manager = new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));
                result = manager.Create(new IdentityRole(id));
                if (result.Succeeded)
                    return Content("Rola " + id + " uspješno dodana");
                else
                    return Content("Greška prilikom dodavanja role " + id);
            }
        }

        public ActionResult DodajRoluKorisniku(string korisnici, string dali)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                if (dali == "DA" && korisnici != "Odaberite korisnika")
                {
                    string rola = "admin";
                    IdentityResult result;
                    var store = new UserStore<ApplicationUser>(context);
                    var manager = new UserManager<ApplicationUser>(store);
                    string userid = context.Users.First(s => s.UserName == korisnici).Id;
                    result = manager.AddToRole(userid, rola);
                    if (result.Succeeded)
                    {
                        string porukaZaRolu = "Korisniku " + korisnici + " je dodana rola " + rola;
                        ViewBag.porukaZaRolu = porukaZaRolu;
                        return View();
                    }
                    else
                    {
                        string porukaZaRolu = "Greška prilikom dodavanja role " + rola + " korisniku " + korisnici;
                        ViewBag.porukaZaRolu = porukaZaRolu;
                        return View();
                    }
                }
                else if (korisnici == "Odaberite korisnika" && dali == "DA")
                {
                    string porukaZaRolu = "Niste odabrali korisnika.";
                    ViewBag.porukaZaRolu = porukaZaRolu;
                    return View();
                }
                else if (korisnici != "Odaberite korisnika" && dali == null)
                {
                    string porukaZaRolu = "Niste postavili kvačicu.";
                    ViewBag.porukaZaRolu = porukaZaRolu;
                    return View();
                }
                else
                {
                    string porukaZaRolu = "Niste niti odabrali korisnika niti postavili kvačicu.";
                    ViewBag.porukaZaRolu = porukaZaRolu;
                    return View();
                }
            }
        }
        public ActionResult SkiniRoluAdminu(string admini, string dali)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                if (dali == "DA" && admini != "Odaberite admina")
                {
                    string rola = "admin";
                    IdentityResult result;
                    var store = new UserStore<ApplicationUser>(context);
                    var manager = new UserManager<ApplicationUser>(store);
                    string userid = context.Users.First(s => s.UserName == admini).Id;
                    result = manager.AddToRole(userid, rola);
                    if (result.Succeeded)
                    {
                        string porukaZaRolu = "Adminu " + admini + " su skinuta admin prava.";
                        ViewBag.porukaZaRolu = porukaZaRolu;
                        return View();
                    }
                    else
                    {
                        string porukaZaRolu = "Greška prilikom skidanja admin prava adminu " + admini + ".";
                        ViewBag.porukaZaRolu = porukaZaRolu;
                        return View();
                    }
                }
                else if (admini == "Odaberite admina" && dali == "DA")
                {
                    string porukaZaRolu = "Niste odabrali admina.";
                    ViewBag.porukaZaRolu = porukaZaRolu;
                    return View();
                }
                else if (admini != "Odaberite admina" && dali == null)
                {
                    string porukaZaRolu = "Niste postavili kvačicu.";
                    ViewBag.porukaZaRolu = porukaZaRolu;
                    return View();
                }
                else
                {
                    string porukaZaRolu = "Niste niti odabrali admina niti postavili kvačicu.";
                    ViewBag.porukaZaRolu = porukaZaRolu;
                    return View();
                }
            }
        }
        public ActionResult Prava()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            ViewBag.admini = db.Users.Where(x => x.Roles.Select(role => role.RoleId).Contains("bab046ae-8c4c-44b2-9cd9-94022e15a6f8")).ToList();
            ViewBag.korisnici = db.Users.Where(x => !x.Roles.Select(role => role.RoleId).Contains("bab046ae-8c4c-44b2-9cd9-94022e15a6f8")).ToList();
            //ApplicationDbContext korisnici = new ApplicationDbContext();
            //ViewBag.korisnici = korisnici.Users.ToList();
            return View();
        }
    }
}