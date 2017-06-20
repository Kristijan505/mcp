using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServisVozila.Models
{
    [Table("prijavaservisa")]
    public class PrijavaServisa
    {
        [Key]
        [Display(Name = "ID")]
        public int idkorisnika { get; set; }

        [Display(Name = "Vaše Ime i Prezime")]
        public string ime_i_prezime { get; set; }

        [Display(Name = "Vaša e-mail adresa")]
        [EmailAddress (ErrorMessage ="Molimo unesite ispravnu e-mail adresu") ]
        public string email { get; set; }

        [Display(Name = "Tel/mob")]
        public int tel_broj { get; set; }

        //validacije ali ne rade...
        [Display(Name ="odaberite datum (dan/mjesec/godina)")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        [Required(ErrorMessage ="Molimo upisite kada zelite popravak")]
        public DateTime datum_popravka { get; set; }

        [Display(Name = "Opis Servisa")]
        public string opis_servisa { get; set; }

        [Display(Name = "Marka Vozila")]
        public string markavozila { get; set; }

        [Display(Name = "Model Vozila")]
        public string modelvozila { get; set; }
    }
}