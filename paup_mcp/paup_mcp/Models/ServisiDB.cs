using System;
using System.Collections.Generic;

namespace paup_mcp.Models
{
    public class ServisiDB
    {
        // lista Servisa kreirana samo za pomoć u izradi ostatka projekta
        // privremena baza dok se ne kreira prava SQL baza

        private List<ServisAdmin> listaServisa = new List<ServisAdmin>();

        public ServisiDB()
        {
            // dodavanje izmišljenih servisa

            listaServisa.Add(new ServisAdmin
            {

                idServisa = 1,
                vrijemeServisa = new DateTime(2017, 4, 10, 9, 30, 25), // proizvoljno vrijeme servisa
                opisPosla = "Promjena ulja u kočnicama.", // proizvoljan naziv popravka
                cijena = 199.99, // proizvolja cijena
                napomena = "Korišteno Castrol ulje za kočnice.", // proizvoljna napomena
                obavljeno = true // posao označen kao kompletno obavljen

            });

            // dodavanje još jednog izmišljenog servisa sa istim atributima

            listaServisa.Add(new ServisAdmin
            {

                idServisa = 2,
                vrijemeServisa = new DateTime(2017, 4, 12, 11, 2, 37), // proizvoljno vrijeme servisa
                opisPosla = "Zamjena filtera zraka.", // proizvoljan naziv popravka
                cijena = 250.00, // proizvolja cijena
                napomena = "Originalni (ne zamjenski) filter zraka.", // proizvoljna napomena
                obavljeno = true // posao označen kao kompletno obavljen

            });

            // dodavanje još jednog izmišljenog servisa sa istim atributima

            listaServisa.Add(new ServisAdmin
            {

                idServisa = 3,
                vrijemeServisa = new DateTime(2017, 4, 13, 14, 50, 3), // proizvoljno vrijeme servisa
                opisPosla = "Brušenje cilindra.", // proizvoljan naziv popravka
                cijena = 799.99, // proizvolja cijena
                napomena = "Posao nije dovršen radi završetka radnog vremena.", // proizvoljna napomena
                obavljeno = false // posao označen kao neobavljen kompletno

            });
        }

        public List<ServisAdmin> VratiServise()
        {
            return listaServisa;
        }
    }
}