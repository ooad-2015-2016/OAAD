using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviokompanija.Models
{
    class Avion
    {
        public int IdAviona { get; set; }
        public int BrojSjedista { get; set; }
        public bool Dostupnost { get; set; } 
    }

   
}
