using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviokompanija.Models
{
    public enum Klasa { First, Business, Economy}

    class Rezervacija
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RezervacijaId { get; set; }
        public Klasa klasa { get; set; }
        public Let LetRezervacije { get; set; } 
        public Kupac KupacRezervacije { get; set; }
        public bool Praznik { get; set; }
        public int KolicinaPrtljaga { get; set; }
        public int UkupnaCijena { get; set; }




        public Rezervacija()
        {

        }
        public Rezervacija(Klasa kklasa, Let let, Kupac kupac, bool praznik, int prtljag, int cijena)
        {

            klasa = kklasa;
            LetRezervacije = let;
            KupacRezervacije = kupac;
            Praznik = praznik;
            KolicinaPrtljaga = prtljag;
            UkupnaCijena = cijena;

        }
    }




}
