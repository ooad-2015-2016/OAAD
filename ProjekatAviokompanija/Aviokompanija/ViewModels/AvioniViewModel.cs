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
    class AvioniViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public List<Avion> SviAvioni
        {
            get
            {

                using (var db = new AviokompanijaDbContext())
                {
                   
                        return db.Avioni.OrderBy(x => x.BrojLetova).ToList();
                   



                    
                }
            }
        }

        public string Model { get; set; }
        public int BrojSjedista { get; set; }
        public int BrojLetova { get; set; }
        public string Verifikacija { get; set; }

        public Avion KliknutiAvion { get; set; }

        public INavigationService NavigationService { get; set; }
        public ICommand BrisanjeAviona { get; set; }
        public ICommand DodavanjeAviona { get; set; }
        public ICommand NazadAdmin { get; set; }



        public AvioniViewModel()
        {
            NavigationService = new NavigationService();
            DodavanjeAviona= new RelayCommand<object>(dodavanjeAviona);
            BrisanjeAviona = new RelayCommand<object>(brisanjeAviona);
            NazadAdmin = new RelayCommand<object>(nazadAdmin);
            Model = "";
            BrojSjedista = 0;
            BrojLetova = 0;
            Verifikacija = "";
           
        }

        public void brisanjeAviona(object o)
        {
            if (KliknutiAvion != null)
            {
                if (KliknutiAvion.BrojLetova != 0)
                {
                    Verifikacija = "Izbrišite prvo letove koji su dodijeljeni avionu.";
                    NotifyPropertyChanged("Verifikacija");

                }
                else
                    using (var db = new AviokompanijaDbContext())
                    {


                        db.Remove(KliknutiAvion);
                        db.SaveChanges();
                        Verifikacija = "Uspješno izbrisan avion.";
                        NotifyPropertyChanged("Verifikacija");
                        NotifyPropertyChanged("SviAvioni");
                    }
            }
        }

        public void dodavanjeAviona(object parametar)
        {
            if (Model.Length == 0)
                Verifikacija = "Morate unijeti model aviona.";

            else if (BrojSjedista<=0)
                Verifikacija = "Broj sjedišta mora biti veći od nule.";



            else
                using (var db = new AviokompanijaDbContext())
                {
                    Avion novi = new Avion();
                    novi.Model = Model;
                    novi.BrojSjedista = BrojSjedista;
                    novi.BrojLetova = 0;
                   
                    db.Avioni.Add(novi);

                    db.SaveChanges();
                    Model = "";
                    BrojSjedista = BrojLetova= 0;
                    Verifikacija = "Uspješno dodan avion.";

                    NotifyPropertyChanged("Model");
                    NotifyPropertyChanged("BrojSjedista");
                    NotifyPropertyChanged("Dostupnost");
                  
                    NotifyPropertyChanged("SviAvioni");
                }

            NotifyPropertyChanged("Verifikacija");

        }

        private void nazadAdmin(object parametar)
        {
            NavigationService.Navigate(typeof(AdministratorMeni));
        }
    }
}
