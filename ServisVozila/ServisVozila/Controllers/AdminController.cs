using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ServisVozila.App_Start;
using ServisVozila.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServisVozila.Controllers
{
    [CustomAuthorize(Roles = "admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DodajRoluKorisniku(string korisnici, string dali)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                if (dali == "DA" && korisnici != "")
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
                else if (korisnici == "" && dali == "DA")
                {
                    string porukaZaRolu = "Niste odabrali korisnika.";
                    ViewBag.porukaZaRolu = porukaZaRolu;
                    return View();
                }
                else if (korisnici != "" && dali == null)
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
                if (dali == "DA" && admini != "")
                {
                    string rola = "admin";
                    IdentityResult result;
                    var store = new UserStore<ApplicationUser>(context);
                    var manager = new UserManager<ApplicationUser>(store);
                    string userid = context.Users.First(s => s.UserName == admini).Id;
                    result = manager.RemoveFromRole(userid, rola);
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
                else if (admini == "" && dali == "DA")
                {
                    string porukaZaRolu = "Niste odabrali admina.";
                    ViewBag.porukaZaRolu = porukaZaRolu;
                    return View();
                }
                else if (admini != "" && dali == null)
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

        public ActionResult Poruka()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            ViewBag.korisnici = db.Users.Where(x => !x.Roles.Select(role => role.RoleId).Contains("bab046ae-8c4c-44b2-9cd9-94022e15a6f8")).ToList();
            return View();
        }

        public ActionResult Slanje(string korisnici, string poruka, string dali)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                if (dali == "DA" && korisnici != "" && poruka != "")
                {
                    GMailer.GmailUsername = "radionicamvc@gmail.com";
                    GMailer.GmailPassword = "MVCProjekt";
                    GMailer mail = new GMailer();
                    mail.ToEmail = korisnici;
                    mail.Subject = "Poruka od administratora.";
                    mail.Body = poruka;
                    mail.IsHtml = true;
                    mail.Send();
                    string porukaZaPoruku = "Poruka je poslana korisniku: " +korisnici+".";
                    ViewBag.porukaZaPoruku = porukaZaPoruku;
                    return View();
                }
                else
                {
                    string porukaZaPoruku = "Poruka nije poslana iz jednog od sljedečih razloga:";
                    ViewBag.porukaZaPoruku = porukaZaPoruku;
                    string porukaZaPoruku2 = "1. Niste odabrali korisnika";
                    ViewBag.porukaZaPoruku2 = porukaZaPoruku2;
                    string porukaZaPoruku3 = "2.Niste napisali poruku";
                    ViewBag.porukaZaPoruku3 = porukaZaPoruku3;
                    string porukaZaPoruku4 = "3.Niste potvrdili unos kvačicom.";
                    ViewBag.porukaZaPoruku4 = porukaZaPoruku4;
                    return View();
                }
            }
        }
    }

}
