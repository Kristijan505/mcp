using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ServisVozila.Models
{
    public class VoziloDbContext : DbContext
    {
        public DbSet<vozilo> Vozila { get; set; }
        // u db Contextu se dodaju db setovi,odnosno tablice
    }
}