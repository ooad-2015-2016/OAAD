using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviokompanija.Models
{
    public enum StatusLeta { Kasni, Sletio, Poletio, Odgodjen, Popunjen, TrebaPoletjeti}
    class Let
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LetId { get; set; }

        public Avion AvionLeta { get; set; }
        public string MjestoPolaska { get; set; }
        public string MjestoDolaska { get; set; }
        public DateTime VrijemePolaska { get; set; }
        public DateTime VrijemeDolaska { get; set; }
        public int Cijena { get; set; }
        public int BrojZauzetihMjesta { get; set; }
        public StatusLeta Status { get; set; }

        public Let() {

            }
        public Let(Avion avion, string mjestoP, string mjestoD, DateTime vrijemeP, DateTime vrijemeD, int cijena, int mjesta, StatusLeta status)
        {

            AvionLeta = avion;
            MjestoPolaska = mjestoP;
            MjestoDolaska = mjestoD;
            VrijemeDolaska = vrijemeD;
            VrijemePolaska = vrijemeP;
            Cijena = cijena;
            BrojZauzetihMjesta = mjesta;
            Status = status;

        }

    }
}
