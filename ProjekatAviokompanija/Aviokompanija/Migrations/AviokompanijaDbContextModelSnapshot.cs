using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using Aviokompanija.Models;

namespace AviokompanijaMigrations
{
    [ContextType(typeof(AviokompanijaDbContext))]
    partial class AviokompanijaDbContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("Aviokompanija.Models.Avion", b =>
                {
                    b.Property<int>("AvionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrojSjedista");

                    b.Property<bool>("Dostupnost");

                    b.Property<string>("Model");

                    b.Key("AvionId");
                });

            builder.Entity("Aviokompanija.Models.Kupac", b =>
                {
                    b.Property<int>("KupacId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<string>("BrojTelefona");

                    b.Property<string>("Ime");

                    b.Property<string>("Mail");

                    b.Property<string>("Prezime");

                    b.Key("KupacId");
                });

            builder.Entity("Aviokompanija.Models.Let", b =>
                {
                    b.Property<int>("LetId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AvionLetaAvionId");

                    b.Property<int>("BrojZauzetihMjesta");

                    b.Property<decimal>("Cijena");

                    b.Property<string>("MjestoDolaska");

                    b.Property<string>("MjestoPolaska");

                    b.Property<int?>("RezervacijaRezervacijaId");

                    b.Property<int>("Status");

                    b.Property<DateTime>("VrijemeDolaska");

                    b.Property<DateTime>("VrijemePolaska");

                    b.Key("LetId");
                });

            builder.Entity("Aviokompanija.Models.Rezervacija", b =>
                {
                    b.Property<int>("RezervacijaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("KolicinaPrtljaga");

                    b.Property<decimal>("Popust");

                    b.Property<int>("klasa");

                    b.Property<int?>("kupacKupacId");

                    b.Key("RezervacijaId");
                });

            builder.Entity("Aviokompanija.Models.Uposlenik", b =>
                {
                    b.Property<int>("UposlenikId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<string>("BrojTelefona");

                    b.Property<string>("Ime");

                    b.Property<string>("Mail");

                    b.Property<string>("Password");

                    b.Property<string>("Prezime");

                    b.Property<string>("Username");

                    b.Key("UposlenikId");
                });

            builder.Entity("Aviokompanija.Models.Let", b =>
                {
                    b.Reference("Aviokompanija.Models.Avion")
                        .InverseCollection()
                        .ForeignKey("AvionLetaAvionId");

                    b.Reference("Aviokompanija.Models.Rezervacija")
                        .InverseCollection()
                        .ForeignKey("RezervacijaRezervacijaId");
                });

            builder.Entity("Aviokompanija.Models.Rezervacija", b =>
                {
                    b.Reference("Aviokompanija.Models.Kupac")
                        .InverseCollection()
                        .ForeignKey("kupacKupacId");
                });
        }
    }
}
