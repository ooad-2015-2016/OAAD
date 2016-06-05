using Aviokompanija.Helper;
using Aviokompanija.Models;
using Aviokompanija.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Aviokompanija.ViewModels
{
    class RezervacijaViewModel : INotifyPropertyChanged
    {
 
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }



        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }
        public string Mail { get; set; }
        public string MjestoPolaska { get; set; }
        public string MjestoDolaska { get; set; }
        public int Prtljag { get; set; }
        public DateTimeOffset DatumPolaska { get; set; }
        public Klasa ToggleKlasa { get; set; }
        public bool SaPopustom { get; set; }
        public string Verifikacija { get; set; }
        public int UkupnaCijena { get; set; }
        public string PrikazCijene { get; set; }


        public Let KliknutiLet { get; set; }
        public Rezervacija KliknutaRezervacija { get; set; }

        public INavigationService NavigationService { get; set; }
        public ICommand MijenjajKlasu { get; set; }
        public ICommand DodavanjeRezervacije { get; set; }
        public ICommand BrisanjeRezervacije { get; set; }
        public ICommand NazadAdmin { get; set; }
        public ICommand OsvjeziLetove { get; set; }
        public ICommand Racunaj { get; set; }




        public List<Let> SviLetovi
        {
            get
            {

                using (var db = new AviokompanijaDbContext())
                {

                    return db.Letovi.Where(x => x.MjestoDolaska == MjestoDolaska).Where(x => x.MjestoPolaska == MjestoPolaska).ToList();


                }
            }
        }

        public List<Rezervacija> SveRezervacije
        {
            get
            {

                using (var db = new AviokompanijaDbContext())
                {

                    return db.Rezervacije.OrderBy(x => x.RezervacijaId).ToList();


                }
            }
        }


        public RezervacijaViewModel()
        {
            NavigationService = new NavigationService();
            MijenjajKlasu = new RelayCommand<object>(mijenjajKlasu);
            DodavanjeRezervacije = new RelayCommand<object>(dodavanjeRezervacije);
            NazadAdmin = new RelayCommand<object>(nazadAdmin);
            BrisanjeRezervacije = new RelayCommand<object>(brisanjeRezervacije);
            OsvjeziLetove = new RelayCommand<object>(osvjeziLetove);
            Racunaj = new RelayCommand<object>(racunaj);



            MjestoDolaska = MjestoPolaska= Verifikacija = Ime= Prezime= Adresa = BrojTelefona= Mail = PrikazCijene= "";
            Prtljag = UkupnaCijena= 0;
            SaPopustom = false;
            ToggleKlasa = Klasa.Economy;
            DatumPolaska  = DateTime.Today;
          

            

        }
        public void osvjeziLetove(object o)
        {
            if (MjestoDolaska.Length == 0 || MjestoPolaska.Length == 0)
                Verifikacija = "Unesite mjesto dolaska i mjesto polaska.";
            NotifyPropertyChanged("MjestoPolaska");

            NotifyPropertyChanged("MjestoDolaska");

            NotifyPropertyChanged("Verifikacija");
            NotifyPropertyChanged("SviLetovi");


        }

        public void mijenjajKlasu(object o)
        {
            if ((int)ToggleKlasa == 2) ToggleKlasa = 0;
            else ToggleKlasa += 1;
            NotifyPropertyChanged("ToggleKlasa");


        }
        public void racunaj(object o)
        {
            if (KliknutiLet != null)
            {
                
                using (var db = new AviokompanijaDbContext())
                {
                    int Cijena;
                    if (SaPopustom == true) Cijena = (int)((double)KliknutiLet.Cijena + (double)Prtljag * 30 - (((double)KliknutiLet.Cijena + (double)Prtljag * 30) * 0.1));
                    else Cijena = KliknutiLet.Cijena + Prtljag * 30;
                    if ((int)ToggleKlasa == 0) Cijena += 40;
                    else if ((int)ToggleKlasa == 1) Cijena += 20;
                    else Cijena += 0;
                    PrikazCijene = Cijena.ToString();
                    NotifyPropertyChanged("PrikazCijene");

                }
            }
        }

        public void brisanjeRezervacije(object o)
        {
            if (KliknutaRezervacija != null)
            {

                using (var db = new AviokompanijaDbContext())
                {
                    Rezervacija pronadjeni = db.Rezervacije.Where(x => x.RezervacijaId == KliknutaRezervacija.RezervacijaId).SingleOrDefault();
                    if(pronadjeni != null)
                    {
                        if(pronadjeni.LetRezervacije != null)
                            pronadjeni.LetRezervacije.BrojZauzetihMjesta -= 1;

                        db.Remove(pronadjeni);
                        db.SaveChanges();
                        Verifikacija = "Uspješno izbrisana rezervacija.";
                        NotifyPropertyChanged("Verifikacija");
                        NotifyPropertyChanged("SveRezervacije");
                    }
                    // Let av = db.Letovi.FirstOrDefault();

                    

                }
            }
        }

        public void dodavanjeRezervacije(object parametar)
        {
            if (MjestoDolaska.Length == 0 || MjestoPolaska.Length == 0 || Ime.Length == 0 || Prezime.Length == 0 || Adresa.Length == 0 || BrojTelefona.Length == 0 || Mail.Length == 0)
            {
                Verifikacija = "Popunite prazna polja.";
            }

      
        //    else if (DateTime.Compare(DateTime.Now, VrijemePolaskaOS.DateTime.Add(VrijemePolaskaOS1))>0 || DateTime.Compare(DateTime.Now, VrijemeDolaskaOS.DateTime.Add(VrijemeDolaskaOS1)) > 0)
        //    {
         //       Verifikacija = "Izabrana vremena ne mogu biti u prošlosti.";
         //   }
        //    else if (DateTime.Compare(VrijemePolaskaOS.DateTime.Add(VrijemePolaskaOS1), VrijemeDolaskaOS.DateTime.Add(VrijemeDolaskaOS1)) > 0 )
        //    {
         //       Verifikacija = "Vrijeme polaska mora biti prije vremena dolaska.";
        //    }
            else if (KliknutiLet ==null)
                Verifikacija = "Niste izabrali let.";
            
            else
                using (var db = new AviokompanijaDbContext())
                {
                    Rezervacija novi = new Rezervacija();
                    KliknutiLet.BrojZauzetihMjesta += 1;
                    db.Update(KliknutiLet);
                    db.SaveChanges();
                    Kupac kupac = new Kupac();
                    kupac.Ime = Ime;
                    kupac.Prezime = Prezime;
                    kupac.Adresa = Adresa;
                    kupac.BrojTelefona = BrojTelefona;
                    kupac.Mail = Mail;

                    novi.KupacRezervacije = kupac;                  
                    novi.LetRezervacije = KliknutiLet;

                    novi.KolicinaPrtljaga = Prtljag;
                    novi.klasa = ToggleKlasa;
                    novi.Praznik = SaPopustom;
                    if (SaPopustom == true) novi.UkupnaCijena = (int)((double)KliknutiLet.Cijena + (double)Prtljag * 30 - (((double)KliknutiLet.Cijena + (double)Prtljag * 30) * 0.1));
                    else novi.UkupnaCijena = KliknutiLet.Cijena + Prtljag * 30;

                    if ((int)ToggleKlasa == 0) novi.UkupnaCijena += 40;
                    else if ((int)ToggleKlasa == 1) novi.UkupnaCijena += 20;
                    else novi.UkupnaCijena += 0;

                    db.Rezervacije.Add(novi);
                    db.SaveChanges();
                    MjestoDolaska = MjestoPolaska = Verifikacija = Ime = Prezime = Adresa = BrojTelefona = Mail = PrikazCijene= "";
                    DatumPolaska = DateTime.Today;
                    SaPopustom = false;
                    ToggleKlasa = Klasa.Economy;


                    Verifikacija = "Uspješno dodana rezervacija.";

                    NotifyPropertyChanged("Ime");
                    NotifyPropertyChanged("Prezime");
                    NotifyPropertyChanged("Adresa");
                    NotifyPropertyChanged("BrojTelefona");
                    NotifyPropertyChanged("Mail");
                    NotifyPropertyChanged("MjestoPolaska");
                    NotifyPropertyChanged("MjestoDolaska");
                    NotifyPropertyChanged("DatumPolaska");
                    NotifyPropertyChanged("SaPopustom");
                    NotifyPropertyChanged("ToggleKlasa");
                    NotifyPropertyChanged("PrikazCijene");

                    NotifyPropertyChanged("SviLetovi");
                    NotifyPropertyChanged("SveRezervacije");

                }

            NotifyPropertyChanged("Verifikacija");

        }

        private void nazadAdmin(object parametar)
        {
            NavigationService.Navigate(typeof(UposlenikMeni));
        }

 
    }
}

