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

        public string BrojKartice { get; set; }
        public DateTime IstekKartice { get; set; }
        public int Cvc { get; set; }
    }
}
