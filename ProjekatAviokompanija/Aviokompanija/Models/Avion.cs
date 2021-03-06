﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviokompanija.Models
{
    class Avion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AvionId { get; set; }

        public string Model { get; set; }
        public int BrojSjedista { get; set; }
        public int BrojLetova { get; set; }


        public Avion()
        {

        }
        public Avion(string model, int brojSjedista,int dostupnost)
        {
            // IdUposlenik = 0;
            Model = model;
            BrojSjedista = brojSjedista;
            BrojLetova = dostupnost;
        }
    }
}
