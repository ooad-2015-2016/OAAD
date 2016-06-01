using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviokompanija.Models
{
    class DefaultPodaci
    {
        public static void Initialize(AviokompanijaDbContext context)
        {
            if (!context.Uposlenici.Any())
            {
                context.Uposlenici.AddRange(
                    new Uposlenik()
                    {
                        Ime = "Huso",
                        Prezime = "Husić",
                        BrojTelefona = "0038762222222",
                        Adresa = "Bulevar 20",
                        Mail = "husohusic@etf.unsa.ba",
                        Username="huso",
                        Password="huso",
                    }
                );
                context.SaveChanges();
            }

            if (!context.Administratori.Any())
            {
                context.Administratori.AddRange(
                    new Administrator()
                    {
                        Ime = "muso",
                        Prezime = "music",
                        BrojTelefona = "0038762222222",
                        Adresa = "Bulevar 20",
                        Mail = "husohusic@etf.unsa.ba",
                        Username = "admin",
                        Password = "admin",
                    }
                );
                context.SaveChanges();
            }

            if (!context.Avioni.Any())
            {
                context.Avioni.AddRange(
                    new Avion()
                    {
                        Model = "Embraer 106",
                        BrojSjedista = 100,
                        BrojLetova=0,
                    }
                );
                context.SaveChanges();
            }

            if (!context.Kupci.Any())
            {
                context.Kupci.AddRange(
                    new Kupac()
                    {
                        Ime = "Muso",
                        Prezime = "Musić",
                        BrojTelefona = "0038762212222",
                        Adresa = "Bulevar 130",
                        Mail = "musomusic@etf.unsa.ba",
                
                    }
                );
                context.SaveChanges();
            }

           

        }
    }
}
