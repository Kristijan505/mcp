using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ServisVozila.Models
{
    [Table("servis")]
    public class servis
    {
        [Key]
        public int idServis { get; set; }
        public string idKorisnik { get; set; }
        public int idVozilo { get; set; }
        public DateTime datum { get; set; }
        public string opisPosla { get; set; }
        public int cijena { get; set; }
        public string napomena { get; set; }
        public bool obavljen { get; set; }
    }
}