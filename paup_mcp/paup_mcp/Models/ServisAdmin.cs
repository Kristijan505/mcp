using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace paup_mcp.Models
{
    public class ServisAdmin // model za modul Servis(admin)
    {
        // podaci o servisu vozila potrebni administratoru
        // podaci o vlasniku i vozilu??

        public int idServisa { get; set; }
        public DateTime vrijemeServisa { get; set; }
        public string opisPosla { get; set; }
        public double cijena { get; set; }
        public string napomena { get; set; }
        public bool obavljeno { get; set; }
    }
}