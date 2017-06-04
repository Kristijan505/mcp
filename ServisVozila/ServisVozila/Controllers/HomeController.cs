using MySql.Data.MySqlClient;
using ServisVozila.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            int brojac = 0;
            ApplicationDbContext korisnici = new ApplicationDbContext();
            ViewBag.korisnici = korisnici.Users.Count();
            VoziloDbContext vozila = new VoziloDbContext();
            ViewBag.vozila = vozila.Vozila.Count();
            ServisDbContext obavljeniServisi = new ServisDbContext();
            ViewBag.obavljeniServisi = obavljeniServisi.Servisi.Where(o => o.obavljen == true).Count();
            ServisDbContext neobavljeniServisi = new ServisDbContext();
            ViewBag.neobavljeniServisi = neobavljeniServisi.Servisi.Where(o => o.obavljen == false).Count();

            string[] nazivi = {"Šrafimo mašinu","Skidamo haubu", "Točimo ulje kak debili", "Pehamo gume", "Nalukavljemo se u auspuhe", "Spajamo kompjutere" };
            string[] filePaths = { @"http://pngmotors.com/images/car_service.jpg", @"http://www.costarica-rentals.org/wp-content/uploads/2016/10/car-service.jpg", @"http://www.liftequipt.com.au/wp-content/uploads/2015/05/vehicle-service.jpg", @"http://wardsauto.com/site-files/wardsauto.com/files/imagecache/large_img/uploads/2016/02/service-department-workers.jpg", @"https://www.theaa.com/~/media/the-aa/article-summaries/driving-advice/service-repair/mot-test.jpg?h=400&la=en&w=640&hash=538D804BE8FBDC7ABC4C448090C2862B159D02B4", @"http://www.asiapacific.ford.com/servlet/Satellite?blobcol=urlpicture&blobheader=image%2Fjpeg&blobheadername1=Cache-Control&blobheadername2=Content-Disposition&blobheadername3=Content-Length&blobheadervalue1=max-age%3D1000&blobheadervalue2=inline%3B+filename%3D1178833381251.jpeg&blobheadervalue3=269356&blobkey=id&blobtable=DFYImage&blobwhere=1178833381251&ssbinary=true" };
            List<Slider> files = new List<Slider>();
            foreach (string filePath in filePaths)
            {
                files.Add(new Slider
                {
                    title = nazivi[brojac],
                    src = filePath
                });
                brojac++;
            }

            return View(files);
        }

        public ActionResult About()
        {
            ViewBag.Message = "O nama";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontakt";

            return View();
        }
    }
}