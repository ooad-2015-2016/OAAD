using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace AviokompanijaMigrations
{
    public partial class InitialMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    AdministratorId = table.Column(type: "INTEGER", nullable: false),
                      //  .Annotation("Sqlite:Autoincrement", true),
                    Adresa = table.Column(type: "TEXT", nullable: true),
                    BrojTelefona = table.Column(type: "TEXT", nullable: true),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    Mail = table.Column(type: "TEXT", nullable: true),
                    Password = table.Column(type: "TEXT", nullable: true),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    Username = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.AdministratorId);
                });
            migration.CreateTable(
                name: "Avion",
                columns: table => new
                {
                    AvionId = table.Column(type: "INTEGER", nullable: false),
                      //  .Annotation("Sqlite:Autoincrement", true),
                    BrojLetova = table.Column(type: "INTEGER", nullable: false),
                    BrojSjedista = table.Column(type: "INTEGER", nullable: false),
                    Model = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avion", x => x.AvionId);
                });
            migration.CreateTable(
                name: "Kupac",
                columns: table => new
                {
                    KupacId = table.Column(type: "INTEGER", nullable: false),
                      //  .Annotation("Sqlite:Autoincrement", true),
                    Adresa = table.Column(type: "TEXT", nullable: true),
                    BrojTelefona = table.Column(type: "TEXT", nullable: true),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    Mail = table.Column(type: "TEXT", nullable: true),
                    Prezime = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupac", x => x.KupacId);
                });
            migration.CreateTable(
                name: "Uposlenik",
                columns: table => new
                {
                    UposlenikId = table.Column(type: "INTEGER", nullable: false),
                       // .Annotation("Sqlite:Autoincrement", true),
                    Adresa = table.Column(type: "TEXT", nullable: true),
                    BrojTelefona = table.Column(type: "TEXT", nullable: true),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    Mail = table.Column(type: "TEXT", nullable: true),
                    Password = table.Column(type: "TEXT", nullable: true),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    Username = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uposlenik", x => x.UposlenikId);
                });
            migration.CreateTable(
                name: "Let",
                columns: table => new
                {
                    LetId = table.Column(type: "INTEGER", nullable: false),
                       // .Annotation("Sqlite:Autoincrement", true),
                    AvionLetaAvionId = table.Column(type: "INTEGER", nullable: true),
                    BrojZauzetihMjesta = table.Column(type: "INTEGER", nullable: false),
                    Cijena = table.Column(type: "INTEGER", nullable: false),
                    MjestoDolaska = table.Column(type: "TEXT", nullable: true),
                    MjestoPolaska = table.Column(type: "TEXT", nullable: true),
                    Status = table.Column(type: "INTEGER", nullable: false),
                    VrijemeDolaska = table.Column(type: "TEXT", nullable: false),
                    VrijemePolaska = table.Column(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Let", x => x.LetId);
                    table.ForeignKey(
                        name: "FK_Let_Avion_AvionLetaAvionId",
                        columns: x => x.AvionLetaAvionId,
                        referencedTable: "Avion",
                        referencedColumn: "AvionId");
                });
            migration.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    RezervacijaId = table.Column(type: "INTEGER", nullable: false),
                      //  .Annotation("Sqlite:Autoincrement", true),
                    KolicinaPrtljaga = table.Column(type: "INTEGER", nullable: false),
                    KupacRezervacijeKupacId = table.Column(type: "INTEGER", nullable: true),
                    LetRezervacijeLetId = table.Column(type: "INTEGER", nullable: true),
                    Praznik = table.Column(type: "INTEGER", nullable: false),
                    UkupnaCijena = table.Column(type: "INTEGER", nullable: false),
                    klasa = table.Column(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.RezervacijaId);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Kupac_KupacRezervacijeKupacId",
                        columns: x => x.KupacRezervacijeKupacId,
                        referencedTable: "Kupac",
                        referencedColumn: "KupacId");
                    table.ForeignKey(
                        name: "FK_Rezervacija_Let_LetRezervacijeLetId",
                        columns: x => x.LetRezervacijeLetId,
                        referencedTable: "Let",
                        referencedColumn: "LetId");
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Administrator");
            migration.DropTable("Rezervacija");
            migration.DropTable("Uposlenik");
            migration.DropTable("Kupac");
            migration.DropTable("Let");
            migration.DropTable("Avion");
        }
    }
}
