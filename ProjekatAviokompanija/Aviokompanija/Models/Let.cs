using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviokompanija.Models
{
    class Let
    {
        public int IdLeta { get; set; }
        public Avion AvionLeta { get; set; }
        public string MjestoPolaska { get; set; }
        public string MjestoDolaska { get; set; }
        public DateTime VrijemePolaska { get; set; }
        public DateTime VrijemeDolaska { get; set; }
        public double Cijena { get; set; }
        public int BrojZauzetihMjesta { get; set; }
    }
}
