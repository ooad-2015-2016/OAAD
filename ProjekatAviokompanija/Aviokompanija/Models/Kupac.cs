using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviokompanija.Models
{
    class Kupac : Osoba
    {
        public string BrojKartice { get; set; }
        public DateTime IstekKartice { get; set; }
        public int Cvc { get; set; }
    }
}
