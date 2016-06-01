using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using Aviokompanija.Models;

namespace AviokompanijaMigrations
{
    [ContextType(typeof(AviokompanijaDbContext))]
    partial class InitialMigration
    {
        public override string Id
        {
            get { return "20160530203752_InitialMigration"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("Aviokompanija.Models.Administrator", b =>
                {
                    b.Property<int>("AdministratorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<string>("BrojTelefona");

                    b.Property<string>("Ime");

                    b.Property<string>("Mail");

                    b.Property<string>("Password");

                    b.Property<string>("Prezime");

                    b.Property<string>("Username");

                    b.Key("AdministratorId");
                });

            builder.Entity("Aviokompanija.Models.Avion", b =>
                {
                    b.Property<int>("AvionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrojLetova");

                    b.Property<int>("BrojSjedista");

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

                    b.Property<int>("Cijena");

                    b.Property<string>("MjestoDolaska");

                    b.Property<string>("MjestoPolaska");

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

                    b.Property<int?>("KupacRezervacijeKupacId");

                    b.Property<int?>("LetRezervacijeLetId");

                    b.Property<bool>("Praznik");

                    b.Property<int>("UkupnaCijena");

                    b.Property<int>("klasa");

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
                });

            builder.Entity("Aviokompanija.Models.Rezervacija", b =>
                {
                    b.Reference("Aviokompanija.Models.Kupac")
                        .InverseCollection()
                        .ForeignKey("KupacRezervacijeKupacId");

                    b.Reference("Aviokompanija.Models.Let")
                        .InverseCollection()
                        .ForeignKey("LetRezervacijeLetId");
                });
        }
    }
}
