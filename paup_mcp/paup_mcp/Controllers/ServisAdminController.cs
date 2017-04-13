using paup_mcp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;

namespace paup_mcp.Controllers
{
    public class ServisAdminController : Controller
    {
        // model forme
        private ServisiDB servisiA = new ServisiDB();

        // GET: ServisAdmin
        // ulazna stranica
        public ActionResult IndexServisAdmin()
        {

            ViewBag.Title="Servis - administracija";
            return View();

        }

        public ActionResult ServisAdminDetaljno(int id = 1)
        {
            
            // lambda izraz - pronađi prvi servis koji ima ID jednak ulaznom parametru
            ServisAdmin sa = servisiA.VratiServise().Find(x => x.idServisa == id);
            ViewBag.Title = "Detaljno o servisu";

            // vraćamo view sa modelom kao ulaznim parametrom
            return View(sa);

        }

        public ActionResult PopisServisa()
        {
            ViewBag.Title = "Popis servisa";

            // vraćamo view sa listom svih studenata kao ulaznim parametrom
            return View(servisiA);
        }

    }
}