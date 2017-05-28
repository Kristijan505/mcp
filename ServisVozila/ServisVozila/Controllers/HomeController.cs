using ServisVozila.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServisVozila.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Content/img/"));
            List<Slider> files = new List<Slider>();
            foreach (string filePath in filePaths)
            {
                string fileName = Path.GetFileName(filePath);
                files.Add(new Slider
                {
                    title = fileName.Split('.')[0].ToString(),
                    src = "../Content/img/" + fileName
                });
            }

            return View(files);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}