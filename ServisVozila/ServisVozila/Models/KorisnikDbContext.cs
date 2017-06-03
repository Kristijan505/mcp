using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ServisVozila.Models
{
    public class KorisnikDbContext : DbContext
    {
        public DbSet<korisnik> Korisnici { get; set; }
        // u db Contextu se dodaju db setovi,odnosno tablice
    }
}