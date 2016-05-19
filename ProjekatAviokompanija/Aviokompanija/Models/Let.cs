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
        public decimal Cijena { get; set; }
        public int BrojZauzetihMjesta { get; set; }
        public StatusLeta Status { get; set; }
    }
}
