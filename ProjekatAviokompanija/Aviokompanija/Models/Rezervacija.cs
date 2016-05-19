using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviokompanija.Models
{
    public enum Klasa { First, Business, Economy}

    class Rezervacija
    {
        public int RezervacijaId { get; set; }
        public Klasa klasa { get; set; }
        public List<Let> Letovi { get; set; } // 1 ili 2 leta
        public Kupac kupac { get; set; }
        public decimal Popust { get; set; }
        public int KolicinaPrtljaga { get; set; }
        public decimal CijenaPrtljaga { get { return 30 * KolicinaPrtljaga; } }
    }
}
