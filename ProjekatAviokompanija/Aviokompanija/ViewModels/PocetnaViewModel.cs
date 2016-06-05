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
using Windows.UI.Xaml;

namespace Aviokompanija.ViewModels
{
    class PocetnaViewModel : INotifyPropertyChanged
    {

        public Uposlenik UlogovaniRadnik { get; set; }
        public Administrator UlogovaniAdministrator { get; set; }

        public string VerifikacijaPoruka { get; set; }
        public string UpisaniUsername { get; set; }
        public string UpisaniPass { get; set; }
        public string Verifikacija { get; set; }


        public INavigationService NavigationService { get; set; }
        public ICommand AdminLogin { get; set; }
        public ICommand Izlaz { get; set; }
        public ICommand UposlenikLogin { get; set; }

        public ICommand MeniPregledLetova { get; set; }
        public ICommand MeniRezervacija { get; set; }
        public ICommand MeniLogout { get; set; }

        public ICommand MeniLetovi { get; set; }
        public ICommand MeniUposlenici { get; set; }
        public ICommand MeniAvioni { get; set; }

        public ICommand Help { get; set; }






        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }


        public PocetnaViewModel()
        {
            NavigationService = new NavigationService();
            UlogovaniAdministrator = new Administrator();
            UlogovaniRadnik = new Uposlenik();
            VerifikacijaPoruka = "";
            UpisaniPass = "";
            UpisaniUsername = Verifikacija = "";


            UposlenikLogin = new RelayCommand<object>(loginRadnika);
            AdminLogin = new RelayCommand<object>(adminLogin);
            Izlaz = new RelayCommand<object>(izlaz);
            MeniRezervacija = new RelayCommand<object>(meniRezervacija);
            MeniLogout = new RelayCommand<object>(meniLogout);

            MeniLetovi = new RelayCommand<object>(meniLetovi);
            MeniUposlenici = new RelayCommand<object>(meniUposlenici);
            MeniAvioni = new RelayCommand<object>(meniAvioni);

            Help = new RelayCommand<object>(help);


        }



  

     

        public PocetnaViewModel(PocetnaViewModel pvm)
        {
            NavigationService = new NavigationService();
            UlogovaniRadnik = pvm.UlogovaniRadnik;
            UlogovaniAdministrator = pvm.UlogovaniAdministrator;
            VerifikacijaPoruka = "";
            UpisaniPass = "";
            UpisaniUsername = Verifikacija= "";

            UposlenikLogin = new RelayCommand<object>(loginRadnika);
            AdminLogin = new RelayCommand<object>(adminLogin);
            Izlaz = new RelayCommand<object>(izlaz);
            MeniRezervacija = new RelayCommand<object>(meniRezervacija);
            MeniLogout = new RelayCommand<object>(meniLogout);

            MeniLetovi = new RelayCommand<object>(meniLetovi);
            MeniUposlenici = new RelayCommand<object>(meniUposlenici);
            MeniAvioni = new RelayCommand<object>(meniAvioni);
            Help = new RelayCommand<object>(help);


        }




        private void loginRadnika(object parametar)
        {
            using (var db = new AviokompanijaDbContext())
            {
                UlogovaniRadnik = db.Uposlenici.Where(x => x.Username == UpisaniUsername && x.Password == UpisaniPass).FirstOrDefault();

                if (UlogovaniRadnik == null)
                {
                    VerifikacijaPoruka = "Kombinacija password/username je nepostojeća.";
                    NotifyPropertyChanged("VerifikacijaPoruka");
                }
                else
                {
                    VerifikacijaPoruka = "";
                    NotifyPropertyChanged("VerifikacijaPoruka");
                    NavigationService.Navigate(typeof(UposlenikMeni), new PocetnaViewModel(this));
                }
            }

        }
        private void adminLogin(object parametar)
        {
            using (var db = new AviokompanijaDbContext())
            {
                UlogovaniAdministrator = db.Administratori.Where(x => x.Username == UpisaniUsername && x.Password == UpisaniPass).FirstOrDefault();

                if (UlogovaniAdministrator == null)
                {
                    VerifikacijaPoruka = "Kombinacija password/username je nepostojeća.";
                    NotifyPropertyChanged("VerifikacijaPoruka");
                }
                else
                {
                    VerifikacijaPoruka = "";
                    NotifyPropertyChanged("VerifikacijaPoruka");
                    NavigationService.Navigate(typeof(AdministratorMeni), new PocetnaViewModel(this));
                }
            }

        }


        private void izlaz(object parametar)
        {
            Application.Current.Exit();
        }


    

        private void meniRezervacija(object parametar)
        {
            NavigationService.Navigate(typeof(UposlenikRezervacija), new RezervacijaViewModel());
        }

        private void meniLogout(object parametar)
        {
            NavigationService.Navigate(typeof(Pocetna), new PocetnaViewModel());
        }




        private void meniAvioni(object parametar)
        {
            NavigationService.Navigate(typeof(Avioni), new AvioniViewModel());
        }


        private void meniUposlenici(object parametar)
        {
            NavigationService.Navigate(typeof(AdminUposlenici), new AdminUposleniciViewModel());
        }

        private void meniLetovi(object parametar)
        {
            NavigationService.Navigate(typeof(AdminLetovi), new AdminLetoviViewModel());
        }

        private void help(object parametar)
        {
            Verifikacija = "Upute za korištenje: \rMoguć je login kao admin i kao uposlenik. Nakon logovanja kao admin, dolazi se na meni sa opcijama: Avioni, Letovi, Uposlenici. Biranjem stavke Avioni, otvara se novi prozor gdje se mogu dodavati novi avioni i brisati avioni. Odabirom stavke Uposlenici u meniju, otvara se novi prozor gdje se mogu dodavati i brisati uposlenici. Odabirom stavke Letovi u meniju, otvara se novi prozor, gdje se mogu dodavati i brisati letovi. Dodavanje leta podrazumijeva i dodavanje aviona letu, koje se vrši odabirom aviona sa ponuđene liste. Moguće je i odabrati datum i vrijeme polaska i dolaska. Ukoliko se korisnik loguje kao uposlenik, moguće je sa menija odabrati stavku Rezervacije. Otvara se novi prozor za dodavanje i brisanje rezervacija. Nakon unošenja mjesta polaska i dolaska, klikom na Dugme Osvježi, pojavljuju se svi dostupni letovi s tim destinacijama. Osim popunjavanja podataka o kupcu i biranju leta, moguće je i uračunati popust klikom na checkbox, kao i mijenjanje klase klikanjem na dugme \" Mijenjaj klasu \". Klikom na dugme Izračunaj, prikazuje se ukupna cijena rezervacije sa svim odabranim parametrima. Sva brisanja u svim menijima se uvijek vrše prethodnim odabirom stavke sa liste. Također, svaki prozor sadrži Nazad tipku, kojom se vraća na prethodni prozor.";
            NotifyPropertyChanged("Verifikacija");

        }
    }
}
