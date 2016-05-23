using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviokompanija.Models
{
    class Kupac : Osoba
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KupacId { get; set; }


        public Kupac()
        {

        }
        public Kupac(string ime, string prezime, string brojTel, string adresa, string mail):base(ime, prezime, brojTel, adresa, mail)
        {
            // IdUposlenik = 0;
      
        }
    }
}
