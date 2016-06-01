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
    class AdminLetoviViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }



        public Avion AvionLeta { get; set; }
        public string MjestoPolaska { get; set; }
        public string MjestoDolaska { get; set; }
        public DateTimeOffset VrijemePolaskaOS { get; set; }
        public DateTimeOffset VrijemeDolaskaOS { get; set; }
        public TimeSpan VrijemePolaskaOS1 { get; set; }
        public TimeSpan VrijemeDolaskaOS1 { get; set; }
        public DateTime VrijemePolaska { get; set; }
        public DateTime VrijemeDolaska { get; set; }
        public int Cijena { get; set; }
        public int LetId { get; set; }

        public int BrojZauzetihMjesta { get; set; }
        public StatusLeta Status { get; set; }
        public string Verifikacija { get; set; }

        public Let KliknutiLet { get; set; }
        public Avion KliknutiAvion { get; set; }

        public INavigationService NavigationService { get; set; }
        public ICommand BrisanjeLeta { get; set; }
        public ICommand DodavanjeLeta { get; set; }
        public ICommand NazadAdmin { get; set; }
        public ICommand MijenjajStatus { get; set; }


        public List<Let> SviLetovi
        {
            get
            {

                using (var db = new AviokompanijaDbContext())
                {

                    return db.Letovi.OrderBy(x => x.VrijemePolaska).ToList();


                }
            }
        }

        public List<Avion> SviDostupniAvioni
        {
            get
            {

                using (var db = new AviokompanijaDbContext())
                {

                    return db.Avioni.OrderBy(x => x.BrojLetova).ToList();


                }
            }
        }


        public AdminLetoviViewModel()
        {
            NavigationService = new NavigationService();
            DodavanjeLeta = new RelayCommand<object>(dodavanjeLeta);
            BrisanjeLeta = new RelayCommand<object>(brisanjeLeta);
            NazadAdmin = new RelayCommand<object>(nazadAdmin);
            MijenjajStatus = new RelayCommand<object>(mijenjajStatus);
            MjestoDolaska = MjestoPolaska= Verifikacija = "";
           VrijemePolaskaOS = VrijemeDolaskaOS = DateTime.Today;

            Cijena = BrojZauzetihMjesta = LetId= 0;
            Status = StatusLeta.TrebaPoletjeti;

        }

        public void brisanjeLeta(object o)
        {
            if (KliknutiLet != null)
            {
                
                using (var db = new AviokompanijaDbContext())
                {
                    Let pronadjeni =  db.Letovi.Where(x => x.LetId == KliknutiLet.LetId).FirstOrDefault();
                     Avion av = db.Avioni.FirstOrDefault();
                     NotifyPropertyChanged("Verifikacija");
                    pronadjeni.AvionLeta.BrojLetova -= 1;
                    db.Remove(pronadjeni);
                    db.SaveChanges();
                    Verifikacija = "Uspješno izbrisan let.";
                   NotifyPropertyChanged("Verifikacija");
                    NotifyPropertyChanged("SviLetovi");
                    NotifyPropertyChanged("SviDostupniAvioni");

                }
            }
        }

        public void dodavanjeLeta(object parametar)
        {
            if (MjestoDolaska.Length == 0 || MjestoPolaska.Length == 0)
            {
                Verifikacija = "Unesite mjesto dolaska i polaska.";
            }

          else if (Cijena<=0)
         {
               Verifikacija = "Cijena mora biti veća od nule.";
            }
            else if (DateTime.Compare(DateTime.Now, VrijemePolaskaOS.DateTime.Add(VrijemePolaskaOS1))>0 || DateTime.Compare(DateTime.Now, VrijemeDolaskaOS.DateTime.Add(VrijemeDolaskaOS1)) > 0)
            {
                Verifikacija = "Izabrana vremena ne mogu biti u prošlosti.";
            }
            else if (DateTime.Compare(VrijemePolaskaOS.DateTime.Add(VrijemePolaskaOS1), VrijemeDolaskaOS.DateTime.Add(VrijemeDolaskaOS1)) > 0 )
            {
                Verifikacija = "Vrijeme polaska mora biti prije vremena dolaska.";
            }
            else if (KliknutiAvion ==null)
                Verifikacija = "Niste izabrali avion.";
            
            else
                using (var db = new AviokompanijaDbContext())
                {
                    Let novi = new Let();
                    KliknutiAvion.BrojLetova += 1;
                    db.Update(KliknutiAvion);
                    db.SaveChanges();
                    novi.AvionLeta = KliknutiAvion;
                    novi.MjestoPolaska = MjestoPolaska;
                    novi.MjestoDolaska = MjestoDolaska;
                    novi.VrijemePolaska = VrijemePolaskaOS.DateTime.Date.Add(VrijemePolaskaOS1);
                    novi.VrijemeDolaska = VrijemeDolaskaOS.DateTime.Date.Add(VrijemeDolaskaOS1);
                    novi.Cijena = Cijena;
                    novi.BrojZauzetihMjesta = 0;
                    novi.Status = StatusLeta.TrebaPoletjeti;
                    db.Letovi.Add(novi);

           

                    db.SaveChanges();
                    MjestoDolaska = MjestoPolaska = Verifikacija = "";
                    VrijemePolaskaOS = VrijemeDolaskaOS = DateTime.Today;

                    Cijena = BrojZauzetihMjesta = 0;
                    Status = StatusLeta.TrebaPoletjeti;

                  Verifikacija = "Uspješno dodan let.";

                    NotifyPropertyChanged("LetId");
                    NotifyPropertyChanged("MjestoPolaska");
                    NotifyPropertyChanged("MjestoDolaska");
                    NotifyPropertyChanged("VrijemePolaska");
                    NotifyPropertyChanged("VrijemeDolaska");
                    NotifyPropertyChanged("Cijena");
                    NotifyPropertyChanged("BrojZauzetihMjesta");
                    NotifyPropertyChanged("Status");



                    NotifyPropertyChanged("SviLetovi");

                }

            NotifyPropertyChanged("Verifikacija");

        }

        private void nazadAdmin(object parametar)
        {
            NavigationService.Navigate(typeof(AdministratorMeni));
        }

        private void mijenjajStatus(object parametar)
        {
            if (KliknutiLet != null)
            {

                using (var db = new AviokompanijaDbContext())
                {
                    Let pronadjeni = db.Letovi.Where(x => x.LetId == KliknutiLet.LetId).FirstOrDefault();
                    Avion av = db.Avioni.FirstOrDefault();
                    if ((int)pronadjeni.Status == 5)
                        pronadjeni.Status = 0;
                    else
                        pronadjeni.Status += 1;
                    db.Update(pronadjeni);
                    db.SaveChanges();
                    Verifikacija = "Uspješno promijenjen status leta.";
                    NotifyPropertyChanged("Verifikacija");
                    NotifyPropertyChanged("SviLetovi");

                    NotifyPropertyChanged("Status");

                }
            }
        }
    }
}
