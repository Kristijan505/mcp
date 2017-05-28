using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ServisVozila.Models
{
    [Table("korisnik")]
    public class korisnik
    {
        [Key]
        public int idKorisnik { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string telefon { get; set; }
        public string adresa { get; set; }
        public string mail { get; set; }
        public string OIB { get; set; }
        public string biljeska { get; set; }
        public string lozinka { get; set; }
        public string grad { get; set; }
        public int posta { get; set; }
        public bool admin { get; set; }
    }
}