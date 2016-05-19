using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviokompanija.Models
{
    class Osoba
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string Adresa { get; set; }
        public string Mail { get; set; }

        public Osoba()
        {

        }
        public Osoba(string ime, string prezime, string brojTel, string adresa, string mail)
        {
            Ime = ime;
            Prezime = prezime;
            BrojTelefona = brojTel;
            Adresa = adresa;
            Mail = mail;
        }
    }
    
}
