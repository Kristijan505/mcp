using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ServisVozila.Models
{
    [Table("test")]
    public class test
    {
        [Key]
        public int sifra { get; set; }
        public string naziv { get; set; }
    }
}