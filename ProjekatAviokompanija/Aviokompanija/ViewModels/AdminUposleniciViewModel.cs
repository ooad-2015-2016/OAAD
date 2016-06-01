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
    class AdminUposleniciViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public List<Uposlenik> SviUposlenici
        {
            get
            {

                using (var db = new AviokompanijaDbContext())
                {

                    return db.Uposlenici.OrderBy(x => x.Prezime).ToList();


                }
            }
        }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string Adresa { get; set; }
        public string Mail { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Verifikacija { get; set; }



        public Uposlenik KliknutiUposlenik { get; set; }

        public INavigationService NavigationService { get; set; }
        public ICommand BrisanjeUposlenika { get; set; }
        public ICommand DodavanjeUposlenika{ get; set; }
        public ICommand NazadAdmin { get; set; }



        public AdminUposleniciViewModel()
        {
            NavigationService = new NavigationService();
            DodavanjeUposlenika = new RelayCommand<object>(dodavanjeUposlenika);
            BrisanjeUposlenika = new RelayCommand<object>(brisanjeUposlenika);
            NazadAdmin = new RelayCommand<object>(nazadAdmin);
            Ime = Prezime = Adresa = Mail = Username = Password=Verifikacija = "";

        }

        public void brisanjeUposlenika(object o)
        {
            if (KliknutiUposlenik != null)
            {
                using (var db = new AviokompanijaDbContext())
                {


                    db.Remove(KliknutiUposlenik);
                    db.SaveChanges();
                    Verifikacija = "Uspješno izbrisan uposlenik.";
                    NotifyPropertyChanged("Verifikacija");
                    NotifyPropertyChanged("SviUposlenici");
                }
            }
        }

        public void dodavanjeUposlenika(object parametar)
        {
            if (Ime.Length == 0 || Prezime.Length == 0 || BrojTelefona.Length == 0 || Adresa.Length == 0 || Mail.Length == 0 || Username.Length == 0 || Prezime.Length == 0)
            {
                Verifikacija = "Nijedno polje ne smije biti prazno.";
            }

            else if (Password.Length < 5)
            {
                Verifikacija = "Password mora imati minimalno 5 znakova.";
            }


            else
                using (var db = new AviokompanijaDbContext())
                {
                    Uposlenik novi = new Uposlenik();
                    novi.Ime = Ime;
                    novi.Prezime = Prezime;
                    novi.BrojTelefona = BrojTelefona;
                    novi.Adresa = Adresa;
                    novi.Mail = Mail;
                    novi.Username = Username;
                    novi.Password = Password;

                    db.Uposlenici.Add(novi);

                    db.SaveChanges();
                    Ime = Prezime = Adresa = Mail = Username = Password = "";

                    Verifikacija = "Uspješno dodan uposlenik.";

                    NotifyPropertyChanged("Ime");
                    NotifyPropertyChanged("Prezime");
                    NotifyPropertyChanged("Adresa");
                    NotifyPropertyChanged("BrojTelefona");
                    NotifyPropertyChanged("Mail");
                    NotifyPropertyChanged("Username");
                    NotifyPropertyChanged("Password");


                    NotifyPropertyChanged("SviUposlenici");
                }

            NotifyPropertyChanged("Verifikacija");

        }

        private void nazadAdmin(object parametar)
        {
            NavigationService.Navigate(typeof(AdministratorMeni));
        }
    }
}
