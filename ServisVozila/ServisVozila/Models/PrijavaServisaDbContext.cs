using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ServisVozila.Models
{
    public class PrijavaServisaDbContext : DbContext
    {
        public DbSet<PrijavaServisa> PrServisa { get; set; }
    }
}