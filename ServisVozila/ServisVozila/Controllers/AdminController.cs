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

        public ContentResult DodajRoluKorisniku()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                string rola = "admin";
                string korisnik = @"kristijan.pravica@gmail.com";
                IdentityResult result;
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                string userid = context.Users.FirstOrDefault(s => s.UserName == korisnik).Id;
                result = manager.AddToRole(userid, rola);
                if (result.Succeeded)
                    return Content("Korisniku " + korisnik + " dodana rola " + rola);
                else
                    return Content("Greška prilikom dodavanja role " + rola + " korisniku " + korisnik);
            }
        }
        public ActionResult Prava()
        {
            ApplicationDbContext admini = new ApplicationDbContext();
            ViewBag.admini = admini.Users.Where(x => x.Roles.Select(role => role.RoleId).Contains("bab046ae-8c4c-44b2-9cd9-94022e15a6f8")).ToList();
            ApplicationDbContext korisnici = new ApplicationDbContext();
            ViewBag.korisnici = korisnici.Users.ToList();
            return View();
        }
    }
}