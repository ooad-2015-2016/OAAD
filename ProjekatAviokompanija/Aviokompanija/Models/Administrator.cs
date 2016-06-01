using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviokompanija.Models
{
    class Administrator : Osoba
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdministratorId { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public Administrator()
        {

        }
        public Administrator(string ime, string prezime, string brojTel, string adresa, string mail, int id, string user, string pass):base(ime, prezime, brojTel, adresa, mail)
        {
            // IdUposlenik = 0;
            Username = user;
            Password = pass;
        }
    }
}
