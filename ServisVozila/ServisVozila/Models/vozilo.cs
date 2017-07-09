using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ServisVozila.Models
{
    [Table("vozilo")]
    public class vozilo
    {
        [Key]
        // svojstva vozila( na temelju toga se ispisuju podaci iz tablice vozilo)
        public int idVozilo { get; set; }
        public string idKorisnik { get; set; }
        public string marka { get; set; }
        public string model { get; set; }
        [Range(1950,2017)]
        public int godinaProiz { get; set; }
        public string boja { get; set; }
        [Range(0,10000)]
        public int zapremina { get; set; }
        [Range(0,100000)]
        public int nosivost { get; set; }
        [Range(1950,2017)]
        public int godinaReg { get; set; }
        public string regBroj { get; set; }
    }
    public class voziloDTO
    {
        public int idVozilo { get; set; }
        public string marka { get; set; }
        public string model { get; set; }
        public int zapremina { get; set; }
        public int godinaProiz { get; set; }
        public string boja { get; set; }
        public string regBroj { get; set; }
    }
}